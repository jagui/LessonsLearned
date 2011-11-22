using System;
using System.Collections.Generic;
using System.Linq;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.Application.EventAggregator
{
    internal class EventHandlerProxiesRegistry
    {
        private readonly Dictionary<Type, List<IEventHandlerProxy>> _proxies = new Dictionary<Type, List<IEventHandlerProxy>>();

        public void Register<TEvent>(Action<TEvent> handler)
        {
            var proxy = (IEventHandlerProxy)new EventHandlerProxy<TEvent>(handler);
            var eventType = typeof(TEvent);
            if (!_proxies.ContainsKey(eventType))
            {
                _proxies.Add(eventType, new List<IEventHandlerProxy>());
            }
            _proxies[eventType].Add(proxy);
        }

        private IEnumerable<IEventHandlerProxy> this[Type index]
        {
            get { return _proxies[index]; }
        }

        public IEnumerable<IEventHandler<TEvent>> ForEvent<TEvent>()
        {
            var eventType = typeof(TEvent);

            if (!_proxies.ContainsKey(eventType))
                return Enumerable.Empty<IEventHandler<TEvent>>();

            return this[eventType].OfType<IEventHandler<TEvent>>();
        }
    }
}