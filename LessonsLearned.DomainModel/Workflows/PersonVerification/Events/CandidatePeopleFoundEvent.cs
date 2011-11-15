using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Events
{
    public class CandidatePeopleFoundEvent
    {
        private readonly CandidatesDto _candidatesDto;

        public CandidatePeopleFoundEvent(CandidatesDto candidatesDto)
        {
            _candidatesDto = candidatesDto;
        }

        public CandidatesDto CandidatesDto1
        {
            get { return _candidatesDto; }
        }
    }
}