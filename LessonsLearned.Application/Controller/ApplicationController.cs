using LessonsLearned.DomainModel;
using LessonsLearned.DomainModel.Common;
using Microsoft.Practices.ServiceLocation;
using IEventPublisher = LessonsLearned.Application.EventAggregator.IEventPublisher;

namespace LessonsLearned.Application.Controller
{
    class ApplicationController
    {
        private readonly IServiceLocator _serviceLocator;
        private readonly IEventPublisher _eventPublisher;


        public ApplicationController(IServiceLocator serviceLocator, IEventPublisher eventPublisher)
        {
            _serviceLocator = serviceLocator;
            _eventPublisher = eventPublisher;
        }

        public void Execute<T>(T commandData)
        {
            var command = _serviceLocator.GetInstance<ICommand<T>>();
            command.Execute(commandData);
        }

        public void Raise<T>(T eventData)
        {
            _eventPublisher.Publish(eventData);
        }
    }
}
