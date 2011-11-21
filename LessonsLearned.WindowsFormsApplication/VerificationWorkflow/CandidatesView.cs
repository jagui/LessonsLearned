using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class CandidatesView : UserControl, ICandidatesView
    {
        public CandidatesPresenter Presenter { get; set; }

        public CandidatesView()
        {
            InitializeComponent();
            AcceptButton.Enabled = false;
            RejectButton.Enabled = false;
            dataGridView1.Click += (o, e) => Presenter.EvaluateCandProcess();
            textBox1.TextChanged += (o, e) => Presenter.EvaluateCandProcess();
        }


        public void ShowCandidates(IEnumerable<PersonSummaryDto> candidates)
        {
            this.RunInUiThread(() =>
                                   {
                                       dataGridView1.DataSource = new List<PersonSummaryDto>(candidates);
                                   });
        }
        public void Run()
        {
        }
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            Presenter.Verify();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            Presenter.Reject();
        }

        public PersonSummaryDto SelectedCandidate()
        {
            if (dataGridView1.CurrentRow != null)
                return ((PersonSummaryDto)dataGridView1.CurrentRow.DataBoundItem);
            return null;
        }


        public void SetCanProcess(bool canProcess)
        {
            AcceptButton.Enabled = canProcess;
            RejectButton.Enabled = canProcess;
        }


        public string Comment
        {
            get
            {
                return textBox1.Text;
            }
        }
    }
}
