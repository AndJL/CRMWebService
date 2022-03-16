using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Web_Service.Data
{
    public interface ICRMWebAPIService<T>
    {
        Task<T> GetSingleAsync(string entityName, string query);
        Task<IEnumerable<T>> GetAsync(string entityName, string query);
    }
}