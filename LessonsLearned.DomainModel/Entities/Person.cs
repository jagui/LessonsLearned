using System;
using System.Drawing;

namespace LessonsLearned.DomainModel.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public String Comments { get; set; }
    }
}
