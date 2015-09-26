namespace GrblHeightProbe2
{
	partial class NewHeightMap
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
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownPointsX = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPointsY = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownGridSize = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDownOffsetY = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownOffsetX = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxPreviewX = new System.Windows.Forms.TextBox();
			this.textBoxPreviewY = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointsX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointsY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Points:";
			// 
			// numericUpDownPointsX
			// 
			this.numericUpDownPointsX.Location = new System.Drawing.Point(57, 12);
			this.numericUpDownPointsX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownPointsX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPointsX.Name = "numericUpDownPointsX";
			this.numericUpDownPointsX.Size = new System.Drawing.Size(45, 20);
			this.numericUpDownPointsX.TabIndex = 1;
			this.numericUpDownPointsX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPointsX.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// numericUpDownPointsY
			// 
			this.numericUpDownPointsY.Location = new System.Drawing.Point(126, 12);
			this.numericUpDownPointsY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownPointsY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPointsY.Name = "numericUpDownPointsY";
			this.numericUpDownPointsY.Size = new System.Drawing.Size(45, 20);
			this.numericUpDownPointsY.TabIndex = 2;
			this.numericUpDownPointsY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownPointsY.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(108, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "x";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Grid Size:";
			// 
			// numericUpDownGridSize
			// 
			this.numericUpDownGridSize.DecimalPlaces = 1;
			this.numericUpDownGridSize.Location = new System.Drawing.Point(97, 38);
			this.numericUpDownGridSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownGridSize.Name = "numericUpDownGridSize";
			this.numericUpDownGridSize.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownGridSize.TabIndex = 5;
			this.numericUpDownGridSize.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(177, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "mm";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Offset:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(108, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(10, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = ";";
			// 
			// numericUpDownOffsetY
			// 
			this.numericUpDownOffsetY.DecimalPlaces = 1;
			this.numericUpDownOffsetY.Location = new System.Drawing.Point(126, 64);
			this.numericUpDownOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownOffsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDownOffsetY.Name = "numericUpDownOffsetY";
			this.numericUpDownOffsetY.Size = new System.Drawing.Size(45, 20);
			this.numericUpDownOffsetY.TabIndex = 9;
			this.numericUpDownOffsetY.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// numericUpDownOffsetX
			// 
			this.numericUpDownOffsetX.DecimalPlaces = 1;
			this.numericUpDownOffsetX.Location = new System.Drawing.Point(57, 64);
			this.numericUpDownOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownOffsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.numericUpDownOffsetX.Name = "numericUpDownOffsetX";
			this.numericUpDownOffsetX.Size = new System.Drawing.Size(45, 20);
			this.numericUpDownOffsetX.TabIndex = 8;
			this.numericUpDownOffsetX.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(177, 66);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(23, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "mm";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 93);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Dimensions [X]:";
			// 
			// textBoxPreviewX
			// 
			this.textBoxPreviewX.Location = new System.Drawing.Point(97, 90);
			this.textBoxPreviewX.Name = "textBoxPreviewX";
			this.textBoxPreviewX.ReadOnly = true;
			this.textBoxPreviewX.Size = new System.Drawing.Size(103, 20);
			this.textBoxPreviewX.TabIndex = 13;
			// 
			// textBoxPreviewY
			// 
			this.textBoxPreviewY.Location = new System.Drawing.Point(97, 116);
			this.textBoxPreviewY.Name = "textBoxPreviewY";
			this.textBoxPreviewY.ReadOnly = true;
			this.textBoxPreviewY.Size = new System.Drawing.Size(103, 20);
			this.textBoxPreviewY.TabIndex = 15;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(12, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Dimensions [Y]:";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(125, 153);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 16;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(42, 153);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 17;
			this.button2.Text = "Create";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// NewHeightMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(213, 188);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxPreviewY);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxPreviewX);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.numericUpDownOffsetY);
			this.Controls.Add(this.numericUpDownOffsetX);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.numericUpDownGridSize);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownPointsY);
			this.Controls.Add(this.numericUpDownPointsX);
			this.Controls.Add(this.label1);
			this.Name = "NewHeightMap";
			this.Text = "New HeightMap";
			this.Load += new System.EventHandler(this.NewHeightMap_Load);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointsX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointsY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetX)).EndInit();
			this.Icon = Properties.Resources.logo;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownPointsX;
		private System.Windows.Forms.NumericUpDown numericUpDownPointsY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownGridSize;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDownOffsetY;
		private System.Windows.Forms.NumericUpDown numericUpDownOffsetX;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxPreviewX;
		private System.Windows.Forms.TextBox textBoxPreviewY;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}