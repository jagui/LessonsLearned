using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.Application.EventAggregator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonsLearned.Application.UnitTests
{
    [TestClass]
    public class EventHandlerProxyTests
    {
        [TestMethod]
        public void EventHandlerProxy_HandlesEvent()
        {
            const string dummy = "dummy";
            var eventHandler = new DummyEventHandler();
            var action = new Action<DummyEvent>(eventHandler.Handle);
            var proxy = new EventHandlerProxy<DummyEvent>(action);
            proxy.Handle(new DummyEvent { DummyString = dummy });
            Assert.AreEqual(dummy, eventHandler.HandledResult);
        }
    }
}
