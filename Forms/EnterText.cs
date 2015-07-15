using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class EnterText : Form
	{
		public bool Ok = false;
		public string Result = "";

		public EnterText()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Ok = true;
			Result = textBox1.Text;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
