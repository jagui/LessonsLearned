using Juanagui.Repositories.Common;
using System.Linq;
using LessonsLearned.DomainModel.Entities;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Services
{
    public class PersonSearchService
    {
        private readonly Repository<Person> _personRepository;

        public PersonSearchService(Repository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public CandidatesDto SearchPerson(PersonSearchFormDto personSearchFormDto)
        {
            var candidates = _personRepository.Query().
                Where(p => p.Forename.Equals(personSearchFormDto.Forename) &&
                           p.Surname.Equals(personSearchFormDto.Surname));

            if (personSearchFormDto.DateOfBirth != null)
                candidates = candidates.Where(p => p.DateOfBirth.Equals(personSearchFormDto.DateOfBirth.Value));

            return new CandidatesDto(candidates);
        }

        public PersonDetailsDto SearchPersonDetails(PersonSummaryDto personSummaryDto)
        {
            var candidate = _personRepository.Query().
                FirstOrDefault(p => p.Id.Equals(personSummaryDto.Id));

            if (candidate != null)
                return PersonDetailsDto.NotFound;

            return new PersonDetailsDto(candidate);
        }
    }
}
