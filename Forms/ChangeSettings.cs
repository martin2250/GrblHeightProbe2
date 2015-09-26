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

		//Settings, format {SettingName, SettingDescription (short), Setting Explanation}
		string[,] Names = new string[,] 
		{
			{"SerialBaudRate",		"Baud Rate",						"The Baud Rate used to communicate with GRBL"},
			{"Safety",				"Safety Height [mm]",				"The height to return to after probing"},
			{"ProbeRetraction",		"Probing Retraction [mm]",			"The height to return after completing a probing cycle and before moving to the next"},
			{"ProbePlunge",			"Probe plunge rate [mm/min]",		"The plunge rate used for probing"},
			{"ProbeDepth",			"Maximum depth [mm]",					"In case the probe pin does not fire, this is the maximum distance travelled (only a safety feature)"},
			{"LogTrafficToFile",	"Log the traffic to a file",		"Log all the traffic to a file for debugging purposes"},
			{"UpdateNotifier",		"Automatically check for update",	"Check for updates in the background (only on program startup)"}
		};

		Type[] Types = new Type[] 
		{
			typeof(int),
			typeof(float),
			typeof(float),
			typeof(float),
			typeof(float),
			typeof(bool),
			typeof(bool)
		};

		List<Control> controlList = new List<Control>();

		const int lineDist = 20;

		public ChangeSettings()
		{
			InitializeComponent();

			for (int i = 0; i < Types.Length; i++)
			{
				if (Types[i] != typeof(bool))
				{
					TextBox tb = new TextBox();
					tb.Text = set[Names[i, 0]].ToString();
					tb.Size = new Size(100, lineDist);
					tb.Location = new Point(185, i * (lineDist + 5) + 20);
					Controls.Add(tb);
					controlList.Add(tb);
					toolTip1.SetToolTip(tb, Names[i, 2]);
				}
				else
				{
					CheckBox cb = new CheckBox();
					cb.Checked = (bool)set[Names[i, 0]];
					cb.Location = new Point(185, i * (lineDist + 5) + 20);
					Controls.Add(cb);
					controlList.Add(cb);
					toolTip1.SetToolTip(cb, Names[i, 2]);
				}

				Label l = new Label();
				l.Text = Names[i, 1];
				l.AutoSize = true;
				l.Location = new Point(180 - TextRenderer.MeasureText(l.Text, new Font(l.Font.FontFamily, l.Font.Size, l.Font.Style)).Width, i * (lineDist + 5) + 20);
				Controls.Add(l);
				toolTip1.SetToolTip(l, Names[i, 2]);
			}


		}

		private void ChangeSettings_Load(object sender, EventArgs e)
		{

		}

		private void buttonAccept_Click(object sender, EventArgs e)
		{
			bool success = true;
			object[] results = new object[Names.Length];

			for (int i = 0; i < Types.Length; i++)
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
				for (int i = 0; i < Types.Length; i++)
				{
					set[Names[i, 0]] = results[i];
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
