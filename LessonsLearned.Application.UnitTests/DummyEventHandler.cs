using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Common;

namespace LessonsLearned.Application.UnitTests
{
    public class DummyEventHandler : IEventHandler<DummyEvent>
    {
        public String HandledResult { get; set; }

        public void Handle(DummyEvent eventData)
        {
            HandledResult = eventData.DummyString;
        }
    }
}
