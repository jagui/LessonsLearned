using System;
using System.ComponentModel.DataAnnotations;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class PersonSearchFormDto
    {
        public String Forename { get; set; }
        public String Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}