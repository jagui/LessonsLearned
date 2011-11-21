using System;

namespace LessonsLearned.DomainModel.Common
{
    public class    ActivityFinishedEventArgs<TOutput> : EventArgs
    {
        private readonly TOutput _output;

        public ActivityFinishedEventArgs(TOutput output)
        {
            _output = output;
        }

        public TOutput Output
        {
            get { return _output; }
        }
    }
}