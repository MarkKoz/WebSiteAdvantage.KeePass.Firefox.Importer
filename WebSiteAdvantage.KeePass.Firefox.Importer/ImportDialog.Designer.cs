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

namespace WebSiteAdvantage.KeePass.Firefox.Importer
{
    partial class ImportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportDialog));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.pageSettings = new System.Windows.Forms.TabPage();
            this.groupMerging = new System.Windows.Forms.GroupBox();
            this.checkOverwite = new System.Windows.Forms.CheckBox();
            this.checkExisting = new System.Windows.Forms.CheckBox();
            this.groupInternet = new System.Windows.Forms.GroupBox();
            this.checkInternetTitles = new System.Windows.Forms.CheckBox();
            this.groupWarning = new System.Windows.Forms.GroupBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.groupFirefox = new System.Windows.Forms.GroupBox();
            this.buttonLoadProfiles = new System.Windows.Forms.Button();
            this.comboProfile = new System.Windows.Forms.ComboBox();
            this.labelProfile = new System.Windows.Forms.Label();
            this.pictureFirefox = new System.Windows.Forms.PictureBox();
            this.labelPasswordCaption = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.groupKeePass = new System.Windows.Forms.GroupBox();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.checkNotes = new System.Windows.Forms.CheckBox();
            this.checkAutoType = new System.Windows.Forms.CheckBox();
            this.pictureKeePass = new System.Windows.Forms.PictureBox();
            this.comboIcon = new System.Windows.Forms.ComboBox();
            this.labelIcon = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.linkHome = new System.Windows.Forms.LinkLabel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.listBackground = new System.Windows.Forms.ListBox();
            this.buttonBeer = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.pageSettings.SuspendLayout();
            this.groupMerging.SuspendLayout();
            this.groupInternet.SuspendLayout();
            this.groupWarning.SuspendLayout();
            this.groupFirefox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFirefox)).BeginInit();
            this.groupKeePass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKeePass)).BeginInit();
            this.SuspendLayout();
            //
            // buttonCancel
            //
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(459, 535);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            //
            // tabSettings
            //
            this.tabSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSettings.Controls.Add(this.pageSettings);
            this.tabSettings.Location = new System.Drawing.Point(12, 87);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(512, 442);
            this.tabSettings.TabIndex = 21;
            //
            // pageSettings
            //
            this.pageSettings.Controls.Add(this.groupMerging);
            this.pageSettings.Controls.Add(this.groupInternet);
            this.pageSettings.Controls.Add(this.groupFirefox);
            this.pageSettings.Controls.Add(this.groupKeePass);
            this.pageSettings.Location = new System.Drawing.Point(4, 22);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.pageSettings.Size = new System.Drawing.Size(504, 416);
            this.pageSettings.TabIndex = 0;
            this.pageSettings.Text = "Settings";
            this.pageSettings.UseVisualStyleBackColor = true;
            //
            // groupMerging
            //
            this.groupMerging.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMerging.Controls.Add(this.checkOverwite);
            this.groupMerging.Controls.Add(this.checkExisting);
            this.groupMerging.Location = new System.Drawing.Point(3, 336);
            this.groupMerging.Name = "groupMerging";
            this.groupMerging.Size = new System.Drawing.Size(490, 72);
            this.groupMerging.TabIndex = 29;
            this.groupMerging.TabStop = false;
            this.groupMerging.Text = "Merging";
            //
            // checkOverwite
            //
            this.checkOverwite.AutoSize = true;
            this.checkOverwite.Location = new System.Drawing.Point(15, 44);
            this.checkOverwite.Name = "checkOverwite";
            this.checkOverwite.Size = new System.Drawing.Size(236, 17);
            this.checkOverwite.TabIndex = 1;
            this.checkOverwite.Text = "Overwrite passwords (requires above check)";
            this.checkOverwite.UseVisualStyleBackColor = true;
            //
            // checkExisting
            //
            this.checkExisting.AutoSize = true;
            this.checkExisting.Checked = true;
            this.checkExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExisting.Location = new System.Drawing.Point(15, 20);
            this.checkExisting.Name = "checkExisting";
            this.checkExisting.Size = new System.Drawing.Size(144, 17);
            this.checkExisting.TabIndex = 0;
            this.checkExisting.Text = "Check for existing entries";
            this.checkExisting.UseVisualStyleBackColor = true;
            this.checkExisting.CheckedChanged += new System.EventHandler(this.ExistingCheckedEventHandler);
            //
            // groupInternet
            //
            this.groupInternet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInternet.Controls.Add(this.checkInternetTitles);
            this.groupInternet.Controls.Add(this.groupWarning);
            this.groupInternet.Location = new System.Drawing.Point(3, 238);
            this.groupInternet.Name = "groupInternet";
            this.groupInternet.Size = new System.Drawing.Size(490, 92);
            this.groupInternet.TabIndex = 28;
            this.groupInternet.TabStop = false;
            this.groupInternet.Text = "Internet Access";
            //
            // checkInternetTitles
            //
            this.checkInternetTitles.AutoSize = true;
            this.checkInternetTitles.Location = new System.Drawing.Point(15, 19);
            this.checkInternetTitles.Name = "checkInternetTitles";
            this.checkInternetTitles.Size = new System.Drawing.Size(138, 17);
            this.checkInternetTitles.TabIndex = 0;
            this.checkInternetTitles.Text = "Get Titles from websites";
            this.checkInternetTitles.UseVisualStyleBackColor = true;
            this.checkInternetTitles.CheckedChanged += new System.EventHandler(this.InternetTitlesCheckedEventHandler);
            //
            // groupWarning
            //
            this.groupWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupWarning.BackColor = System.Drawing.Color.Transparent;
            this.groupWarning.Controls.Add(this.labelWarning);
            this.groupWarning.ForeColor = System.Drawing.Color.Red;
            this.groupWarning.Location = new System.Drawing.Point(326, 16);
            this.groupWarning.Name = "groupWarning";
            this.groupWarning.Size = new System.Drawing.Size(152, 62);
            this.groupWarning.TabIndex = 23;
            this.groupWarning.TabStop = false;
            this.groupWarning.Text = "Warning";
            //
            // labelWarning
            //
            this.labelWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWarning.ForeColor = System.Drawing.Color.Maroon;
            this.labelWarning.Location = new System.Drawing.Point(3, 16);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(146, 43);
            this.labelWarning.TabIndex = 20;
            this.labelWarning.Text = "You have to trust me if you allow this plugin to access the internet!";
            //
            // groupFirefox
            //
            this.groupFirefox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFirefox.Controls.Add(this.buttonLoadProfiles);
            this.groupFirefox.Controls.Add(this.comboProfile);
            this.groupFirefox.Controls.Add(this.labelProfile);
            this.groupFirefox.Controls.Add(this.pictureFirefox);
            this.groupFirefox.Controls.Add(this.labelPasswordCaption);
            this.groupFirefox.Controls.Add(this.labelPassword);
            this.groupFirefox.Controls.Add(this.textPassword);
            this.groupFirefox.Location = new System.Drawing.Point(3, 6);
            this.groupFirefox.Name = "groupFirefox";
            this.groupFirefox.Size = new System.Drawing.Size(491, 109);
            this.groupFirefox.TabIndex = 27;
            this.groupFirefox.TabStop = false;
            this.groupFirefox.Text = "Firefox";
            //
            // buttonLoadProfiles
            //
            this.buttonLoadProfiles.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.openfolderHS;
            this.buttonLoadProfiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoadProfiles.Location = new System.Drawing.Point(257, 19);
            this.buttonLoadProfiles.Name = "buttonLoadProfiles";
            this.buttonLoadProfiles.Size = new System.Drawing.Size(133, 23);
            this.buttonLoadProfiles.TabIndex = 1;
            this.buttonLoadProfiles.Text = "Load More Profiles...";
            this.buttonLoadProfiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLoadProfiles.UseVisualStyleBackColor = true;
            this.buttonLoadProfiles.Click += new System.EventHandler(this.LoadProfilesClickedEventHandler);
            //
            // comboProfile
            //
            this.comboProfile.FormattingEnabled = true;
            this.comboProfile.Location = new System.Drawing.Point(106, 19);
            this.comboProfile.Name = "comboProfile";
            this.comboProfile.Size = new System.Drawing.Size(145, 21);
            this.comboProfile.TabIndex = 0;
            //
            // labelProfile
            //
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(12, 22);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(36, 13);
            this.labelProfile.TabIndex = 34;
            this.labelProfile.Text = "Profile";
            //
            // pictureFirefox
            //
            this.pictureFirefox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureFirefox.BackColor = System.Drawing.Color.Transparent;
            this.pictureFirefox.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.firefox_128_509;
            this.pictureFirefox.Location = new System.Drawing.Point(396, 14);
            this.pictureFirefox.Name = "pictureFirefox";
            this.pictureFirefox.Size = new System.Drawing.Size(89, 89);
            this.pictureFirefox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureFirefox.TabIndex = 32;
            this.pictureFirefox.TabStop = false;
            //
            // labelPasswordCaption
            //
            this.labelPasswordCaption.AutoSize = true;
            this.labelPasswordCaption.Location = new System.Drawing.Point(104, 69);
            this.labelPasswordCaption.Name = "labelPasswordCaption";
            this.labelPasswordCaption.Size = new System.Drawing.Size(256, 13);
            this.labelPasswordCaption.TabIndex = 25;
            this.labelPasswordCaption.Text = "(required if you have set a master password in firefox)";
            //
            // labelPassword
            //
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(12, 49);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(88, 13);
            this.labelPassword.TabIndex = 22;
            this.labelPassword.Text = "Master Password";
            //
            // textPassword
            //
            this.textPassword.Location = new System.Drawing.Point(106, 46);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(284, 20);
            this.textPassword.TabIndex = 2;
            //
            // groupKeePass
            //
            this.groupKeePass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupKeePass.Controls.Add(this.comboGroup);
            this.groupKeePass.Controls.Add(this.checkNotes);
            this.groupKeePass.Controls.Add(this.checkAutoType);
            this.groupKeePass.Controls.Add(this.pictureKeePass);
            this.groupKeePass.Controls.Add(this.comboIcon);
            this.groupKeePass.Controls.Add(this.labelIcon);
            this.groupKeePass.Controls.Add(this.labelGroup);
            this.groupKeePass.Location = new System.Drawing.Point(3, 121);
            this.groupKeePass.Name = "groupKeePass";
            this.groupKeePass.Size = new System.Drawing.Size(491, 111);
            this.groupKeePass.TabIndex = 26;
            this.groupKeePass.TabStop = false;
            this.groupKeePass.Text = "KeePass";
            //
            // comboGroup
            //
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(107, 14);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(282, 21);
            this.comboGroup.TabIndex = 0;
            //
            // checkNotes
            //
            this.checkNotes.AutoSize = true;
            this.checkNotes.Checked = true;
            this.checkNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNotes.Location = new System.Drawing.Point(153, 88);
            this.checkNotes.Name = "checkNotes";
            this.checkNotes.Size = new System.Drawing.Size(124, 17);
            this.checkNotes.TabIndex = 3;
            this.checkNotes.Text = "Include Import Notes";
            this.checkNotes.UseVisualStyleBackColor = true;
            //
            // checkAutoType
            //
            this.checkAutoType.AutoSize = true;
            this.checkAutoType.Checked = true;
            this.checkAutoType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAutoType.Location = new System.Drawing.Point(16, 88);
            this.checkAutoType.Name = "checkAutoType";
            this.checkAutoType.Size = new System.Drawing.Size(131, 17);
            this.checkAutoType.TabIndex = 2;
            this.checkAutoType.Text = "Add Auto-Type entries";
            this.checkAutoType.UseVisualStyleBackColor = true;
            //
            // pictureKeePass
            //
            this.pictureKeePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureKeePass.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.keepasslogo_512;
            this.pictureKeePass.Location = new System.Drawing.Point(395, 13);
            this.pictureKeePass.Name = "pictureKeePass";
            this.pictureKeePass.Size = new System.Drawing.Size(89, 81);
            this.pictureKeePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureKeePass.TabIndex = 33;
            this.pictureKeePass.TabStop = false;
            //
            // comboIcon
            //
            this.comboIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIcon.FormattingEnabled = true;
            this.comboIcon.Location = new System.Drawing.Point(107, 43);
            this.comboIcon.Name = "comboIcon";
            this.comboIcon.Size = new System.Drawing.Size(121, 21);
            this.comboIcon.TabIndex = 1;
            //
            // labelIcon
            //
            this.labelIcon.AutoSize = true;
            this.labelIcon.Location = new System.Drawing.Point(13, 46);
            this.labelIcon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(28, 13);
            this.labelIcon.TabIndex = 11;
            this.labelIcon.Text = "Icon";
            //
            // labelGroup
            //
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(13, 22);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(36, 13);
            this.labelGroup.TabIndex = 0;
            this.labelGroup.Text = "Group";
            //
            // linkHome
            //
            this.linkHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHome.AutoSize = true;
            this.linkHome.BackColor = System.Drawing.Color.White;
            this.linkHome.Location = new System.Drawing.Point(485, 22);
            this.linkHome.Name = "linkHome";
            this.linkHome.Size = new System.Drawing.Size(35, 13);
            this.linkHome.TabIndex = 26;
            this.linkHome.TabStop = true;
            this.linkHome.Tag = "https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepas" +
    "sfirefox&utm_medium=application&utm_content=link&utm_campaign=importer-";
            this.linkHome.Text = "Home";
            this.linkHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClickedEventHandler);
            //
            // labelDescription
            //
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.BackColor = System.Drawing.SystemColors.Window;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(15, 17);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(496, 54);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "This tool will import passwords stored in Firefox.\r\n";
            //
            // listBackground
            //
            this.listBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBackground.FormattingEnabled = true;
            this.listBackground.Location = new System.Drawing.Point(12, 12);
            this.listBackground.Name = "listBackground";
            this.listBackground.Size = new System.Drawing.Size(511, 69);
            this.listBackground.TabIndex = 2;
            //
            // buttonBeer
            //
            this.buttonBeer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBeer.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.beer3;
            this.buttonBeer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBeer.Location = new System.Drawing.Point(83, 536);
            this.buttonBeer.Name = "buttonBeer";
            this.buttonBeer.Size = new System.Drawing.Size(110, 23);
            this.buttonBeer.TabIndex = 34;
            this.buttonBeer.Tag = "https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepas" +
    "sfirefox&utm_medium=application&utm_content=help&utm_campaign=importerdonate-";
            this.buttonBeer.Text = "Buy me a Beer...";
            this.buttonBeer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBeer.UseVisualStyleBackColor = true;
            this.buttonBeer.Click += new System.EventHandler(this.LinkClickedEventHandler);
            //
            // buttonHelp
            //
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonHelp.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.Help;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(12, 536);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(65, 23);
            this.buttonHelp.TabIndex = 31;
            this.buttonHelp.Tag = "https://websiteadvantage.com.au/Firefox-KeePass-Password-Import#utm_source=keepas" +
    "sfirefox&utm_medium=application&utm_content=help&utm_campaign=importer-";
            this.buttonHelp.Text = "Help...";
            this.buttonHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.LinkClickedEventHandler);
            //
            // buttonStart
            //
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonStart.Image = global::WebSiteAdvantage.KeePass.Firefox.Importer.Properties.Resources.FormRunHS;
            this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStart.Location = new System.Drawing.Point(351, 535);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(103, 24);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            //
            // ImportDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 570);
            this.Controls.Add(this.buttonBeer);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.linkHome);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.listBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(544, 581);
            this.Name = "ImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Site Advantage Firefox to KeePass Importer";
            this.Load += new System.EventHandler(this.FormLoadEventHandler);
            this.tabSettings.ResumeLayout(false);
            this.pageSettings.ResumeLayout(false);
            this.groupMerging.ResumeLayout(false);
            this.groupMerging.PerformLayout();
            this.groupInternet.ResumeLayout(false);
            this.groupInternet.PerformLayout();
            this.groupWarning.ResumeLayout(false);
            this.groupFirefox.ResumeLayout(false);
            this.groupFirefox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFirefox)).EndInit();
            this.groupKeePass.ResumeLayout(false);
            this.groupKeePass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureKeePass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage pageSettings;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.GroupBox groupWarning;
        private System.Windows.Forms.GroupBox groupKeePass;
        private System.Windows.Forms.GroupBox groupInternet;
        private System.Windows.Forms.GroupBox groupFirefox;
        private System.Windows.Forms.GroupBox groupMerging;
        private System.Windows.Forms.CheckBox checkExisting;
        private System.Windows.Forms.CheckBox checkAutoType;
        private System.Windows.Forms.CheckBox checkInternetTitles;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.CheckBox checkOverwite;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.ComboBox comboIcon;
        private System.Windows.Forms.Label labelPasswordCaption;
        private System.Windows.Forms.LinkLabel linkHome;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.ListBox listBackground;
        private System.Windows.Forms.PictureBox pictureFirefox;
        private System.Windows.Forms.PictureBox pictureKeePass;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.ComboBox comboProfile;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Button buttonLoadProfiles;
        private System.Windows.Forms.Button buttonBeer;
        private System.Windows.Forms.CheckBox checkNotes;
        private System.Windows.Forms.ComboBox comboGroup;
    }
}
