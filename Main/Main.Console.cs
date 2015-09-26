using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		private void GRBL_OnLineReceived_Console(string line)
		{
			Invoke(new Action(() =>
			{
				textBoxConsole.AppendText(line);
				textBoxConsole.AppendText("\n");
			}));
		}

		void GRBL_OnLineSent_Console(string line)
		{
			Invoke(new Action(() =>
			{
				AddTextToConsole(line);
			}));
		}

		private void AddTextToConsole(string text)
		{
			int start = textBoxConsole.Text.Length;
			textBoxConsole.AppendText(text);
			textBoxConsole.AppendText("\n");
			textBoxConsole.Select(start, textBoxConInput.Text.Length + 1);
			textBoxConsole.SelectionAlignment = HorizontalAlignment.Right;

			textBoxConsole.Select(textBoxConsole.Text.Length + 1, 0);
			textBoxConsole.ScrollToCaret();
		}

		private void buttonSendConsole_Click(object sender, EventArgs e)
		{
			AddTextToConsole(textBoxConInput.Text);

			GRBL.Port.WriteLine(textBoxConInput.Text);
			PreviousConsole.Insert(0, textBoxConInput.Text);
			textBoxConInput.Clear();
			ConsoleIndex = -1;
		}

		private List<string> PreviousConsole = new List<string>();
		private int ConsoleIndex = -1;

		private void textBoxConInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonSendConsole_Click(null, null);
				e.Handled = true;
			}

			if (e.KeyCode == Keys.Up)
			{
				if (ConsoleIndex + 1 < PreviousConsole.Count)
				{
					ConsoleIndex++;
					textBoxConInput.Text = PreviousConsole[ConsoleIndex];
					textBoxConInput.SelectionStart = textBoxConInput.Text.Length + 1;
				}

				e.Handled = true;
			}

			if (e.KeyCode == Keys.Down)
			{
				if (ConsoleIndex >= 0)
				{
					ConsoleIndex--;

					if (ConsoleIndex < 0)
					{
						textBoxConInput.Clear();
					}
					else
					{
						textBoxConInput.Text = PreviousConsole[ConsoleIndex];
						textBoxConInput.SelectionStart = textBoxConInput.Text.Length + 1;
					}
				}

				e.Handled = true;
			}
		}
	}
}
