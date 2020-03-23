using System;
using System.Net.Http;
using COVIDsStat.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace COVIDsStat.Connectivity.Api
{
    public class ApiService:IApiService
    {
        private readonly string _apiBaseAddress;
        private readonly HttpClient _client;

        public ICOVIDApi COVIDApi { get; set; }
        public ApiService()
        {
            _apiBaseAddress = GetUrl();

            _client = _client ?? new HttpClient()
            {
                BaseAddress = new Uri(_apiBaseAddress),
                Timeout = TimeSpan.FromSeconds(20)
            };

            COVIDApi = RestService.For<ICOVIDApi>(_client, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            });
        }
        private string GetUrl()
        {
            var urlAttribute = (UrlAttribute)Attribute.GetCustomAttribute(typeof(ICOVIDApi), typeof(UrlAttribute));

            return urlAttribute.Url;
        }
    }
}
