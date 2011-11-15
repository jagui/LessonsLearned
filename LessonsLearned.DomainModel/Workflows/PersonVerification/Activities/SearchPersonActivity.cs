using System.Threading.Tasks;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Services;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Activities
{
    public class SearchPersonActivity : Activity<PersonSearchFormDto, CandidatesDto>
    {
        private readonly PersonSearchService _personSearchService;

        public SearchPersonActivity(PersonSearchService personSearchService)
        {
            _personSearchService = personSearchService;
        }

        public override void Start(PersonSearchFormDto input)
        {
            Task.Factory.StartNew(() => _personSearchService.SearchPerson(input)).ContinueWith(
                ant => RaiseFinished(ant.Result));
        }
    }
}
