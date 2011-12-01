using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LessonsLearned.DomainModel.Validation
{
    public class MustBeTitleCaseAttribute : ValidationAttribute
    {
        public MustBeTitleCaseAttribute() : 
            base("{0} must start with uppercase")
        {
        }

        public override bool IsValid(object value)
        {
            var strValue = value as string;
            if (String.IsNullOrEmpty(strValue))
                return false;

            return Char.IsUpper(strValue[0]);
        }

    }
}
