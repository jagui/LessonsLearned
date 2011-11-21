using System;
using StructureMap;

namespace LessonsLearned.WindowsFormsApplication
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var ioc = new Container();
            var bootStrapper = new BootStrapper(ioc);
            var appcontext = bootStrapper.GetAppContext();

            System.Windows.Forms.Application.Run(appcontext);
        }

    }
}