using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class CandidatesView : UserControl, ICandidatesView
    {
        public CandidatesView()
        {
            InitializeComponent();
        }

        public void ShowCandidates(IEnumerable<PersonSummaryDto> candidates)
        {
            dataGridView1.DataSource = candidates;
        }

        public CandidatesPresenter Presenter { get; set; }

        public void Run()
        {
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            //Presenter.Verify((PersonSummaryDto)dataGridView1.DataSource.);
        }
    }
}
