using CRM_Web_Service.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CRM_Web_Service.ServiceCollectionExtension
{
    public static class CRMWebAPIServiceCollectionExtension
    {

        public static void AddCRMWebAPI(this IServiceCollection services, string baseUrl, NetworkCredential credential)
        {
            services.AddHttpClient("ServiceClient", c =>
             {
                 c.BaseAddress = new Uri(baseUrl);

             }).ConfigurePrimaryHttpMessageHandler(() =>
             {
                 return new HttpClientHandler()
                 {
                     UseDefaultCredentials = true,
                     Credentials = credential
                 };
             });
        }
    }

    public class CRMWebAPIConfigOptions
    {
        public Uri BaseUrl { get; set; }
        public NetworkCredential Credential { get; set; }
    }
}