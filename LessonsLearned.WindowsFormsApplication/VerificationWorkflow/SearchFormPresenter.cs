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
    public class SearchFormPresenter : ICommand<StartSearchCommand>
    {
        private readonly IApplicationController _applicationController;
        private readonly ISearchFormView _view;
        public SearchFormPresenter(IApplicationController applicationController, ISearchFormView view)
        {
            _applicationController = applicationController;
            _view = view;
            _view.Presenter = this;
        }

        public void Search()
        {
            _applicationController.Execute(CreateSearchPersonCommand(_view));
        }

        public void Execute(StartSearchCommand commandData)
        {
            _applicationController.ShowInHost(_view);
        }

        private static SearchPersonCommand CreateSearchPersonCommand(ISearchFormView view)
        {
            return new SearchPersonCommand(
                           new PersonSearchFormDto
                               {
                                   Forename = view.FirstName,
                                   Surname = view.LastName,
                                   DateOfBirth = view.DateOfBirth
                               });
        }
    }
}
