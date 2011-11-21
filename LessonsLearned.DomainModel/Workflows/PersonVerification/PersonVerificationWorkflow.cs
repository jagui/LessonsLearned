using System;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Activities;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification
{
    public class PersonVerificationWorkflow :
        ICommand<SearchPersonCommand>,
        IEventHandler<PersonSelectedEvent>,
        ICommand<AcceptPersonCommand>,
        ICommand<RejectPersonCommand>
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly SearchPersonActivity _personSearchActivity;
        private readonly SearchPersonDetailsActivity _searchPersonDetailsActivity;
        private readonly VerifyPersonActivity _verifyPersonActivity;


        public PersonVerificationWorkflow(IEventPublisher eventPublisher,
            SearchPersonActivity personSearchActivity,
            SearchPersonDetailsActivity searchPersonDetailsActivity, VerifyPersonActivity verifyPersonActivity)
        {
            _eventPublisher = eventPublisher;
            _personSearchActivity = personSearchActivity;
            _searchPersonDetailsActivity = searchPersonDetailsActivity;
            _verifyPersonActivity = verifyPersonActivity;
        }


        public void Execute(SearchPersonCommand commandData)
        {
            _personSearchActivity.Finished += PersonSearchActivityFinished;
            _personSearchActivity.Start(commandData.PersonSummaryDto);
        }
        private void PersonSearchActivityFinished(object sender, ActivityFinishedEventArgs<CandidatesDto> e)
        {
            _personSearchActivity.Finished -= PersonSearchActivityFinished;
            _eventPublisher.Publish(new CandidatesFoundEvent(e.Output));
        }

        public void Handle(PersonSelectedEvent eventData)
        {
            _searchPersonDetailsActivity.Finished += SearchPersonDetailsActivity_Finished;
            _searchPersonDetailsActivity.Start(eventData.SelectedPersonSummary);
        }

        void SearchPersonDetailsActivity_Finished(object sender, ActivityFinishedEventArgs<PersonDetailsDto> e)
        {
            _searchPersonDetailsActivity.Finished -= SearchPersonDetailsActivity_Finished;
            _eventPublisher.Publish(new PersonDetailsFoundEvent(e.Output));
        }



        public void Execute(AcceptPersonCommand commandData)
        {
            Execute((AcceptOrRejectPersonCommand) commandData);
        }

        public void Execute(RejectPersonCommand commandData)
        {
            Execute((AcceptOrRejectPersonCommand)commandData);
        }

        private void Execute(AcceptOrRejectPersonCommand commandData)
        {
            _verifyPersonActivity.Finished += VerifyPersonActivity_Finished;
            _verifyPersonActivity.Start(commandData);
        }

        private void VerifyPersonActivity_Finished(object sender, ActivityFinishedEventArgs<bool> e)
        {
            _verifyPersonActivity.Finished -= VerifyPersonActivity_Finished;
            _eventPublisher.Publish(new PersonVerifiedEvent(e.Output));
        }
    }
}
