namespace GrblHeightProbe2
{
	partial class ThreeFloatPicker
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.X = new System.Windows.Forms.NumericUpDown();
			this.Y = new System.Windows.Forms.NumericUpDown();
			this.Z = new System.Windows.Forms.NumericUpDown();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.X)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Y)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Z)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "X";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Z";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Y";
			// 
			// X
			// 
			this.X.DecimalPlaces = 3;
			this.X.Location = new System.Drawing.Point(32, 12);
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
			this.X.Size = new System.Drawing.Size(120, 20);
			this.X.TabIndex = 3;
			// 
			// Y
			// 
			this.Y.DecimalPlaces = 3;
			this.Y.Location = new System.Drawing.Point(32, 38);
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
			this.Y.Size = new System.Drawing.Size(120, 20);
			this.Y.TabIndex = 4;
			// 
			// Z
			// 
			this.Z.DecimalPlaces = 3;
			this.Z.Location = new System.Drawing.Point(32, 64);
			this.Z.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.Z.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.Z.Name = "Z";
			this.Z.Size = new System.Drawing.Size(120, 20);
			this.Z.TabIndex = 5;
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(16, 90);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(55, 23);
			this.buttonOk.TabIndex = 6;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(77, 90);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// ThreeFloatPicker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(163, 122);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.Z);
			this.Controls.Add(this.Y);
			this.Controls.Add(this.X);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ThreeFloatPicker";
			((System.ComponentModel.ISupportInitialize)(this.X)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Y)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Z)).EndInit();
			this.Icon = Properties.Resources.logo;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.NumericUpDown X;
		public System.Windows.Forms.NumericUpDown Y;
		public System.Windows.Forms.NumericUpDown Z;
	}
}