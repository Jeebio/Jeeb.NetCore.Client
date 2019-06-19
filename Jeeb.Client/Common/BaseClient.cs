using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Exceptions;
using Jeeb.Client.Models;
using RestSharp;

namespace Jeeb.Client.Common
{
    public abstract class BaseClient
    {
        private readonly RestClient _restClient;
        private readonly Uri _baseUri;


        protected BaseClient(string baseUrl)
        {
            _baseUri = new Uri(baseUrl, UriKind.Absolute);
            _restClient = new RestClient(_baseUri)
            {
                Encoding = Encoding.UTF8
            };
        }


        protected T WrappedExecute<T>(IRestRequest request, Method method) where T : class, new()
        {
            var result = _restClient.Execute<Response<T>>(request, method);
            if (result.IsSuccessful && result.Data?.HasError != true)
            {
                return result.Data?.Result;
            }

            throw new JeebRequestFailedException(result.Data?.ErrorMessage ?? result.ErrorMessage,
                result.Data?.ErrorCode,
                (int)result.StatusCode);
        }

        protected async Task<T> WrappedExecuteAsync<T>(IRestRequest request) where T : class, new()
        {
            var result = await _restClient.ExecuteTaskAsync<Response<T>>(request);
            if (result.IsSuccessful && result.Data?.HasError != true)
            {
                return result.Data?.Result;
            }

            throw new JeebRequestFailedException(result.Data?.ErrorMessage ?? result.ErrorMessage,
                result.Data?.ErrorCode,
                (int)result.StatusCode);
        }


        protected T Execute<T>(IRestRequest request, Method method) where T : class, new()
        {
            var result = _restClient.Execute<T>(request, method);
            if (result.IsSuccessful)
            {
                return result.Data;
            }

            throw new JeebRequestFailedException(result.ErrorMessage,
                null,
                (int)result.StatusCode);
        }

        protected async Task<T> ExecuteAsync<T>(IRestRequest request) where T : class, new()
        {
            var result = await _restClient.ExecuteTaskAsync<T>(request);
            if (result.IsSuccessful)
            {
                return result.Data;
            }

            throw new JeebRequestFailedException(result.ErrorMessage,
                null,
                (int)result.StatusCode);
        }


        protected RestRequest GetRequest<T>(string url, T data, Method method)
        {
            var request = new RestRequest(new Uri(_baseUri, url), method, DataFormat.Json)
            {
                JsonSerializer = new CustomJsonSerializer()
            };
            request.AddQueryParameter("culture", CultureInfo.CurrentUICulture.Name);
            request.AddBody(data);
            return request;
        }

        protected RestRequest GetRequest(string url, Method method)
        {
            var request = new RestRequest(new Uri(_baseUri, url), method, DataFormat.Json)
            {
                JsonSerializer = new CustomJsonSerializer()
            };

            request.AddQueryParameter("culture", CultureInfo.CurrentUICulture.Name);
            return request;
        }
    }
}
