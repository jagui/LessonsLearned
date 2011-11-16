using System.Windows.Forms;
using StructureMap;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;

namespace LessonsLearned.WindowsFormsApplication
{
    public class AppContext : ApplicationContext
    {

        private IContainer Container { get; set; }

        public AppContext(IContainer container)
        {
            Container = container;
            MainForm = GetMainForm();
        }

        private Form GetMainForm()
        {
            var mainForm = new VerificationWorkflowForm();
            Container.Inject<IVerificationWorkflowView>(mainForm);
            var presenter = Container.GetInstance<VerificationWorkflowPresenter>();
            presenter.Run();
            return mainForm;
        }

    }
}