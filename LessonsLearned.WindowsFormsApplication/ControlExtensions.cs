using System;
using System.Windows.Forms;

namespace LessonsLearned.WindowsFormsApplication
{
    public static class ControlExtensions
    {
        public static void RunInUiThread(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}