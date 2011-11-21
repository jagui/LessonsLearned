using System;
using System.Linq;
using Juanagui.Repositories.Common;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Entities;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using System.Threading.Tasks;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Activities
{
    public class VerifyPersonActivity : Activity<AcceptOrRejectPersonCommand, Boolean>
    {
        private readonly Repository<Person> _repository;

        public VerifyPersonActivity(Repository<Person> repository)
        {
            _repository = repository;
        }

        public override void Start(AcceptOrRejectPersonCommand input)
        {
            var accept = input is AcceptPersonCommand;
            Task.Factory.StartNew(() => Persist(input, accept)).ContinueWith(r => RaiseFinished(accept));
        }

        private void Persist(AcceptOrRejectPersonCommand input, Boolean accept)
        {
            var person = _repository.Query().Where(p => p.Id == input.Id).Single();
            person.Comments = input.Comment;
            person.Accepted = accept;
            _repository.Attach(person);
            _repository.PersistAll();
        }
    }
}
