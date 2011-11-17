using System;
using System.Drawing;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class PersonDetailsDto
    {
        private readonly Person _person;

        internal PersonDetailsDto(Person person)
        {
            _person = person;
        }

        internal long Id
        {
            get { return _person.Id; }
        }

        public string FullName
        {
            get { return String.Format("{0}, {1}", _person.Surename, _person.Forename); }
        }

        public String Comments { get { return _person.Comments; } }

        public override string ToString()
        {
            return String.Format("{0}, {1}: {2}", _person.Surename, _person.Forename, _person.Comments);
        }

        public static readonly PersonDetailsDto NotFound = new NotFoundPersonDetailsDto();

        private class NotFoundPersonDetailsDto : PersonDetailsDto
        {
            public NotFoundPersonDetailsDto() : base(new Person { Comments = "NotFound" }) { }
        }
    }
}