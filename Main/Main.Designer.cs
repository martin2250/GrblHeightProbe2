namespace GrblHeightProbe2
{
    partial class Main
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
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newHeightMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openHeightMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveHeightMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.openPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closePortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manualConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.applyToFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonPause = new System.Windows.Forms.ToolStripButton();
			this.testremoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialogHMap = new System.Windows.Forms.OpenFileDialog();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.openFileDialogGCode = new System.Windows.Forms.OpenFileDialog();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripMain.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStripMain
			// 
			this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.connectionToolStripMenuItem1,
            this.gCodeToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(431, 24);
			this.menuStripMain.TabIndex = 0;
			this.menuStripMain.Text = "menuStripMain";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newHeightMapToolStripMenuItem,
            this.openHeightMapToolStripMenuItem,
            this.saveHeightMapToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
			this.fileToolStripMenuItem.Text = "Height Map";
			// 
			// newHeightMapToolStripMenuItem
			// 
			this.newHeightMapToolStripMenuItem.Name = "newHeightMapToolStripMenuItem";
			this.newHeightMapToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.newHeightMapToolStripMenuItem.Text = "New";
			this.newHeightMapToolStripMenuItem.Click += new System.EventHandler(this.newHeightMapToolStripMenuItem_Click);
			// 
			// openHeightMapToolStripMenuItem
			// 
			this.openHeightMapToolStripMenuItem.Name = "openHeightMapToolStripMenuItem";
			this.openHeightMapToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openHeightMapToolStripMenuItem.Text = "Open";
			this.openHeightMapToolStripMenuItem.Click += new System.EventHandler(this.openHeightMapToolStripMenuItem_Click);
			// 
			// saveHeightMapToolStripMenuItem
			// 
			this.saveHeightMapToolStripMenuItem.Name = "saveHeightMapToolStripMenuItem";
			this.saveHeightMapToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveHeightMapToolStripMenuItem.Text = "Save";
			this.saveHeightMapToolStripMenuItem.Click += new System.EventHandler(this.saveHeightMapToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.resetToDefaultsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// generalToolStripMenuItem
			// 
			this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
			this.generalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.generalToolStripMenuItem.Text = "Change Settings";
			this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
			// 
			// resetToDefaultsToolStripMenuItem
			// 
			this.resetToDefaultsToolStripMenuItem.Name = "resetToDefaultsToolStripMenuItem";
			this.resetToDefaultsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.resetToDefaultsToolStripMenuItem.Text = "Reset to Defaults";
			this.resetToDefaultsToolStripMenuItem.Click += new System.EventHandler(this.resetToDefaultsToolStripMenuItem_Click);
			// 
			// connectionToolStripMenuItem1
			// 
			this.connectionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPortToolStripMenuItem,
            this.closePortToolStripMenuItem,
            this.manualConsoleToolStripMenuItem});
			this.connectionToolStripMenuItem1.Name = "connectionToolStripMenuItem1";
			this.connectionToolStripMenuItem1.Size = new System.Drawing.Size(81, 20);
			this.connectionToolStripMenuItem1.Text = "Connection";
			this.connectionToolStripMenuItem1.DropDownOpening += new System.EventHandler(this.connectionToolStripMenuItem1_DropDownOpening);
			// 
			// openPortToolStripMenuItem
			// 
			this.openPortToolStripMenuItem.Name = "openPortToolStripMenuItem";
			this.openPortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.openPortToolStripMenuItem.Text = "Open";
			this.openPortToolStripMenuItem.DropDownOpening += new System.EventHandler(this.openPortToolStripMenuItem_Click);
			this.openPortToolStripMenuItem.Click += new System.EventHandler(this.openPortToolStripMenuItem_Click);
			// 
			// closePortToolStripMenuItem
			// 
			this.closePortToolStripMenuItem.Name = "closePortToolStripMenuItem";
			this.closePortToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.closePortToolStripMenuItem.Text = "Close";
			this.closePortToolStripMenuItem.Click += new System.EventHandler(this.closePortToolStripMenuItem_Click);
			// 
			// manualConsoleToolStripMenuItem
			// 
			this.manualConsoleToolStripMenuItem.Name = "manualConsoleToolStripMenuItem";
			this.manualConsoleToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.manualConsoleToolStripMenuItem.Text = "Manual Console";
			this.manualConsoleToolStripMenuItem.Click += new System.EventHandler(this.manualConsoleToolStripMenuItem_Click);
			// 
			// gCodeToolStripMenuItem
			// 
			this.gCodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyToFilesToolStripMenuItem});
			this.gCodeToolStripMenuItem.Name = "gCodeToolStripMenuItem";
			this.gCodeToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.gCodeToolStripMenuItem.Text = "GCode";
			this.gCodeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.gCodeToolStripMenuItem_DropDownOpening);
			// 
			// applyToFilesToolStripMenuItem
			// 
			this.applyToFilesToolStripMenuItem.Name = "applyToFilesToolStripMenuItem";
			this.applyToFilesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.applyToFilesToolStripMenuItem.Text = "Apply to Files";
			this.applyToFilesToolStripMenuItem.Click += new System.EventHandler(this.applyToFilesToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonPause});
			this.toolStrip1.Location = new System.Drawing.Point(339, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(213, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonStart
			// 
			this.toolStripButtonStart.Enabled = false;
			this.toolStripButtonStart.Image = global::GrblHeightProbe2.Properties.Resources.play124;
			this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonStart.Name = "toolStripButtonStart";
			this.toolStripButtonStart.Size = new System.Drawing.Size(143, 22);
			this.toolStripButtonStart.Text = "Start/Resume Probing";
			this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
			// 
			// toolStripButtonPause
			// 
			this.toolStripButtonPause.Enabled = false;
			this.toolStripButtonPause.Image = global::GrblHeightProbe2.Properties.Resources.pause52;
			this.toolStripButtonPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonPause.Name = "toolStripButtonPause";
			this.toolStripButtonPause.Size = new System.Drawing.Size(58, 22);
			this.toolStripButtonPause.Text = "Pause";
			this.toolStripButtonPause.Click += new System.EventHandler(this.toolStripButtonPause_Click);
			// 
			// testremoveToolStripMenuItem
			// 
			this.testremoveToolStripMenuItem.Name = "testremoveToolStripMenuItem";
			this.testremoveToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.testremoveToolStripMenuItem.Text = "test_remove";
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.removeToolStripMenuItem.Text = "remove";
			// 
			// removeToolStripMenuItem1
			// 
			this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
			this.removeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.removeToolStripMenuItem1.Text = "remove";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "hmap";
			this.saveFileDialog.Filter = "Height Maps|*.hmap|All Files|*.*";
			this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
			// 
			// openFileDialogHMap
			// 
			this.openFileDialogHMap.DefaultExt = "hmap";
			this.openFileDialogHMap.Filter = "Height Maps|*.hmap|All Files|*.*";
			this.openFileDialogHMap.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
			// 
			// pictureBoxPreview
			// 
			this.pictureBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxPreview.Location = new System.Drawing.Point(12, 28);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(795, 467);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPreview.TabIndex = 1;
			this.pictureBoxPreview.TabStop = false;
			// 
			// openFileDialogGCode
			// 
			this.openFileDialogGCode.Filter = "GCode Files|*.nc;*.tap;*.gcode;*.cnc|All Files|*.*";
			this.openFileDialogGCode.Multiselect = true;
			this.openFileDialogGCode.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogGCode_FileOk);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 507);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.pictureBoxPreview);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "Main";
			this.Text = "GRBL Height Probe 2 by martin2250";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHeightMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHeightMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveHeightMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closePortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem manualConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testremoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogHMap;
		private System.Windows.Forms.ToolStripButton toolStripButtonStart;
		private System.Windows.Forms.ToolStripButton toolStripButtonPause;
		private System.Windows.Forms.ToolStripMenuItem gCodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem applyToFilesToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialogGCode;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

