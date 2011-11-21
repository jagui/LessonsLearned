using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow
{
    public partial class EnrolmentForm : Form, IEnrolmentFormView
    {
        public EnrolmentForm()
        {
            InitializeComponent();
        }

        public string FirstName
        {
            get { return FirstNameTextBox.Text; }
        }

        public string LastName
        {
            get { return LastNameTextBox.Text; }
        }

        public DateTime DateOfBirth
        {
            get { return DateOfBirthDatePicker.Value; }
        }

        public void Reset()
        {
            FirstNameTextBox = null;
            LastNameTextBox.Text = null;
            DateOfBirthDatePicker.Value = DateTime.Today;
        }

        public void Run()
        {
            Show();
        }

        public EnrolmentWorkflowPresenter Presenter { get; set; }

        private void EnrolButton_Click(object sender, EventArgs e)
        {
            Presenter.Enrol(this);
        }
    }
}
