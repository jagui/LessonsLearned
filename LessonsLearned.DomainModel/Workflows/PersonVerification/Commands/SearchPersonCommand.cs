using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Commands
{
    public class SearchPersonCommand
    {
        private readonly PersonSearchFormDto _personSearchFormDto;

        public SearchPersonCommand(PersonSearchFormDto personSearchFormDto)
        {
            _personSearchFormDto = personSearchFormDto;
        }

        public PersonSearchFormDto PersonSummaryDto
        {
            get { return _personSearchFormDto; }
        }
    }
}