namespace LessonsLearned.Application.Controller
{
    public interface IApplicationController : IHost
    {
        void Execute<T>(T commandData);
        void Raise<T>(T eventData);
        void SetHost(IHost host);
    }
}