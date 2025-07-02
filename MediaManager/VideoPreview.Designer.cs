namespace MediaManager
{
    partial class VideoPreview
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoPreview));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayList = new System.Windows.Forms.ListBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnName = new System.Windows.Forms.Button();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.txtFileCurrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.optMovie = new System.Windows.Forms.RadioButton();
            this.optShow = new System.Windows.Forms.RadioButton();
            this.txtFileNewName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSeason = new System.Windows.Forms.NumericUpDown();
            this.numEpisode = new System.Windows.Forms.NumericUpDown();
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.btnMoveFile = new System.Windows.Forms.Button();
            this.grpFolder = new System.Windows.Forms.GroupBox();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolderDestination = new System.Windows.Forms.TextBox();
            this.VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).BeginInit();
            this.grpFile.SuspendLayout();
            this.grpFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFolderToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadFolderToolStripMenuItem
            // 
            this.loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            this.loadFolderToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadFolderToolStripMenuItem.Text = "Load Folder";
            this.loadFolderToolStripMenuItem.Click += new System.EventHandler(this.LoadFolderEvent);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutEvent);
            // 
            // PlayList
            // 
            this.PlayList.FormattingEnabled = true;
            this.PlayList.Location = new System.Drawing.Point(478, 27);
            this.PlayList.Name = "PlayList";
            this.PlayList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PlayList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.PlayList.Size = new System.Drawing.Size(423, 251);
            this.PlayList.TabIndex = 2;
            this.PlayList.SelectedIndexChanged += new System.EventHandler(this.PlayListChanged);
            this.PlayList.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(13, 315);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(54, 13);
            this.lblFilename.TabIndex = 3;
            this.lblFilename.Text = "File Name";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(337, 315);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(59, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration: 0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.TimerEvent);
            // 
            // btnName
            // 
            this.btnName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnName.Location = new System.Drawing.Point(215, 110);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(75, 23);
            this.btnName.TabIndex = 5;
            this.btnName.Text = "Rename";
            this.btnName.UseVisualStyleBackColor = true;
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.Location = new System.Drawing.Point(478, 312);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(420, 238);
            this.lstSearchResults.TabIndex = 5;
            this.lstSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSearchResults_MouseDblClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(704, 283);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchString
            // 
            this.txtSearchString.Location = new System.Drawing.Point(478, 286);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(220, 20);
            this.txtSearchString.TabIndex = 3;
            this.txtSearchString.Text = "Movie/TV Show name";
            this.txtSearchString.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearchString_MouseClick);
            // 
            // txtFileCurrName
            // 
            this.txtFileCurrName.Location = new System.Drawing.Point(52, 15);
            this.txtFileCurrName.Name = "txtFileCurrName";
            this.txtFileCurrName.Size = new System.Drawing.Size(387, 20);
            this.txtFileCurrName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFolder.Location = new System.Drawing.Point(52, 45);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(82, 23);
            this.btnSelectFolder.TabIndex = 8;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // optMovie
            // 
            this.optMovie.AutoSize = true;
            this.optMovie.Checked = true;
            this.optMovie.Location = new System.Drawing.Point(6, 13);
            this.optMovie.Name = "optMovie";
            this.optMovie.Size = new System.Drawing.Size(54, 17);
            this.optMovie.TabIndex = 9;
            this.optMovie.TabStop = true;
            this.optMovie.Text = "Movie";
            this.optMovie.UseVisualStyleBackColor = true;
            // 
            // optShow
            // 
            this.optShow.AutoSize = true;
            this.optShow.Location = new System.Drawing.Point(66, 13);
            this.optShow.Name = "optShow";
            this.optShow.Size = new System.Drawing.Size(52, 17);
            this.optShow.TabIndex = 10;
            this.optShow.Text = "Show";
            this.optShow.UseVisualStyleBackColor = true;
            this.optShow.CheckedChanged += new System.EventHandler(this.optShow_CheckedChanged);
            // 
            // txtFileNewName
            // 
            this.txtFileNewName.Location = new System.Drawing.Point(52, 84);
            this.txtFileNewName.Name = "txtFileNewName";
            this.txtFileNewName.Size = new System.Drawing.Size(387, 20);
            this.txtFileNewName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "New";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Season";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(108, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Episode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optMovie);
            this.groupBox1.Controls.Add(this.optShow);
            this.groupBox1.Location = new System.Drawing.Point(52, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 37);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // numSeason
            // 
            this.numSeason.Enabled = false;
            this.numSeason.Location = new System.Drawing.Point(52, 110);
            this.numSeason.Name = "numSeason";
            this.numSeason.Size = new System.Drawing.Size(50, 20);
            this.numSeason.TabIndex = 18;
            // 
            // numEpisode
            // 
            this.numEpisode.Enabled = false;
            this.numEpisode.Location = new System.Drawing.Point(159, 110);
            this.numEpisode.Name = "numEpisode";
            this.numEpisode.Size = new System.Drawing.Size(50, 20);
            this.numEpisode.TabIndex = 19;
            // 
            // grpFile
            // 
            this.grpFile.Controls.Add(this.btnMoveFile);
            this.grpFile.Controls.Add(this.numEpisode);
            this.grpFile.Controls.Add(this.numSeason);
            this.grpFile.Controls.Add(this.groupBox1);
            this.grpFile.Controls.Add(this.label4);
            this.grpFile.Controls.Add(this.label3);
            this.grpFile.Controls.Add(this.label2);
            this.grpFile.Controls.Add(this.txtFileNewName);
            this.grpFile.Controls.Add(this.label1);
            this.grpFile.Controls.Add(this.txtFileCurrName);
            this.grpFile.Controls.Add(this.btnName);
            this.grpFile.Location = new System.Drawing.Point(16, 331);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(445, 142);
            this.grpFile.TabIndex = 20;
            this.grpFile.TabStop = false;
            this.grpFile.Text = "File";
            // 
            // btnMoveFile
            // 
            this.btnMoveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveFile.Location = new System.Drawing.Point(296, 110);
            this.btnMoveFile.Name = "btnMoveFile";
            this.btnMoveFile.Size = new System.Drawing.Size(75, 23);
            this.btnMoveFile.TabIndex = 20;
            this.btnMoveFile.Text = "Move";
            this.btnMoveFile.UseVisualStyleBackColor = true;
            this.btnMoveFile.Click += new System.EventHandler(this.btnMoveFile_Click);
            // 
            // grpFolder
            // 
            this.grpFolder.Controls.Add(this.btnOpenFolder);
            this.grpFolder.Controls.Add(this.btnCreateFolder);
            this.grpFolder.Controls.Add(this.label5);
            this.grpFolder.Controls.Add(this.txtFolderDestination);
            this.grpFolder.Controls.Add(this.btnSelectFolder);
            this.grpFolder.Location = new System.Drawing.Point(16, 479);
            this.grpFolder.Name = "grpFolder";
            this.grpFolder.Size = new System.Drawing.Size(445, 74);
            this.grpFolder.TabIndex = 21;
            this.grpFolder.TabStop = false;
            this.grpFolder.Text = "Folder";
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateFolder.Location = new System.Drawing.Point(140, 45);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(82, 23);
            this.btnCreateFolder.TabIndex = 9;
            this.btnCreateFolder.Text = "Create Folder";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Destination";
            // 
            // txtFolderDestination
            // 
            this.txtFolderDestination.Location = new System.Drawing.Point(71, 19);
            this.txtFolderDestination.Name = "txtFolderDestination";
            this.txtFolderDestination.Size = new System.Drawing.Size(368, 20);
            this.txtFolderDestination.TabIndex = 0;
            // 
            // VideoPlayer
            // 
            this.VideoPlayer.Enabled = true;
            this.VideoPlayer.Location = new System.Drawing.Point(16, 27);
            this.VideoPlayer.Name = "VideoPlayer";
            this.VideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VideoPlayer.OcxState")));
            this.VideoPlayer.Size = new System.Drawing.Size(446, 279);
            this.VideoPlayer.TabIndex = 1;
            this.VideoPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MediaPlayerStateChangeEvent);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFolder.Location = new System.Drawing.Point(228, 45);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(82, 23);
            this.btnOpenFolder.TabIndex = 10;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // VideoPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 560);
            this.Controls.Add(this.grpFolder);
            this.Controls.Add(this.grpFile);
            this.Controls.Add(this.lstSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchString);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.PlayList);
            this.Controls.Add(this.VideoPlayer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VideoPreview";
            this.Text = "Media Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEpisode)).EndInit();
            this.grpFile.ResumeLayout(false);
            this.grpFile.PerformLayout();
            this.grpFolder.ResumeLayout(false);
            this.grpFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
        private System.Windows.Forms.ListBox PlayList;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnName;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.TextBox txtFileCurrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.RadioButton optMovie;
        private System.Windows.Forms.RadioButton optShow;
        private System.Windows.Forms.TextBox txtFileNewName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numSeason;
        private System.Windows.Forms.NumericUpDown numEpisode;
        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.GroupBox grpFolder;
        private System.Windows.Forms.TextBox txtFolderDestination;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnMoveFile;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}

