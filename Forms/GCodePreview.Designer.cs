namespace GrblHeightProbe2
{
	partial class GCodePreview
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labelSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelFill = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelFitsHeightMap = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.applyHeightMapAndSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.movePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelSize,
            this.toolStripStatusLabelFill,
            this.labelFitsHeightMap,
            this.labelMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 401);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(646, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labelSize
			// 
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(84, 17);
			this.labelSize.Text = "Size ....x.... mm";
			// 
			// toolStripStatusLabelFill
			// 
			this.toolStripStatusLabelFill.Name = "toolStripStatusLabelFill";
			this.toolStripStatusLabelFill.Size = new System.Drawing.Size(459, 17);
			this.toolStripStatusLabelFill.Spring = true;
			// 
			// labelFitsHeightMap
			// 
			this.labelFitsHeightMap.Name = "labelFitsHeightMap";
			this.labelFitsHeightMap.Size = new System.Drawing.Size(88, 17);
			this.labelFitsHeightMap.Text = "Fits HeightMap";
			// 
			// labelMessage
			// 
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(0, 17);
			this.labelMessage.Click += new System.EventHandler(this.labelMessage_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(646, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.applyHeightMapAndSaveToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// applyHeightMapAndSaveToolStripMenuItem
			// 
			this.applyHeightMapAndSaveToolStripMenuItem.Name = "applyHeightMapAndSaveToolStripMenuItem";
			this.applyHeightMapAndSaveToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.applyHeightMapAndSaveToolStripMenuItem.Text = "Apply HeightMap and Save";
			this.applyHeightMapAndSaveToolStripMenuItem.Click += new System.EventHandler(this.applyHeightMapAndSaveToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movePathToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// movePathToolStripMenuItem
			// 
			this.movePathToolStripMenuItem.Name = "movePathToolStripMenuItem";
			this.movePathToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.movePathToolStripMenuItem.Text = "Move Path";
			this.movePathToolStripMenuItem.Click += new System.EventHandler(this.movePathToolStripMenuItem_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "GCode Files|*.nc;*.tap;*.gcode;*.cnc|All Files|*.*";
			this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(622, 371);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// GCodePreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(646, 423);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "GCodePreview";
			this.Text = "GCodePreview   ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GCodePreview_FormClosing);
			this.ResizeEnd += new System.EventHandler(this.GCodePreview_ResizeEnd);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labelSize;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFill;
		private System.Windows.Forms.ToolStripStatusLabel labelFitsHeightMap;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem applyHeightMapAndSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripStatusLabel labelMessage;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem movePathToolStripMenuItem;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}