using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using Juanagui.Validation;

namespace LessonsLearned.Application.WinForms
{
    public class ModelBinder
    {
        private readonly List<Binding> _bindings = new List<Binding>();
        private readonly ErrorProvider _errorProvider;

        private Boolean TrackingValidationErrors { get { return _errorProvider != null; } }

        public ModelBinder(ErrorProvider errorProvider)
        {
            _errorProvider = errorProvider;
        }

        public ModelBinder()
        {

        }

        public void Bind<TProperty>(Expression<Func<TProperty>> targetExpression, Expression<Func<TProperty>> sourceExpression)
        {
            var targetAccessor = (MemberExpression)targetExpression.Body;
            var targetObjExpression = targetAccessor.Expression;
            var targetObj = (Control)Expression.Lambda(targetObjExpression, null).Compile().DynamicInvoke(null);
            var targetPropertyName = targetAccessor.Member.Name;

            var sourceAccessor = (MemberExpression)sourceExpression.Body;
            var sourceObjExpression = sourceAccessor.Expression;
            var sourceObj = Expression.Lambda(sourceObjExpression, null).Compile().DynamicInvoke(null);
            var sourcePropertyName = sourceAccessor.Member.Name;

            var binding = new Binding(targetPropertyName, sourceObj, sourcePropertyName, true,
                                      DataSourceUpdateMode.OnPropertyChanged);
            if (TrackingValidationErrors)
            {
                binding.BindingComplete += binding_BindingComplete;
                binding.Format += binding_Format;
            }
            _bindings.Add(binding);
            targetObj.DataBindings.Add(binding);
        }

        void binding_Format(object sender, ConvertEventArgs e)
        {


        }

        void binding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            var binding = (Binding)sender;
            var target = binding.DataSource;
            var notification = new Notification();
            Validator.Validate(target, notification);
            if (notification.IsValid())
                return;
            _errorProvider.SetError((Control)binding.BindableComponent, notification[binding.BindingMemberInfo.BindingField]);
        }

    }
}
