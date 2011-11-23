using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.PresentationModel;

namespace LessonsLearned.WindowsFormsApplication.VerificationWorkflow
{
    public interface ISearchFormView : IView<SearchFormPresenter>
    {
        void SetSearchForm(SearchForm searchForm);
    }
}
