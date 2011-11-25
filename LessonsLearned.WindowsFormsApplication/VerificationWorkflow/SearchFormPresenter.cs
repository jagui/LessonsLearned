using Caliburn.Micro;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.PresentationModel;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class SearchFormPresenter : Screen, ICommand<StartSearchCommand>
    {
        private readonly IApplicationController _applicationController;
        private readonly ISearchFormView _view;
        private readonly SearchForm _searchForm;
        public SearchFormPresenter(IApplicationController applicationController, ISearchFormView view)
        {
            _applicationController = applicationController;
            _view = view;
            _searchForm = new SearchForm();
            _searchForm.PropertyChanged += SearchFormPropertyChanged;
            _view.SetSearchForm(_searchForm);
            _view.DisableSearch();
            _view.Presenter = this;
            AttachView(_view, null);
        }

        void SearchFormPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_searchForm.IsValid)
                _view.EnableSearch();
            else
                _view.DisableSearch();
        }

        public void Search()
        {
            _applicationController.Execute(CreateSearchPersonCommand());
        }

        public void Execute(StartSearchCommand commandData)
        {
            _applicationController.Activate(this);
        }

        private SearchPersonCommand CreateSearchPersonCommand()
        {
            return new SearchPersonCommand(_searchForm.ToDto());
        }

        protected override void OnDeactivate(bool close)
        {
            _searchForm.Reset();
            base.OnDeactivate(close);
        }
    }
}
