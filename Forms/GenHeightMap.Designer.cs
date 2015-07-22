namespace GrblHeightProbe2
{
	partial class GenHeightMap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenHeightMap));
			this.Y = new System.Windows.Forms.NumericUpDown();
			this.X = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.pY = new System.Windows.Forms.NumericUpDown();
			this.pX = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxExpression = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.numericUpDownGrid = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// Y
			// 
			this.Y.DecimalPlaces = 3;
			this.Y.Location = new System.Drawing.Point(34, 57);
			this.Y.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.Y.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.Y.Name = "Y";
			this.Y.Size = new System.Drawing.Size(59, 20);
			this.Y.TabIndex = 8;
			// 
			// X
			// 
			this.X.DecimalPlaces = 3;
			this.X.Location = new System.Drawing.Point(34, 31);
			this.X.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.X.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.X.Name = "X";
			this.X.Size = new System.Drawing.Size(59, 20);
			this.X.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Y";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "X";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(74, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Offset";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(188, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Points";
			// 
			// pY
			// 
			this.pY.Location = new System.Drawing.Point(148, 57);
			this.pY.Name = "pY";
			this.pY.Size = new System.Drawing.Size(75, 20);
			this.pY.TabIndex = 13;
			this.pY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// pX
			// 
			this.pX.Location = new System.Drawing.Point(148, 31);
			this.pX.Name = "pX";
			this.pX.Size = new System.Drawing.Size(75, 20);
			this.pX.TabIndex = 12;
			this.pX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(128, 59);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(14, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Y";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(128, 33);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "X";
			// 
			// textBoxExpression
			// 
			this.textBoxExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExpression.Location = new System.Drawing.Point(15, 107);
			this.textBoxExpression.Name = "textBoxExpression";
			this.textBoxExpression.Size = new System.Drawing.Size(229, 20);
			this.textBoxExpression.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 91);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Expression";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(15, 133);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(229, 144);
			this.textBox2.TabIndex = 17;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(88, 283);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 18;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(169, 283);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 19;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// numericUpDownGrid
			// 
			this.numericUpDownGrid.DecimalPlaces = 3;
			this.numericUpDownGrid.Location = new System.Drawing.Point(149, 83);
			this.numericUpDownGrid.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
			this.numericUpDownGrid.Name = "numericUpDownGrid";
			this.numericUpDownGrid.Size = new System.Drawing.Size(75, 20);
			this.numericUpDownGrid.TabIndex = 21;
			this.numericUpDownGrid.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(97, 85);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "GridSize";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(230, 85);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(23, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "mm";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(97, 33);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(23, 13);
			this.label10.TabIndex = 23;
			this.label10.Text = "mm";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(97, 59);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(23, 13);
			this.label11.TabIndex = 24;
			this.label11.Text = "mm";
			// 
			// GenHeightMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(256, 314);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.numericUpDownGrid);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBoxExpression);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pY);
			this.Controls.Add(this.pX);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Y);
			this.Controls.Add(this.X);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GenHeightMap";
			this.Text = "Generate HeightMap";
			((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.NumericUpDown Y;
		public System.Windows.Forms.NumericUpDown X;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.NumericUpDown pY;
		public System.Windows.Forms.NumericUpDown pX;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxExpression;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.NumericUpDown numericUpDownGrid;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
	}
}