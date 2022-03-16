using System;
using System.Linq.Expressions;

namespace CRM_Web_Service.QueryBuilders.Definitions.FilterDefinitions
{
    public class ExpressionEqualFilterDefinition<TField, TValue> : FilterDefinition<TField>
    {
        private readonly Expression<Func<TField, TValue>> _expression;
        private readonly TValue _value;

        public ExpressionEqualFilterDefinition(Expression<Func<TField, TValue>> expression, TValue value)
        {
            _expression = expression;
            _value = value;
        }

        public override string Render()
        {
            MemberExpression memberExpr = (MemberExpression)_expression.Body;
            string memberName = memberExpr.Member.Name.ToLower();

            string returnString = $"$filter={memberName} eq ";

            if(_value.GetType() == typeof(int))
            {
                returnString += $"{_value}";
            }
            else
            {
                returnString += $"'{_value}'";
            }

            return returnString;
        }
    }
}