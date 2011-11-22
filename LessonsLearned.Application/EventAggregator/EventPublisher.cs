using System;
using System.Linq;
using LessonsLearned.DomainModel;
using LessonsLearned.DomainModel.Common;
using Microsoft.Practices.ServiceLocation;

namespace LessonsLearned.Application.EventAggregator
{
    public class EventPublisher : IEventPublisher
    {
        private readonly EventHandlerProxiesRegistry _eventHandlerProxiesRegistry = new EventHandlerProxiesRegistry();
        private readonly IServiceLocator _serviceLocator;

        public EventPublisher(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Publish<T>(T eventData)
        {
            var eventHandlers = _serviceLocator.GetAllInstances<IEventHandler<T>>().Concat(_eventHandlerProxiesRegistry.ForEvent<T>());
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Handle(eventData);
            }
        }
        public void Register<T>(Action<T> handler)
        {
            _eventHandlerProxiesRegistry.Register(handler);
        }
    }
}
