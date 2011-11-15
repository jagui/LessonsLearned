using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;

namespace LessonsLearned.PresentationModel
{
    public abstract class PresentationModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(String propertyName)
        {
            Contract.Requires(!String.IsNullOrEmpty(propertyName));
            var type = GetType();
            if (type.GetProperty(propertyName) == null)
            {
                throw new ArgumentOutOfRangeException(String.Format("{0} type contains no {1} property", type.Name, propertyName));
            }
            ActuallyRaisePropertyChanged(propertyName);
        }


        private void ActuallyRaisePropertyChanged(String propertyName)
        {
            var tmp = PropertyChanged;
            if (tmp != null)
            {
                tmp(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;
            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else memberExpression = (MemberExpression)lambda.Body;
            ActuallyRaisePropertyChanged(memberExpression.Member.Name);
        }
    }
}
