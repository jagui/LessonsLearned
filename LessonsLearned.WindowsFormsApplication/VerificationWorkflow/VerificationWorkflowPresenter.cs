using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class VerificationWorkflowPresenter : ICommand<StartWorkflowCommand>, ICommand<StartVerificationWorkflowCommand>, IHost
    {
        private readonly IApplicationController _applicationController;
        private readonly IVerificationWorkflowView _view;

        public VerificationWorkflowPresenter(IApplicationController applicationController, IVerificationWorkflowView view)
        {
            _applicationController = applicationController;
            _applicationController.SetHost(this);
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
            _view.SetLastVerificationState(eventData.Accepted);
        }

        public void ShowInHost(IView view)
        {
            _view.ShowInHost(view);
        }

        public void Execute(StartVerificationWorkflowCommand commandData)
        {
            _view.Run();
            Start();
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
