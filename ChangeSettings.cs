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
	public partial class ChangeSettings : Form
	{
		Settings set = Settings.Default;

		string[] Names = new string[] 
		{
			"SerialBaudRate",
			"Safety",
			"ProbePlunge",
			"ProbeDepth"
		};

		Type[] Types = new Type[] 
		{
			typeof(int),
			typeof(float),
			typeof(float),
			typeof(float)
		};

		List<TextBox> boxes = new List<TextBox>();

		public ChangeSettings()
		{
			InitializeComponent();

			for(int i = 0; i < Names.Length; i++)
			{
				TextBox tb = new TextBox();
				tb.Text = set[Names[i]].ToString();
				tb.Size = new Size(100, tb.Size.Height);
				tb.Location = new Point(105, i * (tb.Height + 5) + 20);
				Controls.Add(tb);

				Label l = new Label();
				l.Text = Names[i];
				l.AutoSize = true;
				l.Location = new Point(100 - TextRenderer.MeasureText(l.Text,new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style)).Width, i * (tb.Height + 5) + 20);
				Controls.Add(l);
				boxes.Add(tb);				
			}


		}

		private void ChangeSettings_Load(object sender, EventArgs e)
		{

		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			bool success = true;
			object[] results = new object[Names.Length];

			for(int i = 0; i < Names.Length; i++)
			{
				switch(Types[i].Name)
				{
					case "Int32":
						int x;
						success &= int.TryParse(boxes[i].Text, out x);
						results[i] = x;
						break;
					case "Single":
						float f;
						success &= float.TryParse(boxes[i].Text, out f);
						results[i] = f;
						break;
				}
			}

			if (success)
			{
				for (int i = 0; i < Names.Length; i++)
				{
					set[Names[i]] = results[i];
				}
				set.Save();
				Close();
			}
			else
			{
				MessageBox.Show("Could not parse");
			}
			
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
