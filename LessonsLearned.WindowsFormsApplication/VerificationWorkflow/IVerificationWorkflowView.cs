using System;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public interface IVerificationWorkflowView : IContentView, IView<VerificationWorkflowPresenter>
    {
        void SetLastVerificationState(Boolean? verificationState);
        void SetBackEnabled(bool enabled);
    }
}
