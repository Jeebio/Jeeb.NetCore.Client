using System;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Dtos;
using Jeeb.Client.Exceptions;
using RestSharp;

namespace Jeeb.Client.Common
{
    public abstract class BaseClient
    {
        private readonly RestClient _client;
        private readonly Uri _baseUri;

        protected BaseClient(string baseUrl)
        {
            _baseUri = new Uri(baseUrl, UriKind.Absolute);
            _client = new RestClient(_baseUri)
            {
                Encoding = Encoding.UTF8
            };
        }

        protected BaseClient(string baseUrl, string apiKey)
            : this(baseUrl)
        {
            _client.Authenticator = new BaseClientAuthenticator(apiKey);
        }

        protected RestRequest BuildRequest<T>(string url, T data, Method method)
        {
            var request = new RestRequest(new Uri(_baseUri, url), method, DataFormat.Json)
            {
                JsonSerializer = new JsonSerializer()
            };
            request.AddJsonBody(data);
            return request;
        }

        protected RestRequest BuildRequest(string url, Method method)
        {
            var request = new RestRequest(new Uri(_baseUri, url), method, DataFormat.Json)
            {
                JsonSerializer = new JsonSerializer()
            };
            return request;
        }

        protected async Task<T> ExecuteRequestAsync<T>(IRestRequest request) where T : Response, new()
        {
            var response = await _client.ExecuteAsync<T>(request);
            return HandleResponse(response);
        }

        private T HandleResponse<T>(IRestResponse<T> response) where T : Response, new()
        {
            if (response.IsSuccessful && response.Data?.Succeed == true)
            {
                return response.Data;
            }

            if (response.Data != null)
            {
                throw new RequestFailedException(response.Data);
            }

            throw new RequestFailedException(response.Content ?? response.ErrorMessage);
        }
    }
}