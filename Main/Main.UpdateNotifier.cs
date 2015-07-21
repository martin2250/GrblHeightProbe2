using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		WebClient UpdateClient = new WebClient();


		private void Main_Load(object sender, EventArgs e)
		{
			if(Set.UpdateNotifier)
			{
				//WTF Github API ?		omitting this, github throws a 403
				UpdateClient.Headers["User-Agent"] = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.15) Gecko/20110303 Firefox/3.6.15";

				UpdateClient.Proxy = null;	//DownloadStringAsync will block if not for this (drastically slower startup)

				UpdateClient.DownloadStringCompleted += UpdateClient_DownloadStringCompleted;
				UpdateClient.DownloadStringAsync(new Uri("https://api.github.com/repos/martin2250/GrblHeightProbe2/releases/latest"));
			}
		}

		Regex versionRegex = new Regex("\"tag_name\":\\s*\"v([0-9\\.]+)\",");
		Regex releaseRegex = new Regex("\"html_url\":\\s*\"([^\"]*)\",");

		void UpdateClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Cancelled || e.Error != null)
			{
				return;
			}

			Match vMatch = versionRegex.Match(e.Result);

			if (!vMatch.Success)
				return;

			Version latest;

			if (!Version.TryParse(vMatch.Groups[1].Value, out latest))
				return;

			Console.WriteLine("Latest available version: {0}", latest);

			if(System.Reflection.Assembly.GetEntryAssembly().GetName().Version < latest)
			{
				Match urlMatch = releaseRegex.Match(e.Result);

				string url = "https://github.com/martin2250/GrblHeightProbe2/releases";

				if (urlMatch.Success)
				{
					url = urlMatch.Groups[1].Value;
				}

				if (MessageBox.Show("There is an update available!\nOpen in browser?", "Update", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
					System.Diagnostics.Process.Start(url);
			}
		}

	}
}
