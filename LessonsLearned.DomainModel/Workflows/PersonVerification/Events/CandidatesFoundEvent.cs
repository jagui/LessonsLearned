using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Events
{
    public class CandidatesFoundEvent
    {
        private readonly CandidatesDto _candidatesDto;

        public CandidatesFoundEvent(CandidatesDto candidatesDto)
        {
            _candidatesDto = candidatesDto;
        }

        public CandidatesDto CandidatesDto
        {
            get { return _candidatesDto; }
        }
    }
}