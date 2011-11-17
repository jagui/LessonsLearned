namespace LessonsLearned.WindowsFormsApplication
{
    public interface IModalView<TPresenter> : IView<TPresenter>
    {
        void Run();
    }
}