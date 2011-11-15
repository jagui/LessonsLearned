using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.WindowsFormsApplication
{
    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; }
    }
}
