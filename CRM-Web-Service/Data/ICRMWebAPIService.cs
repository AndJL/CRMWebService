using CRM_Web_Service.QueryBuilders.Definitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_Service.Data
{
    public interface ICRMWebAPIService<T>
    {
        Task<T> GetSingleAsync(string entityName, FilterDefinition<T> filter);
        Task<IEnumerable<T>> GetAsync(string entityName, FilterDefinition<T> filter);
    }
}