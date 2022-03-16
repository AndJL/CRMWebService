using CRM_Web_Service.QueryBuilders.Definitions.FilterDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Web_Service.QueryBuilders.Definitions
{
    public abstract class FilterDefinition<T>
    {
        public static FilterDefinition<T> Empty { get; } = new EmptyFilterDefinition<T>();

        public abstract string Render();
    }
}