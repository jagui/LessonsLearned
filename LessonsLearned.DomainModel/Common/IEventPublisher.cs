namespace LessonsLearned.DomainModel.Common
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventData);
    }
}
