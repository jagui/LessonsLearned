using System;

namespace LessonsLearned.DomainModel.Common
{
    public abstract class Activity<TInput, TOutput>
    {
        public abstract void Start(TInput input);
        public event EventHandler<ActivityFinishedEventArgs<TOutput>> Finished;

        protected void RaiseFinished(TOutput output)
        {
            var tmp = Finished;
            if (tmp != null)
                tmp(this, new ActivityFinishedEventArgs<TOutput>(output));
        }
    }
}