using System;
using System.Windows.Forms;
using LessonsLearned.WindowsFormsApplication;
using StructureMap;

namespace SimpleOrgChart
{
	static class Program
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var ioc = new Container();
			var bootStrapper = new BootStrapper(ioc);
			var appcontext = bootStrapper.GetAppContext();

			Application.Run(appcontext);
		}

	}
}