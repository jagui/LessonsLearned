using System.Linq;
using Caliburn.Micro;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{

    public class VerificationWorkflowPresenter : LinearWorkflowConductor, ICommand<StartWorkflowCommand>, ICommand<StartVerificationWorkflowCommand>
    {
        private readonly IApplicationController _applicationController;
        private readonly IVerificationWorkflowView _view;

        public VerificationWorkflowPresenter(IApplicationController applicationController, IVerificationWorkflowView view) : base(view)
        {
            _applicationController = applicationController;
            _applicationController.SetConductor(this);
            _view = view;
            _view.Presenter = this;
            applicationController.Register<PersonVerifiedEvent>(Handle);
        }

        public void Start()
        {
            _applicationController.Execute(new StartSearchCommand());
        }

        private void Handle(PersonVerifiedEvent eventData)
        {
            Start();
        }


        public void Execute(StartVerificationWorkflowCommand commandData)
        {
            _view.Run();
            Start();
        }

        public override void ActivateItem(Screen item)
        {
            base.ActivateItem(item);
            _view.Show(item);
            _view.SetBackEnabled(!GetChildren().First().Equals(item));
        }

        public string Name
        {
            get { return "Verification"; }
        }

        public void Execute(StartWorkflowCommand workflowCommand)
        {
            if (workflowCommand is StartVerificationWorkflowCommand)
                Execute((StartVerificationWorkflowCommand)workflowCommand);
        }

        public void GoBack()
        {
            var children = GetChildren().ToList();
            var index = children.IndexOf(this.ActiveItem);
            var previous = children[index - 1];
            ActivateItem(previous);
        }
    }
}
