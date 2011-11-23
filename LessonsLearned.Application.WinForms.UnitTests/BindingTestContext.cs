using System;
using System.Windows.Forms;

namespace LessonsLearned.Application.WinForms.UnitTests
{
    public class BindingTestContext : IDisposable
    {
        private readonly Control _target;

        public BindingTestContext(Control target)
        {
            _target = target;
            _target.BindingContext = new BindingContext();
            _target.CreateControl();
        }

        public void Dispose()
        {
            _target.Dispose();
        }
    }
}