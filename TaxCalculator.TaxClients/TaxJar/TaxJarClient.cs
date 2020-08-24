using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TaxCalculator.TaxClients.Interface;
using TaxCalculator.Common.Models;
using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaxCalculator.Common.Models.Response.TaxJar;
using System.Configuration;
namespace TaxCalculator.TaxClients.TaxJar
{
    public class TaxJarClient : IClient
    {
        internal RestClient apiClient;
        public string ApiToken { get; set; }
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public TaxJarClient()

        {
            ApiToken = ConfigurationManager.AppSettings["TajJarApiKey"] != null ? ConfigurationManager.AppSettings["TajJarApiKey"].ToString() : "";
            ApiVersion =ConfigurationManager.AppSettings["TaxJarApiVersion"].ToString() != null ? ConfigurationManager.AppSettings["TaxJarApiVersion"].ToString() : "";

            ApiUrl = ConfigurationManager.AppSettings["TajJarApiUrl"].ToString() != null ? ConfigurationManager.AppSettings["TajJarApiUrl"].ToString() : "";
            
            if (string.IsNullOrWhiteSpace(ApiToken))
            {
                throw new ArgumentException("Please provide a TaxJar API key.", nameof(ApiToken));
            }

            if (string.IsNullOrWhiteSpace(ApiVersion))
            {
                throw new ArgumentException("Please provide a TaxJar API Version.", nameof(ApiVersion));
            }

            if (string.IsNullOrWhiteSpace(ApiUrl))
            {
                throw new ArgumentException("Please provide a TaxJar API Url.", nameof(ApiUrl));
            }

            ApiUrl = ApiUrl + "/" + ApiVersion + "/";
            Headers = new Dictionary<string, string>();


            apiClient = new RestClient(ApiUrl);
            
        }            

        protected virtual RestRequest CreateRequest(string action, Method method = Method.POST, object body = null)
        {
            var request = new RestRequest(action, method)
            {
                RequestFormat = DataFormat.Json
            };
            var includeBody = new[] { Method.POST }.Contains(method);

            foreach (var header in Headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            request.AddHeader("Authorization", "Bearer " + ApiToken);

            if (body != null)
            {                
                request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            }
            return request;
        }

        protected virtual T SendRequest<T>(string endpoint, object body = null, Method httpMethod = Method.POST) where T : new()
        {
            var request = CreateRequest(endpoint, httpMethod, body);
            var response = apiClient.Execute<T>(request);

            if ((int)response.StatusCode >= 400)
            {
                var error = JsonConvert.DeserializeObject<TaxJarError>(response.Content);
                var errorMessage = error.Error + " - " + error.Detail;

                throw new Exception("Bad Request" + errorMessage);
            }
           
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public Rate GetLocationTaxRates(string zipCode, object locationInfo = null)
        {
            
            var response = SendRequest<RateResponse>("rates/" + zipCode, null, Method.GET);

            return response.Rate;
        }

        public Tax CalculateOrderTaxes(object orderInfo)
        {
            var response = SendRequest<TaxResponse>("taxes", orderInfo, Method.POST);
           
            return response.Tax;
        }
        
    }
}