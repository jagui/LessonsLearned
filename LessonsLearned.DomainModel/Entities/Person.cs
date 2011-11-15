using System;
using System.Drawing;

namespace LessonsLearned.DomainModel.Entities
{
    public class Person
    {
        public long Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Forename { get; set; }
        public String Surename { get; set; }
        public Bitmap Photo { get; set; }
        public String Comments { get; set; }
    }
}
