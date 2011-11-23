using System;
using System.ComponentModel.DataAnnotations;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class PersonSearchFormDto
    {
        [Required]
        public String Forename { get; set; }
        [Required]
        public String Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}