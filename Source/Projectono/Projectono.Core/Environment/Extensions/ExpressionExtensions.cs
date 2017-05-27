using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq.Expressions
{
    public static class ExpressionExtensions
    {
        public static MemberInfo GetMember(this Expression expression) {
            while (expression != null && expression is UnaryExpression) expression = ((UnaryExpression)expression).Operand;
            var memberExpression = expression as MemberExpression;
            if (memberExpression == null) throw new InvalidCastException("expression must evaluate to a MemberExpression");
            return memberExpression.Member;
        }
    }
}
