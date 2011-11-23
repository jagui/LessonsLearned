using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace LessonsLearned.DomainModel.Entities
{
    public class Person
    {
        public long Id { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        [Required]
        public String Forename { get; set; }
        [Required]
        public String Surname { get; set; }
        [Required]
        public String Comments { get; set; }
        
        public Boolean Accepted { get; set; }
    }
}
