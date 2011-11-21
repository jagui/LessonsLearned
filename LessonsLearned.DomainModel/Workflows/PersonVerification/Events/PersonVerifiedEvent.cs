using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Events
{
    public class PersonVerifiedEvent
    {
        private readonly bool _accepted;

        public Boolean Accepted
        {
            get { return _accepted; }
        }

        public PersonVerifiedEvent(bool accepted)
        {
            _accepted = accepted;
        }
    }
}
