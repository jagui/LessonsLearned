using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public interface ICandidatesView : IView<CandidatesPresenter>
    {
        void ShowCandidates(IEnumerable<PersonSummaryDto> candidates);
    }
}
