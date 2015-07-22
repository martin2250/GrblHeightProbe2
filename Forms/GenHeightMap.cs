using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class GenHeightMap : Form
	{
		public HeightMap Map;

		public GenHeightMap()
		{
			InitializeComponent();
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			string code =
@"using System;

namespace expNS{
	public static class expCL{
		public static double Value(double x, double y)
		{
			return {0};
		}
	}
}".Replace("{0}", textBoxExpression.Text);

			CSharpCodeProvider provider = new CSharpCodeProvider();
			CompilerParameters parameters = new CompilerParameters();

			parameters.GenerateInMemory = true;
			parameters.GenerateExecutable = false;

			CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);

			if (results.Errors.HasErrors)
			{
				StringBuilder sb = new StringBuilder();

				foreach (CompilerError error in results.Errors)
				{
					sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
				}

				MessageBox.Show(sb.ToString());
				return;
			}

			Assembly assembly = results.CompiledAssembly;
			Type cl = assembly.GetType("expNS.expCL");
			MethodInfo Value = cl.GetMethod("Value");

			Map = new HeightMap((int)pX.Value, (int)pY.Value, (float)numericUpDownGrid.Value, (float)X.Value, (float)Y.Value);

			while (Map.NotProbed.Any())
			{
				Point p = Map.NotProbed.Dequeue();
				PointF c = Map.GetCoordinates(p);
				try
				{
					object result = Value.Invoke(null, new object[]{(double)c.X, (double)c.Y});
					Map[p.X, p.Y] = Convert.ToSingle(result);
				}
				catch(Exception ex)
				{
					Console.WriteLine("Runtime Error: " + ex.Message);
					return;
				}
			}

			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
