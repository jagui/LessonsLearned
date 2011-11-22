namespace LessonsLearned.Application.EventAggregator
{
    internal interface IEventHandlerProxy
    {
        void Handle(object eventData);
    }
}