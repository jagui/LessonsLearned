using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Juanagui.Validation;
using LessonsLearned.PresentationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace LessonsLearned.Application.WinForms.UnitTests
{
    [TestClass]
    public class ModelBinderTests
    {

        private class BindingSource : PresentationModelBase, IDataErrorInfo
        {
            private string _sourceProperty;

            [Required]
            public String SourceProperty
            {
                get { return _sourceProperty; }
                set
                {
                    _sourceProperty = value;
                    RaisePropertyChanged(() => SourceProperty);
                }
            }

            public string this[string columnName]
            {
                get
                {
                    var notification = new Notification();
                    Juanagui.Validation.Validator.Validate(this, notification);
                    return notification[columnName];
                }
            }

            public string Error
            {
                get { throw new NotImplementedException(); }
            }
        }

        [TestMethod]
        public void ModelBinder_Bind_SourceToTarget()
        {
            var target = new TextBox();
            using (new BindingTestContext(target))
            {
                var source = new BindingSource();
                new ModelBinder().Bind(() => target.Text, () => source.SourceProperty);
                const string changed = "changed";
                source.SourceProperty = changed;
                Assert.AreEqual(changed, target.Text);
            }
        }


        [TestMethod]
        public void ModelBinder_Bind_TargetToSource()
        {
            var target = new TextBox();
            using (new BindingTestContext(target))
            {
                var source = new BindingSource();
                new ModelBinder().Bind(() => target.Text, () => source.SourceProperty);
                const string changed = "changed";
                target.Text = changed;
                Assert.AreEqual(changed, source.SourceProperty);
            }
        }



        [TestMethod]
        public void ModelBinder_Bind_TargetToSource_Validation()
        {
            var target = new TextBox();
            using (new BindingTestContext(target))
            {
                var errors = new ErrorProvider();
                var source = new BindingSource { SourceProperty = "original" };
                new ModelBinder(errors).Bind(() => target.Text, () => source.SourceProperty);
                target.Text = String.Empty;
                Assert.AreEqual(String.Empty, source.SourceProperty);
                Assert.AreEqual("The SourceProperty field is required.", errors.GetError(target));
            }
        }
    }
}
