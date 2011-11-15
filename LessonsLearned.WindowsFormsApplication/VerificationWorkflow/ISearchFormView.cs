using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public interface ISearchFormView : IView<SearchFormPresenter>
    {
        String FirstName { get; }
        String LastName { get; }
        DateTime? DateOfBirth { get; }
    }
}
