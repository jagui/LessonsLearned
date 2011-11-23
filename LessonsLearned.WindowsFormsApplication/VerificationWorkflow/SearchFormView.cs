using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LessonsLearned.PresentationModel;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class SearchFormView : UserControl, ISearchFormView
    {
        public SearchFormView()
        {
            InitializeComponent();
            //FirstNameTextBox.Validating += FirstNameTextBox_Validating;
            //LastNameTextBox.Validating += LastNameTextBox_Validating;
        }

        //void LastNameTextBox_Validating(object sender, CancelEventArgs e)
        //{
        //    errorProvider1 = 
        //}

        //void FirstNameTextBox_Validating(object sender, CancelEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

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

        public string FirstName
        {
            get { return FirstNameTextBox.Text; }
        }

        public string LastName
        {
            get { return LastNameTextBox.Text; }
        }

        public DateTime? DateOfBirth
        {
            get { return null; }
        }

        public void SetSearchForm(SearchForm searchForm)
        {
            SetFirstNameBinding(searchForm);
            SetLastNameBinding(searchForm);
        }

        private void SetFirstNameBinding(SearchForm searchForm)
        {
            FirstNameTextBox.DataBindings.Clear();
            FirstNameTextBox.DataBindings.Add(new Binding("Text", searchForm, "Forename"));
        }

        private void SetLastNameBinding(SearchForm searchForm)
        {
            LastNameTextBox.DataBindings.Clear();
            LastNameTextBox.DataBindings.Add(new Binding("Text", searchForm, "Surname"));
        }

    }
}
