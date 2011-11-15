using System.Collections;
using System.Linq;
using System.Collections.Generic;
using LessonsLearned.DomainModel.Entities;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos
{
    public class CandidatesDto : IEnumerable<PersonSummaryDto>
    {
        private readonly IEnumerable<Person> _inner;

        internal CandidatesDto(IEnumerable<Person> inner)
        {
            _inner = inner;
        }

        public IEnumerator<PersonSummaryDto> GetEnumerator()
        {
            return _inner.Select(p => new PersonSummaryDto(p)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
