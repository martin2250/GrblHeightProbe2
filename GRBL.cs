using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	static class GRBL
	{
		public static SerialPort Port { get; set; }
		public static bool ProbingRunning { get; set; }

		public delegate void LineReceivedHandler(string line);
		public static event LineReceivedHandler OnLineReceived;

		public static bool Connected
		{
			get
			{
				if (Port == null)
					return false;
				return Port.IsOpen;
			}
		}

		public static void SendLine(string line)
		{
			Port.WriteLine(line);

			Console.WriteLine(">{0}", line);

			if (Settings.Default.LogTrafficToFile)
				System.IO.File.AppendAllText("trafficLog.txt", ">" + line + "\n");
		}

		public static void Close()
		{
			Port.Close();
			Port.Dispose();
			Port = null;
		}

		static char[] Line = new char[128];
		static int Index = 0;

		public static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			while(Port.IsOpen && Port.BytesToRead > 0)
			{
				int i = Port.ReadByte();
				if (i != '\r')
				{
					if (i != '\n')
					{
						Line[Index++] = (char)i;
					}
				}
				else
				{
					string line = new string(Line, 0, Index);

					foreach (GRBL.LineReceivedHandler d in OnLineReceived.GetInvocationList())
					{
						d.Invoke(line);
					}

					Index = 0;
				}
					
			}
		}




	}
}
