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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using KeePassLib;

using WebSiteAdvantage.KeePass.Firefox.Extensions;
using WebSiteAdvantage.KeePass.Firefox.Profiles;

namespace WebSiteAdvantage.KeePass.Firefox.Importer
{
    public partial class ImportDialog : Form
    {
        public static readonly Version Version = Assembly.GetAssembly(typeof(ProfileParser)).GetName().Version;

        public ImportDialog(PwDatabase pwStorage)
        {
            InitializeComponent();
            KeePassHelper.InitialiseGroupComboBox(this.comboGroup, pwStorage);
        }

        #region Properties

        public string ProfilePath => (this.comboProfile.SelectedItem as ProfileInfo)?.AbsolutePath;

        public string Password => this.textPassword.Text;

        public PwGroup Group => (this.comboGroup.SelectedItem as KeePassHelper.GroupItem)?.Group;

        public PwIcon EntryIcon => (PwIcon) Enum.Parse(typeof(PwIcon), (string) this.comboIcon.SelectedItem);

        public bool AddAutoType => this.checkAutoType.Checked;

        public bool IncludeNotes => this.checkNotes.Checked;

        public bool GetTitles => this.checkTitles.Checked;

        public bool GetIcons => this.checkIcons.Checked;

        public bool CheckExisting => this.checkExisting.Checked;

        public bool Overwrite => this.checkOverwite.Checked;

        #endregion

        #region Event Handlers

        private void FormLoadEventHandler(object sender, EventArgs e)
        {
            this.Text = $"Web Site Advantage Firefox to KeePass Importer ({Version})";

            IEnumerable<string> paths = ProfileParser.GetProfilePaths();
            ProfileInfo[] profiles = ProfileParser.GetProfiles(paths).SkipExceptions().ToArray();

            this.comboProfile.DataSource = new ObservableCollection<ProfileInfo>(profiles);
            this.comboProfile.DisplayMember = "Name";
            this.comboProfile.SelectedItem = ProfileParser.GetPrimaryProfile(profiles);

            string[] iconNames = Enum.GetNames(typeof(PwIcon));
            this.comboIcon.DataSource = iconNames.Take(iconNames.Length - 1); // Last item is an undesirable virtual identifier
            this.comboIcon.SelectedIndex = 16;
        }

        private void IconsCheckedEventHandler(object sender, EventArgs e)
        {
            this.comboIcon.Enabled = !this.comboIcon.Enabled; // Toggle the icon ComboBox
        }

        private void ExistingCheckedEventHandler(object sender, EventArgs e)
        {
            this.checkOverwite.Enabled = this.checkExisting.Checked;
        }

        private void LoadProfilesClickedEventHandler(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Should profiles be loaded using the profiles.ini file? " +
                "If not, the path to the profile directory will need to be specified.",
                "Load Profiles",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1
            );

            if (result == DialogResult.Yes)
            {
                var dialog = new OpenFileDialog
                {
                    Title = "Select a Firefox profiles.ini file",
                    Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*",
                    FilterIndex = 1
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var profiles = (ObservableCollection<ProfileInfo>) this.comboProfile.DataSource;

                    foreach (ProfileInfo profile in ProfileParser.GetProfiles(dialog.FileNames).SkipExceptions())
                    {
                        profiles.Add(profile);
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                var dialog = new FolderBrowserDialog
                {
                    Description = "Select a Firefox Profile folder",
                    ShowNewFolderButton = false
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var profiles = (ObservableCollection<ProfileInfo>) this.comboProfile.DataSource;
                    string dirName = new DirectoryInfo(dialog.SelectedPath).Name;
                    var profile = new ProfileInfo
                    {
                        Name = dirName.Substring(dirName.IndexOf('.') + 1),
                        Path = dialog.SelectedPath,
                        Default = false,
                        IsRelative = false
                    };

                    profiles.Add(profile);
                    this.comboProfile.SelectedItem = profile;
                }
            }
        }

        private void LinkClickedEventHandler(object sender, EventArgs e)
        {
            var control = sender as Control;

            Process.Start(control?.Tag.ToString() + Version);
        }

        #endregion
    }
}
