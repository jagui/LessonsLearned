using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonEnrolment.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow
{
    public class EnrolmentWorkflowPresenter : ICommand<StartWorkflowCommand>, ICommand<StartEnrolmentWorkflowCommand>
    {
        private readonly IEnrolmentFormView _view;
        private readonly IApplicationController _applicationController;

        public EnrolmentWorkflowPresenter(IEnrolmentFormView view, IApplicationController applicationController)
        {
            _view = view;
            _view.Presenter = this;
            _applicationController = applicationController;
        }


        public void Execute(StartWorkflowCommand commandData)
        {
            if (commandData is StartEnrolmentWorkflowCommand)
                Execute((StartEnrolmentWorkflowCommand)commandData);
        }

        public void Execute(StartEnrolmentWorkflowCommand commandData)
        {
            _view.Run();
        }

        public void Enrol(IEnrolmentFormView enrolmentFormView)
        {
            _applicationController.Execute(CreateEnrolPersonCommand(enrolmentFormView));
            _view.Reset();
        }

        private static EnrolPersonCommand CreateEnrolPersonCommand(IEnrolmentFormView view)
        {
            return new EnrolPersonCommand(
                           new EnrolPersonFormDto
                           {
                               Forename = view.FirstName,
                               Surname = view.LastName,
                               DateOfBirth = view.DateOfBirth
                           });
        }
    }
}
