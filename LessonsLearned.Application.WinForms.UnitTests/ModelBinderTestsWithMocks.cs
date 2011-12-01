using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace LessonsLearned.Application.WinForms.UnitTests
{
    [TestClass]
    public class ModelBinderTestsWithMocks
    {
        [TestClass]
        public class ModelBinderTests
        {


            [TestMethod]
            public void ModelBinder_Bind_SourceToTarget()
            {
                var target = new TextBox();
                using (new BindingTestContext(target))
                {
                    var source = MockRepository.GenerateStub<IPropertyChangedAndError>();
                    new ModelBinder().Bind(() => target.Text, () => source.SourceProperty);
                    
                    const string changed = "changed";
                    source.SourceProperty = changed;


                    source.Stub(s => s.RaiseIt(Arg<String>.Is.Equal("SourceProperty"))).WhenCalled((i)=>source.Raise(x => x.PropertyChanged += null, source, new PropertyChangedEventArgs(i.Arguments.OfType<String>().First())));
                    source.RaiseIt("SourceProperty");
                    Assert.AreEqual(changed, target.Text);
                }
            }


            public interface IPropertyChangedAndError : INotifyPropertyChanged, IDataErrorInfo
            {
                String SourceProperty { get; set; }

                void RaiseIt(String propName);
            }

            [TestMethod]
            public void ModelBinder_Bind_TargetToSource()
            {
                var target = new TextBox();
                using (new BindingTestContext(target))
                {
                    var source = MockRepository.GenerateMock<IPropertyChangedAndError>();
                    new ModelBinder().Bind(() => target.Text, () => source.SourceProperty);
                    
                    
                    const string changed = "changed";
                    target.Text = changed;

                    source.AssertWasCalled(s => s["SourceProperty"]);
                }
            }
        }
    }
}
