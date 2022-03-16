using CRM_Web_Service.Models;

namespace CRM_Web_Service.QueryBuilders
{
    public class CRMQueryBuilder<T> where T : BaseProxyClass
    {
        public static FilterDefinitionBuilder<T> Filter => new FilterDefinitionBuilder<T>();
    }
}