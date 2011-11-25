using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Caliburn.Micro;
using LessonsLearned.Application.Controller;
using Screen = Caliburn.Micro.Screen;

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
            //this.RunInUiThread(() =>
            //                       {
            //                           SuspendLayout();
            //                           Controls.Clear();
            //                           Controls.Add(StartButton);
            //                           if (verificationState.HasValue)
            //                           {
            //                               BackColor = verificationState.Value ? Color.Green : Color.Red;
            //                           }
            //                           else
            //                           {
            //                               BackColor = _defaultBackColor;
            //                           }
            //                           ResumeLayout();
            //                       });
        }

        public void Show(Screen view)
        {
            this.RunInUiThread(() =>
            {
                Content.SuspendLayout();
                Content.Controls.Clear();
                Content.Controls.Add(view.GetView());
                Content.ResumeLayout();
            });
        }

        public void SetBackEnabled(bool enabled)
        {
            this.RunInUiThread(() => Back.Enabled = enabled);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Presenter.Start();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Presenter.GoBack();
        }
    }
}
