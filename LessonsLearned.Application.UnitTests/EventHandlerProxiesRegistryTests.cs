using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LessonsLearned.Application.EventAggregator;
using LessonsLearned.DomainModel.Common;
using Rhino.Mocks;

namespace LessonsLearned.Application.UnitTests
{
    [TestClass]
    public class EventHandlerProxiesRegistryTests
    {
        [TestMethod]
        public void EventHandlerProxiesRegistry_ForUnregisteredEventType_ReturnsEmptyCollection()
        {
            var registry = new EventHandlerProxiesRegistry();
            Assert.IsFalse(registry.ForEvent<DummyEvent>().Any());
        }


        [TestMethod]
        public void EventHandlerProxiesRegistry_ForRegisteredEventType_ReturnsCollection()
        {
            var registry = new EventHandlerProxiesRegistry();
            var eventHandler = MockRepository.GenerateMock <IEventHandler<DummyEvent>>();
            registry.Register<DummyEvent>(eventHandler.Handle);
            registry.Register<DummyEvent>(eventHandler.Handle);
            Assert.AreEqual(2,registry.ForEvent<DummyEvent>().Count());
        }
    }
}
