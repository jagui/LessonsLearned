using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class SearchFormPresenter : ICommand<SearchPersonCommand>
    {
        private readonly IApplicationController _applicationController;
        private readonly ISearchFormView _screen;

        private readonly 
        public SearchFormPresenter(IApplicationController applicationController,ISearchFormView screen)
        {
            _applicationController = applicationController;
            _screen = screen;
        }

        public void Search()
        {
            Execute(CreateSearchPersonCommand(_screen));
        }

        public void Execute(SearchPersonCommand commandData)
        {
            _applicationController.Execute(commandData);
        }

        private static SearchPersonCommand CreateSearchPersonCommand(ISearchFormView screen)
        {
            return new SearchPersonCommand(
                           new PersonSearchFormDto
                               {
                                   Forename = screen.FirstName,
                                   Surname = screen.LastName,
                                   DateOfBirth = screen.DateOfBirth
                               });
        }
    }
}
