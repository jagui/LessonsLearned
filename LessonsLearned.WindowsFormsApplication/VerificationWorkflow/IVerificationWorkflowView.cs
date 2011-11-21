using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.Controller;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public interface IVerificationWorkflowView : IView<VerificationWorkflowPresenter>, IHost
    {
        void SetLastVerificationState(Boolean? verificationState);
    }
}
