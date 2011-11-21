using Juanagui.Repositories.Common;
using Juanagui.Repositories.EntityFramework;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Entities;
using LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow;
using LessonsLearner.DataAccess;
using StructureMap.Configuration.DSL;
using System.Windows.Forms;
using LessonsLearned.Application.Controller;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;
using LessonsLearned.Application.EventAggregator;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Commands;
using LessonsLearned.DomainModel.Workflows.PersonVerification;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Events;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Activities;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Services;
using System.Data.Entity;
using LessonsLearned.DomainModel.Workflows.PersonEnrolment.Commands;
using LessonsLearned.DomainModel.Workflows.PersonEnrolment;


namespace LessonsLearned.WindowsFormsApplication
{

    public class DefaultRegistry : Registry
    {

        public DefaultRegistry()
        {
            For<ApplicationContext>().Use<AppContext>();
            For<IApplicationController>().Singleton().Use<ApplicationController>();
            For<IEventPublisher>().Singleton().Use<EventPublisher>();
            For<DomainModel.Common.IEventPublisher>().Singleton().Use<EventPublisher>();

            //Workflow Chooser
            For<WorkflowChooserPresenter>().Use<WorkflowChooserPresenter>();

            //
            //Verification Workflow
            //

            //Ui
            For<StartWorkflowCommand>().Use<StartVerificationWorkflowCommand>();
            For<IVerificationWorkflowView>().Use<VerificationWorkflowForm>();
            For<ICommand<StartWorkflowCommand>>().Use<VerificationWorkflowPresenter>();
            For<IEventHandler<PersonVerifiedEvent>>().Use<VerificationWorkflowPresenter>();
            For<ICommand<StartVerificationWorkflowCommand>>().Use<VerificationWorkflowPresenter>();
            For<ISearchFormView>().Use<SearchFormView>();
            For<ICommand<StartSearchCommand>>().Use<SearchFormPresenter>();
            For<CandidatesPresenter>().Use<CandidatesPresenter>();
            For<IEventHandler<CandidatesFoundEvent>>().Use<CandidatesPresenter>();
            For<ICandidatesView>().Use<CandidatesView>();
            //Domain
            For<SearchPersonActivity>().Use<SearchPersonActivity>();
            For<PersonSearchService>().Singleton().Use<PersonSearchService>();
            For<Repository<Person>>().Singleton().Use<EntityFrameworkPocoRepository<Person>>().Ctor<DbContext>().Is(c => c.GetInstance<LessonsLearnedDbContext>());
            For<LessonsLearnedDbContext>().Singleton().Use<LessonsLearnedDbContext>();
            For<SearchPersonDetailsActivity>().Use<SearchPersonDetailsActivity>();
            For<ICommand<SearchPersonCommand>>().Singleton().Use<PersonVerificationWorkflow>();
            For<IEventHandler<PersonSelectedEvent>>().Singleton().Use<PersonVerificationWorkflow>();
            For<ICommand<AcceptPersonCommand>>().Singleton().Use<PersonVerificationWorkflow>();
            For<ICommand<RejectPersonCommand>>().Singleton().Use<PersonVerificationWorkflow>();

            //
            //Enrolment Workflow
            //

            //Ui
            For<StartWorkflowCommand>().Use<StartEnrolmentWorkflowCommand>();
            For<IEnrolmentFormView>().Use<EnrolmentForm>();
            For<ICommand<StartWorkflowCommand>>().Use<EnrolmentWorkflowPresenter>();
            For<ICommand<StartEnrolmentWorkflowCommand>>().Use<EnrolmentWorkflowPresenter>();
            //Domain
            For<ICommand<EnrolPersonCommand>>().Singleton().Use<PersonEnrolmentWorkflow>();
        }
    }
}