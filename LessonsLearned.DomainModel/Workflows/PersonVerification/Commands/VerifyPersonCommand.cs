using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Commands
{
    public class VerifyPersonCommand
    {
        private readonly PersonSummaryDto _personSummaryDto;
        private readonly string _comment;
        public VerifyPersonCommand(PersonSummaryDto personSummaryDto, string comment)
        {
            _personSummaryDto = personSummaryDto;
            _comment = comment;
        }

        public PersonSummaryDto PersonSummaryDto
        {
            get { return _personSummaryDto; }
        }

        public string Comment
        {
            get { return _comment; }
        }
    }
}