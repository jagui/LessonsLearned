using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonEnrolment.Commands
{
    public class EnrolPersonCommand
    {
        private readonly EnrolPersonFormDto _enrolPersonFormDto;

        public EnrolPersonCommand(EnrolPersonFormDto enrolPersonFormDto)
        {
            _enrolPersonFormDto = enrolPersonFormDto;
        }

        public EnrolPersonFormDto EnrolPersonFormDto
        {
            get { return _enrolPersonFormDto; }
        }
    }
}