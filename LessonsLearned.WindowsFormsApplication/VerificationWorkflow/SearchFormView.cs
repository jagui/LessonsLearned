using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class SearchFormView : UserControl, ISearchFormView
    {
        public SearchFormView()
        {
            InitializeComponent();
            FirstNameTextBox.Validating += new CancelEventHandler(FirstNameTextBox_Validating);
            LastNameTextBox.Validating += new CancelEventHandler(LastNameTextBox_Validating);
        }

        void LastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        void FirstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
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
    }
}
