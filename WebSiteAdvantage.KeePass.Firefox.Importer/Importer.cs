/*
 * WebSiteAdvantage KeePass to Firefox
 *
 * Copyright (C) 2008 - 2012 Anthony James McCreath
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Linq;
using System.Windows.Forms;

using KeePass.DataExchange;
using KeePass.Resources;

using KeePassLib;
using KeePassLib.Interfaces;
using KeePassLib.Security;

using WebSiteAdvantageKeePassFirefoxImporter.Properties;
using WebSiteAdvantage.KeePass.Firefox.Profiles;
using WebSiteAdvantage.KeePass.Firefox.Signons;
using WebSiteAdvantage.KeePass.Firefox.Utilities;

namespace WebSiteAdvantageKeePassFirefoxImporter
{
    /// <summary>
    /// A singleton class that performs the import
    /// </summary>
    public sealed class Importer : FileFormatProvider
    {
        private const string Note = "Imported from FireFox by the Web Site Advantage FireFox to KeePass Importer";
        private static readonly Lazy<Importer> LazyImporter = new Lazy<Importer>();

        public static Importer Instance
        {
            get
            {
                return LazyImporter.Value;
            }
        }

        public override bool SupportsImport
        {
            get
            {
                return true;
            }
        }

        public override bool SupportsExport
        {
            get
            {
                return false;
            }
        }

        public override string FormatName
        {
            get
            {
                return "Firefox";
            }
        }

        /// <inheritdoc />
        public override string DefaultExtension
        {
            get
            {
                return "xml";
            }
        }

        /// <inheritdoc />
        public override string ApplicationGroup
        {
            get
            {
                return KPRes.Browser;
            }
        }

        /// <inheritdoc />
        public override bool ImportAppendsToRootGroupOnly
        {
            get
            {
                return false;
            }
        }

        /// <remarks>
        /// Data is retrieved directly from Firefox
        /// </remarks>
        public override bool RequiresFile
        {
            get
            {
                return false;
            }
        }

        /// <remarks>
        /// Should get a Firefox icon.
        /// </remarks>
        public override System.Drawing.Image SmallIcon
        {
            get
            {
                return Resources.firefox16;
            }
        }

        /// <inheritdoc />
        public override void Import(PwDatabase db, System.IO.Stream input, IStatusLogger logger)
        {
            try
            {
                ImportDialog form;

                while (true)
                {
                    form = new ImportDialog(db);

                    if (form.ShowDialog() != DialogResult.OK)
                        return;

                    if (string.IsNullOrEmpty(form.ProfilePath))
                    {
                        MessageBox.Show(
                            "No Profile Selected. Use Load More Profiles",
                            "Profile Required",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    else
                    {
                        break;
                    }
                }

                try
                {
                    logger.StartLogging("Importing Firefox Passwords", false);
                    logger.SetText("Logging in.", LogStatusType.Info);

                    using (var profile = new Profile(form.ProfilePath, form.Password))
                    {
                        logger.SetText("Reading signon file.", LogStatusType.Info);
                        Signon[] signons = profile.GetSignons().ToArray();

                        logger.SetText("Processing passwords.", LogStatusType.Info);
                        var pos = 0;

                        foreach (Signon signon in signons)
                        {
                            if (!logger.ContinueWork()) // Check if process has been cancelled by the user.
                                break;

                            ++pos;
                            logger.SetProgress((uint) (100 * (double) pos / signons.Length));
                            AddEntry(signon, form, db, logger);
                        }
                    }
                }
                finally
                {
                    logger.EndLogging();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Failed to Validate Password"))
                    MessageBox.Show(ex.Message, "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    ErrorDialog.Show("Import Failed", ex);
            }
        }

        public static void AddEntry(Signon signon, ImportDialog form, PwDatabase db, IStatusLogger logger)
        {
            logger.SetText("Processing signon " + signon.Username + " @ " + signon.Hostname + ".", LogStatusType.Info);

            PwGroup group = form.Group ?? db.RootGroup;
            PwEntry entry = null;
            var newEntry = true;

            if (form.CheckExisting) // TODO: Search using both the Hostname and FormSubmitUrl.
                entry = KeePassHelper.FindMatchingEntry(db.RootGroup, signon.Hostname, signon.Username);

            if (entry == null)
            {
                // Create a new entry.
                entry = new PwEntry(true, true);
                group.AddEntry(entry, true);
                logger.SetText("Created new entry.", LogStatusType.AdditionalInfo);
            }
            else
            {
                newEntry = false;
                logger.SetText("Found matching entry.", LogStatusType.AdditionalInfo);
            }

            if (newEntry || form.Overwrite)
            {
                // Set the password.
                entry.Strings.Set(
                    PwDefs.PasswordField,
                    new ProtectedString(db.MemoryProtection.ProtectPassword, signon.Password)
                );
            }

            if (!newEntry)
                return;

            string title = signon.Hostname;

            if (!form.GetTitles)
            {
                try
                {
                    var uri = new Uri(signon.Hostname);
                    title = uri.Host;
                }
                catch (UriFormatException ex) // TODO: May need to also catch ArgumentException
                {
                    logger.SetText("The URL of the signon could not be parsed.", LogStatusType.Warning);
                }
            }

            /*if (form.GetTitles || form.GetIcons)
            {
                logger.SetText("Scraping website for the title and/or icon.", LogStatusType.AdditionalInfo);
                WebScraper.ScrapeAsync(signon.Hostname, form.GetTitles, form.GetIcons);

                if (!string.IsNullOrWhiteSpace(title))
                {
                    entry.Strings.Set(
                        PwDefs.TitleField,
                        new ProtectedString(db.MemoryProtection.ProtectTitle, title)
                    );
                }

                if (iconData != null)
                {
                    var icon = new PwCustomIcon(new PwUuid(true), iconData);
                    db.CustomIcons.Add(icon);
                    entry.CustomIconUuid = icon.Uuid;
                }
            }*/

            // Set all fields.
            entry.Strings.Set(
                PwDefs.TitleField,
                new ProtectedString(db.MemoryProtection.ProtectTitle, title)
            );
            entry.Strings.Set(
                PwDefs.UserNameField,
                new ProtectedString(db.MemoryProtection.ProtectUserName, signon.Username)
            );
            entry.Strings.Set
                (PwDefs.UrlField,
                new ProtectedString(db.MemoryProtection.ProtectUrl, signon.Hostname)
            );

            if (form.IncludeNotes)
            {
                entry.Strings.Set(
                    PwDefs.NotesField,
                    new ProtectedString(db.MemoryProtection.ProtectNotes, Note));
            }

            entry.Expires = false;
            entry.IconId = form.EntryIcon;
            entry.CreationTime = signon.TimeCreated ?? entry.CreationTime;
            entry.LastAccessTime = signon.TimeLastUsed ?? entry.LastAccessTime;
            entry.LastModificationTime = signon.TimePasswordChanged ?? entry.LastModificationTime;
            entry.UsageCount = signon.TimesUsed;
        }
    }
}
