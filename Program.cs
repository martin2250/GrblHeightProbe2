using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	static class Program
	{

		[STAThread] static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			GRBL.OnLineReceived += delegate(string line) 
			{ 
				Console.WriteLine(line);
				if (Settings.Default.LogTrafficToFile)
					System.IO.File.AppendAllText("trafficLog.txt", line + "\n");
			};



			Application.Run(new Main());
		}
	}
}
