using System;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class EnrolPersonFormDto
    {
        public String Forename { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}