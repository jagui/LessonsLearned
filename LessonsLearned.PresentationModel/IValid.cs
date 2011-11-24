using System;
using System.ComponentModel;

namespace LessonsLearned.PresentationModel
{
    public interface IValid : IDataErrorInfo
    {
        Boolean IsValid { get; }
    }
}