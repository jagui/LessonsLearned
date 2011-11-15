using System;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class PersonSummaryDto
    {
        private readonly Person _person;

        internal PersonSummaryDto(Person person)
        {
            _person = person;
        }

        internal long Id
        {
            get { return _person.Id; }
        }

        public string FullName
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", _person.Surename, _person.Forename);
        }
    }
}