using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Events
{
    public class PersonSelectedEvent
    {
        private readonly PersonSummaryDto _selectedPersonSummary;

        public PersonSelectedEvent(PersonSummaryDto selectedPersonSummary)
        {
            _selectedPersonSummary = selectedPersonSummary;
        }

        public PersonSummaryDto SelectedPersonSummary
        {
            get { return _selectedPersonSummary; }
        }
    }
}