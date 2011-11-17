using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.WindowsFormsApplication
{
    public interface IWorkflowChooserView : IModalView<WorkflowChooserPresenter>
    {
        void LoadWorkflows(IEnumerable<StartWorkflowCommand> workflowCommands);
    }
}
