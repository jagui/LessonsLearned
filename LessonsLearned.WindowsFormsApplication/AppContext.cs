using System.Windows.Forms;
using StructureMap;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;

namespace LessonsLearned.WindowsFormsApplication
{
    public class AppContext : Caliburn.Micro.ApplicationContext
    {

        private IContainer Container { get; set; }

        public AppContext(IContainer container)
            : base(GetMainForm(container))
        {
            Container = container;
        }

        private static Form GetMainForm(IContainer container)
        {
            var mainForm = new WorkflowChooserView();
            container.Inject<IWorkflowChooserView>(mainForm);
            var presenter = container.GetInstance<WorkflowChooserPresenter>();
            presenter.Run();
            return mainForm;
        }

    }
}