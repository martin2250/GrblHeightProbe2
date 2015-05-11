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
			"ProbeDepth",
			"LogTrafficToFile"
		};

		Type[] Types = new Type[] 
		{
			typeof(int),
			typeof(float),
			typeof(float),
			typeof(float),
			typeof(bool)
		};

		List<Control> controlList = new List<Control>();

		const int lineDist = 20;

		public ChangeSettings()
		{
			InitializeComponent();

			for(int i = 0; i < Names.Length; i++)
			{
				if (Types[i] != typeof(bool))
				{
					TextBox tb = new TextBox();
					tb.Text = set[Names[i]].ToString();
					tb.Size = new Size(100, lineDist);
					tb.Location = new Point(105, i * (lineDist + 5) + 20);
					Controls.Add(tb);
					controlList.Add(tb);
				}
				else
				{
					CheckBox cb = new CheckBox();
					cb.Checked = (bool)set[Names[i]];
					cb.Location = new Point(105, i * (lineDist + 5) + 20);
					Controls.Add(cb);
					controlList.Add(cb);
				}

				Label l = new Label();
				l.Text = Names[i];
				l.AutoSize = true;
				l.Location = new Point(100 - TextRenderer.MeasureText(l.Text, new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style)).Width, i * (lineDist + 5) + 20);
				Controls.Add(l);
								
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
						success &= int.TryParse(controlList[i].Text, out x);
						results[i] = x;
						break;
					case "Single":
						float f;
						success &= float.TryParse(controlList[i].Text, out f);
						results[i] = f;
						break;
					case "Boolean":
						results[i] = ((CheckBox)controlList[i]).Checked;
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
