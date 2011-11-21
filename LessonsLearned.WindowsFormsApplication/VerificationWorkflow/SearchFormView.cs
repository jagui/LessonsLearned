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
