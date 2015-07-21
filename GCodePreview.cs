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
	public partial class GCodePreview : Form
	{
		public GCodeCommand[] Commands;

		public GCodePreview(IEnumerable<GCodeCommand> commands)
		{
			Commands = commands.ToArray();
			InitializeComponent();
		}
	}
}
