using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public class StartVerificationWorkflowCommand : StartWorkflowCommand
    {
        public override string Name
        {
            get { return "Verification"; }
        }
    }
}
