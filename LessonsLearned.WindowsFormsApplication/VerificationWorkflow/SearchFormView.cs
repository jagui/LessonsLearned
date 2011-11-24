using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LessonsLearned.Application.WinForms;
using LessonsLearned.PresentationModel;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class SearchFormView : UserControl, ISearchFormView
    {
        private readonly ModelBinder _modelBinder;

        public SearchFormView()
        {
            InitializeComponent();
            _modelBinder = new ModelBinder(errorProvider1);
        }

        public SearchFormPresenter Presenter
        {
            get;
            set;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            Presenter.Search();
        }

        public void SetSearchForm(SearchForm searchForm)
        {
            BindFirstName(searchForm);
            BinsLastName(searchForm);
        }

        public void EnableSearch()
        {
            SearchButton.Enabled = true;
        }

        public void DisableSearch()
        {
            SearchButton.Enabled = false;
        }

        private void BindFirstName(SearchForm searchForm)
        {
            _modelBinder.Bind(() => FirstNameTextBox.Text, () => searchForm.Forename);
        }

        private void BinsLastName(SearchForm searchForm)
        {
            _modelBinder.Bind(() => LastNameTextBox.Text, () => searchForm.Surname);
        }
    }
}
