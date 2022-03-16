using CRM_Web_Service.QueryBuilders.Definitions;
using CRM_Web_Service.QueryBuilders.Definitions.FilterDefinitions;
using System;
using System.Linq.Expressions;

namespace CRM_Web_Service.QueryBuilders
{
    public sealed class FilterDefinitionBuilder<T>
    {
        public FilterDefinition<T> Empty => FilterDefinition<T>.Empty;

        public FilterDefinition<T> Eq<TValue>(Expression<Func<T, TValue>> field, TValue value)
        {
            return new ExpressionEqualFilterDefinition<T, TValue>(field, value);
        }
        public FilterDefinition<T> Eq(string property, string value)
        {
            return new EqualFilterDefinition<T>(property, value);
        }
    }
}