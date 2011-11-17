using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class VerificationWorkflowPresenter : IEventHandler<PersonVerifiedEvent>, IHost
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

        public void Run()
        {
            _view.SetLastVerificationState(null);
        }

        public void Start()
        {

            _applicationController.Execute(new StartWorkflowCommand());
        }

        public void Handle(PersonVerifiedEvent eventData)
        {
            _view.SetLastVerificationState(eventData.Valid);
        }

        public void ShowInHost(IView view)
        {
            _view.ShowInHost(view);
        }
    }
}
