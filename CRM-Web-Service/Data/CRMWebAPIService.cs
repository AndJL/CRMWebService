using CRM_Web_Service.Exception;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRM_Web_Service.Data
{
    public class CRMWebAPIService<T> : ICRMWebAPIService<T>
    {
        private readonly ILogger<CRMWebAPIService<T>> _logger;
        private readonly HttpClient _httpClient;
        public CRMWebAPIService(ILogger<CRMWebAPIService<T>> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _httpClient = clientFactory.CreateClient("ServiceClient");
        }

        public async Task<IEnumerable<T>> GetAsync(string entityName, string queryOptions)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entityName))
                    throw new ArgumentException("Request is missing entityName");
                if (string.IsNullOrWhiteSpace(queryOptions))
                    throw new ArgumentException("Request is missing query");

                var response = await GETResponse(entityName, queryOptions);

                return response.Value;
            }
            catch(System.Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new BadRequestException(e.Message);
            }
        }

        public async Task<T> GetSingleAsync(string entityName, string queryOptions)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(entityName))
                    throw new ArgumentException("Request is missing entityName");
                if (string.IsNullOrWhiteSpace(queryOptions))
                    throw new ArgumentException("Request is missing query");

                var response = await GETResponse(entityName, queryOptions);

                return response.Value.First();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new BadRequestException(e.Message);
            }
        }

        private async Task<GETResponse<T>> GETResponse(string entityName, string queryOptions)
        {
            try
            {
                _logger.LogInformation($"GET request: EntityName: {entityName}, queryOptions: {queryOptions}");

                var response = await _httpClient.GetAsync($"{entityName}?{queryOptions}");
                var responseMsg = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError(responseMsg);
                }
                var jsonObj = JsonConvert.DeserializeObject<GETResponse<T>>(responseMsg, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                return jsonObj;
            }
            catch(System.Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new BadRequestException(e.Message);
            }
        }
    }

    public class GETResponse<T>
    {
        [JsonProperty("@odata.context")]
        public string Context { get; set; }
        [JsonProperty("value")]
        public T[] Value { get; set; }

    }
}