using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace LessonsLearned.Application.WinForms
{
    public class ModelBinder
    {
        public static void Bind<TProperty>(Expression<Func<TProperty>> targetExpression, Expression<Func<TProperty>> sourceExpression)
        {

            var targetAccessor = (MemberExpression)targetExpression.Body;
            var targetObjExpression = targetAccessor.Expression;
            var targetObj = (Control)Expression.Lambda(targetObjExpression, null).Compile().DynamicInvoke(null);
            var targetPropertyName = targetAccessor.Member.Name;

            var sourceAccessor = (MemberExpression)sourceExpression.Body;
            var sourceObjExpression = sourceAccessor.Expression;
            var sourceObj = Expression.Lambda(sourceObjExpression, null).Compile().DynamicInvoke(null);
            var sourcePropertyName = sourceAccessor.Member.Name;

            targetObj.DataBindings.Add(new Binding(targetPropertyName, sourceObj, sourcePropertyName));


        }
    }
}
