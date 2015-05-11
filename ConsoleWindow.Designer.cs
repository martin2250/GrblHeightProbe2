namespace GrblHeightProbe2
{
    partial class ConsoleWindow
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.buttonSend = new System.Windows.Forms.Button();
			this.textBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(374, 327);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// buttonSend
			// 
			this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSend.Location = new System.Drawing.Point(311, 345);
			this.buttonSend.Name = "buttonSend";
			this.buttonSend.Size = new System.Drawing.Size(75, 23);
			this.buttonSend.TabIndex = 1;
			this.buttonSend.Text = "Send";
			this.buttonSend.UseVisualStyleBackColor = true;
			this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.Location = new System.Drawing.Point(93, 347);
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(212, 20);
			this.textBox.TabIndex = 2;
			this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 344);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Soft Reset";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ConsoleWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 373);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.buttonSend);
			this.Controls.Add(this.richTextBox1);
			this.Name = "ConsoleWindow";
			this.Text = "ConsoleWindow";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleWindow_FormClosing);
			this.Load += new System.EventHandler(this.ConsoleWindow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button buttonSend;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Button button1;
    }
}