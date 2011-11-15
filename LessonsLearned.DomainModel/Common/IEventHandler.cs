namespace LessonsLearned.DomainModel.Common
{
	public interface IEventHandler<T>
	{
		void Handle(T eventData);
	}
}