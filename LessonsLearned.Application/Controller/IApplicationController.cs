using System;
using Caliburn.Micro;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.Application.Controller
{
    public interface IApplicationController : IEventPublisher
    {
        void Execute<T>(T commandData);
        void SetConductor(IConductor conductor);
        void Activate(Screen view);
    }
}