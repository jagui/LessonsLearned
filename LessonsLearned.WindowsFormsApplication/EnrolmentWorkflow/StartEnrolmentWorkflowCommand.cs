using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow
{
    public class StartEnrolmentWorkflowCommand : StartWorkflowCommand
    {
        public override string Name
        {
            get { return "Enrolment"; }
        }
    }
}