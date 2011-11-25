using LessonsLearned.Application.Controller;

namespace LessonsLearned.WindowsFormsApplication
{

    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; set; }
        void Run();
    }
}
