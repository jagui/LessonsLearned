using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LessonsLearned.PresentationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonsLearned.Application.WinForms.UnitTests
{
    [TestClass]
    public class ModelBinderTests
    {
        private class BindingSource : PresentationModelBase
        {
            private string _sourceProperty;
            public String SourceProperty
            {
                get { return _sourceProperty; }
                set
                {
                    _sourceProperty = value;
                    RaisePropertyChanged(() => SourceProperty);
                }
            }
        }

        [TestMethod]
        public void ModelBinder_Bind_IsBound()
        {
            var form = new Form();
            var target = new TextBox();
            form.Controls.Add(target);
            form.Show();
            var source = new BindingSource();
            ModelBinder.Bind(() => target.Text, () => source.SourceProperty);
            const string changed = "changed";
            source.SourceProperty = changed;
            Assert.AreEqual(changed, target.Text);
        }
    }
}
