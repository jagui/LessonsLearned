using System;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.Application.EventAggregator
{
    internal class EventHandlerProxy<T> : IEventHandler<T>, IEventHandlerProxy
    {
        private readonly Action<T> _handler;

        public EventHandlerProxy(Action<T> handler)
        {
            _handler = handler;
        }

        public void Handle(T eventData)
        {
            _handler(eventData);
        }

        public void Handle(object eventData)
        {
            Handle((T)eventData);
        }
    }
}