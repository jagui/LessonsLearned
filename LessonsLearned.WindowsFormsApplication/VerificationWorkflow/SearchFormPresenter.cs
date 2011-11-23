using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using LessonsLearned.PresentationModel;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class SearchFormPresenter : ICommand<StartSearchCommand>
    {
        private readonly IApplicationController _applicationController;
        private readonly ISearchFormView _view;
        private readonly SearchForm _searchForm;
        public SearchFormPresenter(IApplicationController applicationController, ISearchFormView view)
        {
            _applicationController = applicationController;
            _view = view;
            _searchForm = new SearchForm();
            _view.SetSearchForm(_searchForm);
            _view.Presenter = this;
        }

        public void Search(ISearchFormView formView)
        {
            _applicationController.Execute(CreateSearchPersonCommand(formView));
        }

        public void Execute(StartSearchCommand commandData)
        {
            _applicationController.ShowInHost(_view);
        }

        private SearchPersonCommand CreateSearchPersonCommand(ISearchFormView view)
        {
            return new SearchPersonCommand(_searchForm.ToDto());
        }
    }
}
