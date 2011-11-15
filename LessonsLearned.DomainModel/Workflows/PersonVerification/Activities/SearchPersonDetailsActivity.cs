using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Services;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.DomainModel.Workflows.PersonVerification.Activities
{
    public class SearchPersonDetailsActivity : Activity<PersonSummaryDto,PersonDetailsDto>
    {
        private readonly PersonSearchService _personSearchService;

        public SearchPersonDetailsActivity(PersonSearchService personSearchService)
        {
            _personSearchService = personSearchService;
        }

        public override void Start(PersonSummaryDto input)
        {
            Task.Factory.StartNew(() => _personSearchService.SearchPersonDetails(input)).ContinueWith(
                ant => RaiseFinished(ant.Result));
        }
    }
}
