using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using LessonsLearned.DomainModel.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonsLearned.DomainModel.UnitTests
{
    [TestClass]
    public class MustBeTitleCaseValidatorTests
    {
        [TestMethod]
        public void MustBeTitleCaseValidator_FirstLetterLowercase_NotValid()
        {
            var attrib = new MustBeTitleCaseAttribute();

            Assert.IsFalse(attrib.IsValid("this is invalid"));
        }

        [TestMethod]
        public void MustBeTitleCaseValidator_FirstLetterUppercase_IsValid()
        {        
            var attrib = new MustBeTitleCaseAttribute();

            Assert.IsTrue(attrib.IsValid("This is valid"));
        }

        [TestMethod]
        public void MustBeTitleCaseValidator_Null_NotValid()
        {
            var attrib = new MustBeTitleCaseAttribute();
            Assert.IsFalse(attrib.IsValid(null));
        }

        [TestMethod]
        public void MustBeTitleCaseValidator_EmptyString_NotValid()
        {
            var attrib = new MustBeTitleCaseAttribute();
            Assert.IsFalse(attrib.IsValid(String.Empty));
        }

        [TestMethod]
        public void MustBeTitleCaseValidator_NonStringValue_NotValid()
        {
            var attrib = new MustBeTitleCaseAttribute();

            Assert.IsFalse(attrib.IsValid(new DateTime(2001,09,10)));
            Assert.IsFalse(attrib.IsValid(210));
            Assert.IsFalse(attrib.IsValid(new List<string>{"Hello", "World"}));
        }


        [TestMethod]
        public void MustBeTitleCaseValidator_ErrorMessage()
        {
            var attrib = new MustBeTitleCaseAttribute();

            Assert.AreEqual("Field must start with uppercase", attrib.FormatErrorMessage("Field"));
        }


    }
}