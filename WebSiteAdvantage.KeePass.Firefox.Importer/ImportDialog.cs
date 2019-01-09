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
using System.Diagnostics;
using System.Windows.Forms;

using KeePassLib;

namespace WebSiteAdvantage.KeePass.Firefox.Importer
{
    public partial class ImportDialog : Form
    {
        public ImportDialog()
        {
            InitializeComponent();

            this.comboIcon.SelectedIndex = 16;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public string IconName
        {
            get { return this.comboIcon.SelectedItem.ToString(); }
        }


        public PwGroup Group
        {
            get
            {
                if (this.comboGroup.SelectedItem is KeePassHelper.GroupItem)
                    return ((KeePassHelper.GroupItem)this.comboGroup.SelectedItem).Group;

                return null;
            }
        }

        public string Password
        {
            get { return this.textPassword.Text; }
        }


        public bool GetTitles
        {
            get
            {
                return this.checkInternetTitles.Checked;
            }
        }

        public bool IncludeImportNotes
        {
            get
            {
                return this.checkNotes.Checked;
            }
        }
        public bool AddAutoType
        {
            get
            {
                return this.checkAutoType.Checked;
            }
        }
        public bool Merge
        {
            get
            {
                return this.checkExisting.Checked;
            }
        }
        public bool Overwrite
        {
            get
            {
                return this.checkOverwite.Checked;
            }
        }

        public string ProfilePath
        {
            get
            {
                if (this.comboProfile.SelectedItem == null)
                    return null;
                return ((FirefoxProfileInfo)this.comboProfile.SelectedItem).AbsolutePath;
            }
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=link&utm_campaign=importer-" + KeePassUtilities.Version);
        }

        private void checkBoxTitle_CheckedChanged(object sender, EventArgs e)
        {
//			this.checkBoxAutoType.Enabled = this.checkBoxTitle.Checked;
        }

        private void checkBoxCheckExisting_CheckedChanged(object sender, EventArgs e)
        {
            this.checkOverwite.Enabled = this.checkExisting.Checked;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=importer-" + KeePassUtilities.Version);

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<FirefoxProfileInfo> profiles = FirefoxProfileInfo.FindFirefoxProfileInfos();
            this.comboProfile.DataSource = profiles;
            this.comboProfile.DisplayMember = "Name";

            this.Text = "Web Site Advantage Firefox to KeePass Importer (" + KeePassUtilities.Version + ")";

            foreach (FirefoxProfileInfo profile in profiles)
            {
                if (profile.Default)
                {
                    this.comboProfile.SelectedItem = profile;
                    break;
                }
            }

        }


        public void Initialise(PwDatabase pwStorage)
        {
            KeePassHelper.InitialiseGroupComboBox(this.comboGroup, pwStorage);
        }

        private void buttonFindProfiles_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Yes - If you wish to load profiles via the profiles ini file." + Environment.NewLine +
                "No  - To directly select a profiles folder.",
                "Load Profiles ini file?",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


            if (result == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Title = "Select a Firefox Profiles.ini file";
                openFileDialog1.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                //   openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)this.comboProfile.DataSource;
                    FirefoxProfileInfo.FindFirefoxProfileInfosFromIniFile(openFileDialog1.FileName, list);

                    // get it to refresh!
                    this.comboProfile.DataSource = null;
                    this.comboProfile.DataSource = list;
                }
            }

            if (result == DialogResult.No)
            {
                FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();

                openFolderDialog1.Description = "Select a Firefox Profile folder";
                openFolderDialog1.ShowNewFolderButton = false;


                if (openFolderDialog1.ShowDialog() == DialogResult.OK)
                {

                    List<FirefoxProfileInfo> list = (List<FirefoxProfileInfo>)this.comboProfile.DataSource;
                    FirefoxProfileInfo profile = new FirefoxProfileInfo();

                    profile.Name = openFolderDialog1.SelectedPath.Substring(openFolderDialog1.SelectedPath.LastIndexOf(@"\") + 1);
                    profile.Path = openFolderDialog1.SelectedPath;
                    profile.Default = false;
                    profile.IsRelative = false;

                    list.Add(profile);

                    // get it to refresh!
                    this.comboProfile.DataSource = null;
                    this.comboProfile.DataSource = list;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepassfirefox&utm_medium=application&utm_content=help&utm_campaign=importerdonate-" + KeePassUtilities.Version);

        }

    }
}
