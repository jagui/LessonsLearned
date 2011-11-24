using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.ComponentModel;

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
            CreateBinding(new BindingTargetDescriptor(targetExpression), new BindingSourceDescriptor(sourceExpression));
        }

        private void CreateBinding(BindingTargetDescriptor target, BindingSourceDescriptor source)
        {
            var binding = new Binding(target.PropertyName, source.Object, source.PropertyName, TrackingValidationErrors,
                                      DataSourceUpdateMode.OnPropertyChanged);
            if (TrackingValidationErrors)
            {
                binding.BindingComplete += BindingComplete;
            }
            _bindings.Add(binding);
            target.Object.DataBindings.Add(binding);
        }

        private void BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            var binding = (Binding)sender;
            if (e.BindingCompleteState == BindingCompleteState.Success)
            {
                _errorProvider.SetError((Control)binding.BindableComponent, String.Empty);
            }
            if (e.BindingCompleteState == BindingCompleteState.DataError)
            {
                _errorProvider.SetError((Control)binding.BindableComponent, e.ErrorText);
            }
            if (e.BindingCompleteState == BindingCompleteState.Exception)
            {
                _errorProvider.SetError((Control)binding.BindableComponent, e.Exception.Message);
            }
        }
    }
}
