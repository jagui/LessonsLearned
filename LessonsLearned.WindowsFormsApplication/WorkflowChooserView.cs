using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.WindowsFormsApplication
{
    public partial class WorkflowChooserView : Form, IWorkflowChooserView
    {
        public WorkflowChooserView()
        {
            InitializeComponent();
        }

        public WorkflowChooserPresenter Presenter { get; set; }

        public void Run()
        {
            ShowDialog();
        }

        public void LoadWorkflows(IEnumerable<StartWorkflowCommand> workflows)
        {
            foreach (var workflow in workflows)
            {
                var button = new Button { Text = workflow.Name };
                button.Click += button_Click;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Presenter.StartWorkflow(((Button)sender).Text);
        }
    }
}
