using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class CandidatesPresenter : Screen, IEventHandler<CandidatesFoundEvent>
    {
        private readonly ICandidatesView _view;
        private readonly IApplicationController _applicationController;

        public CandidatesPresenter(ICandidatesView view, IApplicationController applicationController)
        {
            _view = view;
            _view.Presenter = this;
            _applicationController = applicationController;
            AttachView(_view,null);
        }

        public void Handle(CandidatesFoundEvent eventData)
        {
            _applicationController.Activate(this);
            _view.ShowCandidates(eventData.CandidatesDto);
        }

        public void EvaluateCandProcess()
        {
            _view.SetCanProcess(_view.SelectedCandidate() != null && !String.IsNullOrEmpty(_view.Comment));
        }

        internal void Verify()
        {

            _applicationController.Execute(new AcceptPersonCommand(_view.SelectedCandidate(), _view.Comment));
        }

        internal void Reject()
        {
            _applicationController.Execute(new RejectPersonCommand(_view.SelectedCandidate(), _view.Comment));
        }
    }
}
