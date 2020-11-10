using System;
using System.Threading.Tasks;
using Jeeb.Client.Common;
using Jeeb.Client.Dtos;
using Jeeb.Client.Interfaces;
using RestSharp;

namespace Jeeb.Client.Services
{
    public class JeebPaymentClient : BaseClient, IJeebPaymentClient
    {
        const string BaseUrl = "https://core.jeeb.io/api/v3/payments/";

        const string IssueUrl = "issue";
        const string StatusUrl = "status";
        const string SealUrl = "seal";

        public JeebPaymentClient(string apiKey)
            : base(BaseUrl, apiKey)
        {
        }

        public async Task<PaymentDto> IssueAsync(IssueDto input)
        {
            var httpRequest = BuildRequest(IssueUrl, input, Method.POST);
            var response = await ExecuteRequestAsync<Response<PaymentDto>>(httpRequest);
            return response.Result;
        }

        public PaymentDto Issue(IssueDto request)
        {
            return IssueAsync(request).GetAwaiter().GetResult();
        }

        public async Task<PaymentDto> StatusAsync(StatusDto input)
        {
            var httpRequest = BuildRequest(StatusUrl, input, Method.POST);
            var response = await ExecuteRequestAsync<Response<PaymentDto>>(httpRequest);
            return response.Result;
        }

        public PaymentDto Status(StatusDto input)
        {
            return StatusAsync(input).GetAwaiter().GetResult();
        }

        public async Task<PaymentDto> SealAsync(SealDto input)
        {
            var httpRequest = BuildRequest(SealUrl, input, Method.POST);
            var response = await ExecuteRequestAsync<Response<PaymentDto>>(httpRequest);
            return response.Result;
        }

        public PaymentDto Seal(SealDto input)
        {
            return SealAsync(input).GetAwaiter().GetResult();
        }

        public string GetRedirectUrl(string token)
        {
            return $"{BaseUrl}invoice?token={token}";
        }
    }
}