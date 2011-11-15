using System;
using System.Linq.Expressions;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using Rhino.Mocks;

namespace LessonsLearned.PresentationModel.UnitTests
{
    [TestClass]
    public class PresentationModelBaseTests
    {
        private class PresentationModel : PresentationModelBase
        {
            public String AString { get; set; }
            public void TesteableRaisePropertyChanged(String propertyName)
            {
                RaisePropertyChanged(propertyName);
            }
            public void TesteableRaisePropertyChanged<TProperty>(Expression<Func<TProperty>> expression)
            {
                RaisePropertyChanged(expression);
            }
        }

        public interface IPresentationModelObserver
        {
            void NotifyPropertyChangedHandler(object sender, PropertyChangedEventArgs eventArgs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "When raising property changed passing an unexisting property name, an ArgumentOutOfRangeException shall be thrown")]
        public void RaisePropertyChanged_WithUnexistingPropertyName_ThrowsArgumentOutOfRangeException()
        {
            const string unexistingPropertyName = "unexistingPropertyName";
            var presentationModel = new PresentationModel();
            presentationModel.TesteableRaisePropertyChanged(unexistingPropertyName);
        }

        [TestMethod]
        public void RaisePropertyChanged_WithExistingPropertyName_RaisesPropertyChangedEvent()
        {
            const string existingPropertyName = "AString";
            var presentationModel = new PresentationModel();
            var observer = MockRepository.GenerateMock<IPresentationModelObserver>();
            presentationModel.PropertyChanged += observer.NotifyPropertyChangedHandler;
            presentationModel.TesteableRaisePropertyChanged(existingPropertyName);
            observer.AssertWasCalled(o => o.NotifyPropertyChangedHandler(
                Arg<Object>.Is.Equal(presentationModel),
                Arg<PropertyChangedEventArgs>.Matches(e => e.PropertyName.Equals(existingPropertyName))));
        }

        [TestMethod]
        public void RaisePropertyChanged_WithExpression_RaisesPropertyChangedEvent()
        {
            const string existingPropertyName = "AString";
            var presentationModel = new PresentationModel();
            var observer = MockRepository.GenerateMock<IPresentationModelObserver>();
            presentationModel.PropertyChanged += observer.NotifyPropertyChangedHandler;
            presentationModel.TesteableRaisePropertyChanged(() => presentationModel.AString);
            observer.AssertWasCalled(o => o.NotifyPropertyChangedHandler(
                Arg<Object>.Is.Equal(presentationModel),
                Arg<PropertyChangedEventArgs>.Matches(e => e.PropertyName.Equals(existingPropertyName))));
        }
    }
}
