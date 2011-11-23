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
            Presenter.Search(this);
        }

        public void SetSearchForm(SearchForm searchForm)
        {
            SetFirstNameBinding(searchForm);
            SetLastNameBinding(searchForm);
        }

        private void SetFirstNameBinding(SearchForm searchForm)
        {
            _modelBinder.Bind(() => FirstNameTextBox.Text, () => searchForm.Forename);
        }

        private void SetLastNameBinding(SearchForm searchForm)
        {
            _modelBinder.Bind(() => LastNameTextBox.Text, () => searchForm.Surname);
        }
    }
}
