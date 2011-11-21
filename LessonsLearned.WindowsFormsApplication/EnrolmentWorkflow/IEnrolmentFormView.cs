using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow
{
    public interface IEnrolmentFormView : IView<EnrolmentWorkflowPresenter>
    {
        String FirstName { get; }
        String LastName { get; }
        DateTime DateOfBirth { get; }
        void Reset();
    }
}
