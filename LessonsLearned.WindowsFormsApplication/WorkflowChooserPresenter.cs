using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;

namespace LessonsLearned.WindowsFormsApplication
{
    public class WorkflowChooserPresenter
    {
        private readonly StartWorkflowCommand[] _workflows;
        private readonly IApplicationController _applicationController;
        private readonly IWorkflowChooserView _view;

        public WorkflowChooserPresenter(StartWorkflowCommand[] workflows, IApplicationController applicationController, IWorkflowChooserView view)
        {
            _workflows = workflows;
            _view = view;
            _applicationController = applicationController;
            _view.Presenter = this;
        }

        public void Run()
        {
            _view.LoadWorkflows(_workflows);
        }

        public void StartWorkflow(string text)
        {
            _applicationController.Execute(_workflows.Single(c => c.Name.Equals(text)));
        }
    }
}
