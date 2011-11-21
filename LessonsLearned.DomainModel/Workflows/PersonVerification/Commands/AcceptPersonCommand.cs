using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Commands
{
    public class AcceptOrRejectPersonCommand
    {
        private readonly PersonSummaryDto _personSummaryDto;
        private readonly string _comment;
        protected AcceptOrRejectPersonCommand(PersonSummaryDto personSummaryDto, string comment)
        {
            _personSummaryDto = personSummaryDto;
            _comment = comment;
        }

        public long Id
        {
            get { return _personSummaryDto.Id; }
        }

        public string Comment
        {
            get { return _comment; }
        }
    }

    public class RejectPersonCommand : AcceptOrRejectPersonCommand
    {
        public RejectPersonCommand(PersonSummaryDto personSummaryDto, string comment)
            : base(personSummaryDto, comment)
        {
        }
    }

    public class AcceptPersonCommand : AcceptOrRejectPersonCommand
    {
        public AcceptPersonCommand(PersonSummaryDto personSummaryDto, string comment)
            : base(personSummaryDto, comment)
        {
        }
    }
}