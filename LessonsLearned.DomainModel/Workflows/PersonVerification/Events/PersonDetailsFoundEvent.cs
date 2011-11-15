using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Events
{
    public class PersonDetailsFoundEvent
    {
        private readonly PersonDetailsDto _personDetailsDto;

        public PersonDetailsFoundEvent(PersonDetailsDto personDetailsDto)
        {
            _personDetailsDto = personDetailsDto;
        }

        public PersonDetailsDto PersonDetailsDto1
        {
            get { return _personDetailsDto; }
        }
    }
}
