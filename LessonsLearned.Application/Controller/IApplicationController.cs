using System;
namespace LessonsLearned.Application.Controller
{
    public interface IApplicationController : IHost
    {
        void Execute<T>(T commandData);
        void Raise<T>(T eventData);
        void Register<T>(Action<T> handler);
        void SetHost(IHost host);
    }
}