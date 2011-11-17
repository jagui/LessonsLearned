using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class VerificationWorkflowPresenter : ICommand<StartWorkflowCommand>, ICommand<StartVerificationWorkflowCommand>, IEventHandler<PersonVerifiedEvent>, IHost
    {
        private readonly IApplicationController _applicationController;
        private readonly IVerificationWorkflowView _view;

        public VerificationWorkflowPresenter(IApplicationController applicationController, IVerificationWorkflowView view)
        {
            _applicationController = applicationController;
            _applicationController.SetHost(this);
            _view = view;
            _view.Presenter = this;
        }

        public void Start()
        {
            _applicationController.Execute(new StartSearchCommand());
        }

        public void Handle(PersonVerifiedEvent eventData)
        {
            _view.SetLastVerificationState(eventData.Valid);
        }

        public void ShowInHost(IView view)
        {
            _view.ShowInHost(view);
        }

        public void Execute(StartVerificationWorkflowCommand commandData)
        {
            _view.SetLastVerificationState(null);
            _view.Run();
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
    }
}
