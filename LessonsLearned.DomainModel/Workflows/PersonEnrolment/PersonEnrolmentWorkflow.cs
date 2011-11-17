using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonEnrolment.Commands;
using LessonsLearned.DomainModel.Entities;
using Juanagui.Repositories.Common;

namespace LessonsLearned.DomainModel.Workflows.PersonEnrolment
{
    public class PersonEnrolmentWorkflow : ICommand<EnrolPersonCommand>
    {
        private readonly Repository<Person> _repository;

        public PersonEnrolmentWorkflow(Repository<Person> repository)
        {
            _repository = repository;
        }

        public void Execute(EnrolPersonCommand commandData)
        {
            _repository.Add(new Person
            {
                DateOfBirth = commandData.EnrolPersonFormDto.DateOfBirth,
                Forename = commandData.EnrolPersonFormDto.Forename,
                Surname = commandData.EnrolPersonFormDto.Surname
            });
            _repository.PersistAll();
        }
    }
}
