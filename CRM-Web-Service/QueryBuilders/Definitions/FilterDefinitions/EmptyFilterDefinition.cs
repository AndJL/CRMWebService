using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Web_Service.QueryBuilders.Definitions.FilterDefinitions
{
    public sealed class EmptyFilterDefinition<T> : FilterDefinition<T>
    {
        public override string Render()
        {
            return string.Empty;
        }
    }
}