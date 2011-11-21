using LessonsLearned.Application.Controller;

namespace LessonsLearned.WindowsFormsApplication
{

    public interface IView<TPresenter> : IView
    {
        TPresenter Presenter { get; set; }
        void Run();
    }
}
