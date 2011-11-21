using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LessonsLearned.Application.Controller;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public partial class VerificationWorkflowForm : Form, IVerificationWorkflowView
    {
        private readonly Color _defaultBackColor;

        public VerificationWorkflowForm()
        {
            InitializeComponent();
            _defaultBackColor = BackColor;
        }

        public VerificationWorkflowPresenter Presenter { get; set; }

        public void Run()
        {
            Show();
        }

        public void SetLastVerificationState(bool? verificationState)
        {
            this.RunInUiThread(() =>
                                   {
                                       Controls.Clear();
                                       Controls.Add(StartButton);
                                       if (verificationState.HasValue)
                                       {
                                           BackColor = verificationState.Value ? Color.Green : Color.Red;
                                       }
                                       else
                                       {
                                           BackColor = _defaultBackColor;
                                       }
                                   });
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Presenter.Start();
        }


        public void ShowInHost(IView view)
        {
            this.RunInUiThread(() =>
                              {
                                  SuspendLayout();
                                  Controls.Clear();
                                  Controls.Add((Control)view);
                                  ResumeLayout();
                              });

        }
    }
}
