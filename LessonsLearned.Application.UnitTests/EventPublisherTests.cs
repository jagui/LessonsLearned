using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LessonsLearned.Application.EventAggregator;
using Rhino.Mocks;
using Microsoft.Practices.ServiceLocation;

namespace LessonsLearned.Application.UnitTests
{
    [TestClass]
    public class EventPublisherTests
    {
        [TestMethod]
        public void EventPublisher_RegisterHandler_PublishEvent_HandlerIsCalled()
        {
            var serviceLocator = MockRepository.GenerateStub<IServiceLocator>();
            serviceLocator.Stub(s => s.GetAllInstances<IEventHandler<DummyEvent>>()).Return(
                Enumerable.Empty<IEventHandler<DummyEvent>>());

            var publisher = new EventPublisher(serviceLocator);
            var eventHandler = new DummyEventHandler();
            publisher.Register<DummyEvent>(eventHandler.Handle);

            const string dummy = "dummy";
            publisher.Publish(new DummyEvent { DummyString = dummy });
            Assert.AreEqual(dummy, eventHandler.HandledResult);
        }

        [TestMethod]
        public void EventPublisher_HandlerRegisteresInContainer_PublishEvent_HandlerIsCalled()
        {
            var eventHandler = new DummyEventHandler();
            var serviceLocator = MockRepository.GenerateStub<IServiceLocator>();
            serviceLocator.Stub(s => s.GetAllInstances<IEventHandler<DummyEvent>>()).Return(new[] {eventHandler});

            var publisher = new EventPublisher(serviceLocator);

            const string dummy = "dummy";
            publisher.Publish(new DummyEvent { DummyString = dummy });
            Assert.AreEqual(dummy, eventHandler.HandledResult);
        }
    }
}
