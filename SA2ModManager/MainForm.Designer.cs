﻿namespace SA2ModManager
{
    partial class MainForm
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
			System.Windows.Forms.GroupBox groupBox2;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.closeCheckBox = new System.Windows.Forms.CheckBox();
			this.modDescription = new System.Windows.Forms.Label();
			this.modDownButton = new System.Windows.Forms.Button();
			this.modUpButton = new System.Windows.Forms.Button();
			this.modListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.saveButton = new System.Windows.Forms.Button();
			this.saveAndPlayButton = new System.Windows.Forms.Button();
			this.installButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonNewMod = new System.Windows.Forms.Button();
			this.buttonModsFolder = new System.Windows.Forms.Button();
			this.buttonRefreshModList = new System.Windows.Forms.Button();
			this.codesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			groupBox2.Controls.Add(this.closeCheckBox);
			groupBox2.Location = new System.Drawing.Point(12, 352);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(360, 50);
			groupBox2.TabIndex = 2;
			groupBox2.TabStop = false;
			groupBox2.Text = "Options";
			// 
			// closeCheckBox
			// 
			this.closeCheckBox.AutoSize = true;
			this.closeCheckBox.Location = new System.Drawing.Point(6, 19);
			this.closeCheckBox.Name = "closeCheckBox";
			this.closeCheckBox.Size = new System.Drawing.Size(102, 17);
			this.closeCheckBox.TabIndex = 12;
			this.closeCheckBox.Text = "Exit after launch";
			this.closeCheckBox.UseVisualStyleBackColor = true;
			// 
			// modDescription
			// 
			this.modDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.modDescription.Location = new System.Drawing.Point(6, 281);
			this.modDescription.Name = "modDescription";
			this.modDescription.Size = new System.Drawing.Size(366, 36);
			this.modDescription.TabIndex = 5;
			this.modDescription.Text = "Description: No mod selected.";
			// 
			// modDownButton
			// 
			this.modDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modDownButton.AutoSize = true;
			this.modDownButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.modDownButton.Enabled = false;
			this.modDownButton.Location = new System.Drawing.Point(343, 35);
			this.modDownButton.Name = "modDownButton";
			this.modDownButton.Size = new System.Drawing.Size(29, 23);
			this.modDownButton.TabIndex = 2;
			this.modDownButton.Text = "↓";
			this.modDownButton.UseVisualStyleBackColor = true;
			this.modDownButton.Click += new System.EventHandler(this.modDownButton_Click);
			// 
			// modUpButton
			// 
			this.modUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.modUpButton.AutoSize = true;
			this.modUpButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.modUpButton.Enabled = false;
			this.modUpButton.Location = new System.Drawing.Point(343, 6);
			this.modUpButton.Name = "modUpButton";
			this.modUpButton.Size = new System.Drawing.Size(29, 23);
			this.modUpButton.TabIndex = 1;
			this.modUpButton.Text = "↑";
			this.modUpButton.UseVisualStyleBackColor = true;
			this.modUpButton.Click += new System.EventHandler(this.modUpButton_Click);
			// 
			// modListView
			// 
			this.modListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.modListView.CheckBoxes = true;
			this.modListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.modListView.FullRowSelect = true;
			this.modListView.HideSelection = false;
			this.modListView.Location = new System.Drawing.Point(3, 6);
			this.modListView.MultiSelect = false;
			this.modListView.Name = "modListView";
			this.modListView.Size = new System.Drawing.Size(334, 240);
			this.modListView.TabIndex = 0;
			this.modListView.UseCompatibleStateImageBehavior = false;
			this.modListView.View = System.Windows.Forms.View.Details;
			this.modListView.SelectedIndexChanged += new System.EventHandler(this.modListView_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 154;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Author";
			this.columnHeader2.Width = 120;
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveButton.Location = new System.Drawing.Point(104, 408);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 3;
			this.saveButton.Text = "Save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// saveAndPlayButton
			// 
			this.saveAndPlayButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveAndPlayButton.AutoSize = true;
			this.saveAndPlayButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.saveAndPlayButton.Location = new System.Drawing.Point(12, 408);
			this.saveAndPlayButton.Name = "saveAndPlayButton";
			this.saveAndPlayButton.Size = new System.Drawing.Size(86, 23);
			this.saveAndPlayButton.TabIndex = 4;
			this.saveAndPlayButton.Text = "Save and Play";
			this.saveAndPlayButton.UseVisualStyleBackColor = true;
			this.saveAndPlayButton.Click += new System.EventHandler(this.saveAndPlayButton_Click);
			// 
			// installButton
			// 
			this.installButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.installButton.AutoSize = true;
			this.installButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.installButton.Location = new System.Drawing.Point(185, 408);
			this.installButton.Name = "installButton";
			this.installButton.Size = new System.Drawing.Size(79, 23);
			this.installButton.TabIndex = 5;
			this.installButton.Text = "Enable Mods";
			this.installButton.UseVisualStyleBackColor = true;
			this.installButton.Click += new System.EventHandler(this.installButton_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(386, 346);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.buttonNewMod);
			this.tabPage1.Controls.Add(this.buttonModsFolder);
			this.tabPage1.Controls.Add(this.buttonRefreshModList);
			this.tabPage1.Controls.Add(this.modDescription);
			this.tabPage1.Controls.Add(this.modListView);
			this.tabPage1.Controls.Add(this.modDownButton);
			this.tabPage1.Controls.Add(this.modUpButton);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(378, 320);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Mods";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonNewMod
			// 
			this.buttonNewMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonNewMod.Location = new System.Drawing.Point(269, 252);
			this.buttonNewMod.Name = "buttonNewMod";
			this.buttonNewMod.Size = new System.Drawing.Size(75, 23);
			this.buttonNewMod.TabIndex = 8;
			this.buttonNewMod.Text = "New Mod";
			this.buttonNewMod.UseVisualStyleBackColor = true;
			this.buttonNewMod.Click += new System.EventHandler(this.buttonNewMod_Click);
			// 
			// buttonModsFolder
			// 
			this.buttonModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonModsFolder.Location = new System.Drawing.Point(87, 252);
			this.buttonModsFolder.Name = "buttonModsFolder";
			this.buttonModsFolder.Size = new System.Drawing.Size(105, 23);
			this.buttonModsFolder.TabIndex = 7;
			this.buttonModsFolder.Text = "Open Mods folder";
			this.buttonModsFolder.UseVisualStyleBackColor = true;
			this.buttonModsFolder.Click += new System.EventHandler(this.buttonModsFolder_Click);
			// 
			// buttonRefreshModList
			// 
			this.buttonRefreshModList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonRefreshModList.Location = new System.Drawing.Point(6, 252);
			this.buttonRefreshModList.Name = "buttonRefreshModList";
			this.buttonRefreshModList.Size = new System.Drawing.Size(75, 23);
			this.buttonRefreshModList.TabIndex = 6;
			this.buttonRefreshModList.Text = "Refresh";
			this.buttonRefreshModList.UseVisualStyleBackColor = true;
			this.buttonRefreshModList.Click += new System.EventHandler(this.buttonRefreshModList_Click);
			// 
			// codesCheckedListBox
			// 
			this.codesCheckedListBox.Location = new System.Drawing.Point(0, 0);
			this.codesCheckedListBox.Name = "codesCheckedListBox";
			this.codesCheckedListBox.Size = new System.Drawing.Size(120, 96);
			this.codesCheckedListBox.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 444);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.installButton);
			this.Controls.Add(this.saveAndPlayButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(400, 482);
			this.Name = "MainForm";
			this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Storm 4 Mod Manager";
			this.Load += new System.EventHandler(this.MainForm_Load);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView modListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button modDownButton;
        private System.Windows.Forms.Button modUpButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAndPlayButton;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Label modDescription;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox codesCheckedListBox;
        private System.Windows.Forms.Button buttonModsFolder;
		private System.Windows.Forms.Button buttonRefreshModList;
        private System.Windows.Forms.Button buttonNewMod;
        private System.Windows.Forms.CheckBox closeCheckBox;
    }
}

