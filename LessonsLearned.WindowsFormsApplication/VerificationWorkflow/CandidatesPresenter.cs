using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class CandidatesPresenter : IEventHandler<CandidatesFoundEvent>
    {
        private readonly ICandidatesView _view;
        private readonly IApplicationController _applicationController;

        public CandidatesPresenter(ICandidatesView view, IApplicationController applicationController)
        {
            _view = view;
            _view.Presenter = this;
            _applicationController = applicationController;
        }

        public void Handle(CandidatesFoundEvent eventData)
        {
            _applicationController.ShowInHost(_view);
            _view.ShowCandidates(eventData.CandidatesDto);
        }

        internal void Verify(DomainModel.Workflows.PersonVerification.Dtos.PersonSummaryDto personSummaryDto)
        {
            _applicationController.Execute(new VerifyPersonCommand(personSummaryDto, "hola"));
        }
    }
}
