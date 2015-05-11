using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class ConsoleWindow : Form
	{
		public ConsoleWindow()
		{
			InitializeComponent();

			GRBL.OnLineReceived += GRBL_OnLineReceived;
		}

		void GRBL_OnLineReceived(string line)
		{
			Invoke(new Action(()=>
			{
				richTextBox1.AppendText(line);
				richTextBox1.AppendText("\n");
			}));
		}

		private void buttonSend_Click(object sender, EventArgs e)
		{
			int start = richTextBox1.Text.Length;
			richTextBox1.AppendText(textBox.Text);
			richTextBox1.AppendText("\n");
			richTextBox1.Select(start, textBox.Text.Length + 1);
			richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

			GRBL.Port.WriteLine(textBox.Text);
			Previous.Insert(0, textBox.Text);
			textBox.Clear();
			Index = -1;
		}

		private List<string> Previous = new List<string>();
		private int Index = -1;

		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonSend_Click(null, null);
				e.Handled = true;
			}

			if (e.KeyCode == Keys.Up)
			{
				if (Index + 1 < Previous.Count)
				{
					Index++;
					textBox.Text = Previous[Index];
					textBox.SelectionStart = textBox.Text.Length + 1;
				}

				e.Handled = true;
			}

			if (e.KeyCode == Keys.Down)
			{
				if (Index >= 0)
				{
					Index--;

					if (Index < 0)
					{
						textBox.Clear();
					}
					else
					{
						textBox.Text = Previous[Index];
						textBox.SelectionStart = textBox.Text.Length + 1;
					}
				}

				e.Handled = true;
			}
		}

		private void ConsoleWindow_Load(object sender, EventArgs e)
		{
			ActiveControl = textBox;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			GRBL.Port.Write(new byte[]{0x18}, 0, 1);
		}

		private void ConsoleWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			GRBL.OnLineReceived -= GRBL_OnLineReceived;
		}

		private void textBox_Leave(object sender, EventArgs e)
		{
			ActiveControl = textBox;
		}
	}
}
