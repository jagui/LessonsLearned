using System;
using System.Linq;
using Caliburn.Micro;
using LessonsLearned.Application.EventAggregator;
using LessonsLearned.DomainModel.Common;
using Microsoft.Practices.ServiceLocation;


namespace LessonsLearned.Application.Controller
{
    public class ApplicationController : IApplicationController
    {
        private readonly EventHandlerProxiesRegistry _eventHandlerProxiesRegistry = new EventHandlerProxiesRegistry();
        private readonly IServiceLocator _serviceLocator;
        private IConductor _conductor;

        public ApplicationController(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public void Execute<T>(T commandData)
        {
            var commands = Enumerable.Empty<ICommand<T>>();
            if (_conductor != null)
            {
                commands = _conductor.GetChildren().OfType<ICommand<T>>();
            }
            if (!commands.Any())
            {
                commands = _serviceLocator.GetAllInstances<ICommand<T>>();
            }
            commands.Apply(command => command.Execute(commandData));
        }

        public void SetConductor(IConductor conductor)
        {
            _conductor = conductor;
        }

        public void Activate(Screen screen)
        {
            _conductor.ActivateItem(screen);
        }

        void IEventPublisher.Publish<T>(T eventData)
        {
            var events = Enumerable.Empty<IEventHandler<T>>();
            if (_conductor != null)
            {
                events = _conductor.GetChildren().OfType<IEventHandler<T>>();
            }
            if (!events.Any())
            {
                events = _serviceLocator.GetAllInstances<IEventHandler<T>>();
            }
            events = events.Concat(_eventHandlerProxiesRegistry.ForEvent<T>());
            events.Apply(eventHandler => eventHandler.Handle(eventData));
        }
        void IEventPublisher.Register<T>(Action<T> handler)
        {
            _eventHandlerProxiesRegistry.Register(handler);
        }

    }
}
