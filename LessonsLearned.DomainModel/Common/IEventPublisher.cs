namespace LessonsLearned.DomainModel.Common
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventData);
        void Register<T>(System.Action<T> handler);
    }
}
