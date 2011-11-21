using System;
using System.Collections.Generic;
using LessonsLearned.DomainModel;
using LessonsLearned.DomainModel.Common;
using Microsoft.Practices.ServiceLocation;

namespace LessonsLearned.Application.EventAggregator
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IServiceLocator _serviceLocator;

        public EventPublisher(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Publish<T>(T eventData)
        {
            var eventHandlers = _serviceLocator.GetAllInstances<IEventHandler<T>>();
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Handle(eventData);
            }
        }
    }
}
