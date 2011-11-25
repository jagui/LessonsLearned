using Caliburn.Micro;

namespace LessonsLearned.WindowsFormsApplication
{
    public abstract class LinearWorkflowConductor : Conductor<Screen>.Collection.OneActive
    {
        private readonly IContentView _contentView;
        
        protected LinearWorkflowConductor(IContentView contentView)
        {
            _contentView = contentView;
        }

        protected void Show(Screen screen)
        {
            _contentView.Show(screen);
        }
    }
}