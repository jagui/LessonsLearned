using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.WindowsFormsApplication
{
    public abstract class StartWorkflowCommand
    {
        public abstract String Name { get; }
    }
}
