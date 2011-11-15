using System;
using System.Collections.Generic;
using LessonsLearned.DomainModel;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.Application.EventAggregator
{
    public interface IEventPublisher : DomainModel.Common.IEventPublisher
    {
        EventHandlerOptions RegisterHandler<T>(IEventHandler<T> eventHandler);
        IList<EventHandlerOptions> RegisterHandlers(object eventHandler);

        void UnregisterHandler<T>(IEventHandler<T> eventHandler);
        void UnregisterHandlers(object eventHandler);


        T GetMostRecentPublication<T>();

        void OnHandlerError(Action<Exception> errorHandler);
    }
}
