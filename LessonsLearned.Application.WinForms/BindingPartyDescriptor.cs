using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace LessonsLearned.Application.WinForms
{
    internal abstract class BindingPartyDescriptor<TObject>
    {
        private readonly String _propertyName;
        private readonly TObject _object;

        protected BindingPartyDescriptor(Expression expression)
        {
            var memberExpression = GetMemberExpression(expression);
            _object = GetObject<TObject>(memberExpression);
            _propertyName = GetMemberName(memberExpression);
        }


        public TObject Object
        {
            get { return _object; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        private static String GetMemberName(MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }

        private static MemberExpression GetMemberExpression(Expression targetExpression)
        {
            return (MemberExpression)((LambdaExpression)targetExpression).Body;
        }

        private static T GetObject<T>(MemberExpression memberExpression)
        {
            var objExpression = memberExpression.Expression;
            return (T)Expression.Lambda(objExpression, null).Compile().DynamicInvoke(null);
        }
    }

    internal sealed class BindingTargetDescriptor : BindingPartyDescriptor<IBindableComponent>
    {
        public BindingTargetDescriptor(Expression expression) : base(expression)
        {
        }
    }

    internal sealed class BindingSourceDescriptor : BindingPartyDescriptor<INotifyPropertyChanged>
    {
        public BindingSourceDescriptor(Expression expression) : base(expression)
        {
        }
    }
}