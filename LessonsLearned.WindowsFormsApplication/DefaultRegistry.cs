using Juanagui.Repositories.Common;
using Juanagui.Repositories.EntityFramework;
using LessonsLearned.DomainModel.Common;
using LessonsLearned.DomainModel.Entities;
using LessonsLearned.WindowsFormsApplication.EnrolmentWorkflow;
using LessonsLearner.DataAccess;
using SimpleOrgChart;
using StructureMap.Configuration.DSL;
using System.Windows.Forms;
using LessonsLearned.Application.Controller;
using LessonsLearned.WindowsFormsApplication.VerificationWorkflow;
using LessonsLearned.Application.EventAggregator;
using IEventPublisher = LessonsLearned.Application.EventAggregator.IEventPublisher;
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
            RegisterInterceptor(new EventAggregatorInterceptor());

            For<WorkflowChooserPresenter>().Use<WorkflowChooserPresenter>();

            For<StartWorkflowCommand>().Use<StartVerificationWorkflowCommand>();
            For<IVerificationWorkflowView>().Use<VerificationWorkflowForm>();
            For<ICommand<StartWorkflowCommand>>().Use<VerificationWorkflowPresenter>();
            For<ICommand<StartVerificationWorkflowCommand>>().Use<VerificationWorkflowPresenter>();

            For<StartWorkflowCommand>().Use<StartEnrolmentWorkflowCommand>();
            For<IEnrolmentFormView>().Use<EnrolmentForm>();
            For<ICommand<StartWorkflowCommand>>().Use<EnrolmentWorkflowPresenter>();
            For<ICommand<StartEnrolmentWorkflowCommand>>().Use<EnrolmentWorkflowPresenter>();

            For<ISearchFormView>().Use<SearchFormView>();
            For<ICommand<StartSearchCommand>>().Use<SearchFormPresenter>();

            For<SearchPersonActivity>().Use<SearchPersonActivity>();
            For<PersonSearchService>().Singleton().Use<PersonSearchService>();
            For<Repository<Person>>().Singleton().Use<EntityFrameworkPocoRepository<Person>>().Ctor<DbContext>().Is(c => c.GetInstance<LessonsLearnedDbContext>());
            For<LessonsLearnedDbContext>().Singleton().Use<LessonsLearnedDbContext>();
            For<SearchPersonDetailsActivity>().Use<SearchPersonDetailsActivity>();
            For<ICommand<SearchPersonCommand>>().Singleton().Use<PersonVerificationWorkflow>();
            For<IEventHandler<PersonSelectedEvent>>().Singleton().Use<PersonVerificationWorkflow>();
            For<ICommand<VerifyPersonCommand>>().Singleton().Use<PersonVerificationWorkflow>();

            For<ICommand<EnrolPersonCommand>>().Singleton().Use<PersonEnrolmentWorkflow>();



            //    .AsSingletons()
            //    .TheDefault.Is.OfConcreteType<EventPublisher>();

            //ForRequestedType<IOrgChartView>()
            //    .TheDefaultIsConcreteType<MainForm>()
            //    .OnCreation((i, v) => i.GetInstance<EmployeeDetailPresenter>());

            //ForRequestedType<IEmployeeRepository>()
            //    .TheDefaultIsConcreteType<InMemoryEmployeeRepository>();

            //ForRequestedType<IEmployeeDetailView>()
            //    .TheDefaultIsConcreteType<ViewEmployeeDetailControl>();

            //ForRequestedType<ICommand<AddNewEmployeeData>>()
            //    .TheDefaultIsConcreteType<AddNewEmployeeService>();

            //ForRequestedType<IGetNewEmployeeInfo>()
            //    .TheDefaultIsConcreteType<NewEmployeeInfoPresenter>();

            //ForRequestedType<INewEmployeeInfoView>()
            //    .TheDefaultIsConcreteType<NewEmployeeInfoForm>();

            //ForRequestedType<IGetEmployeeManager>()
            //    .TheDefaultIsConcreteType<SelectEmployeeManagerPresenter>();

            //ForRequestedType<ISelectEmployeeManagerView>()
            //    .TheDefaultIsConcreteType<SelectEmployeeManagerForm>();


        }

    }

}