using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Common;
using Jeeb.Client.Exceptions;
using Jeeb.Client.Interfaces;
using Jeeb.Client.Models;
using RestSharp;

namespace Jeeb.Client.Services
{
    public class JeebClient : BaseClient, IJeebClient
    {

        public const string BaseUrl = "https://core.jeeb.io/";
        public const string IssueUrl = "api/payments/{0}/issue";
        public const string StatusUrl = "api/payments/{0}/status";
        public const string ConfirmUrl = "api/payments/{0}/confirm";
        public const string RatesUrl = "api/currency/complexRates";
        public const string ConvertUrl = "api/currency?base={0}&target={1}&value={2}";

        private readonly string _signature;
        
        public JeebClient(string signature) 
            : base(BaseUrl)
        {
            _signature = signature;
        }

        public async Task<IssueResponse> IssueAsync(IssueRequest request)
        {
            var httpRequest = GetRequest(string.Format(IssueUrl, _signature), request, Method.POST);
            return await WrappedExecuteAsync<IssueResponse>(httpRequest);
        }

        public IssueResponse Issue(IssueRequest request)
        {
            return IssueAsync(request).GetAwaiter().GetResult();
        }

        public async Task<StatusResponse> StatusAsync(StatusRequest request)
        {
            var httpRequest = GetRequest(string.Format(StatusUrl, _signature), request, Method.POST);
            return await WrappedExecuteAsync<StatusResponse>(httpRequest);
        }

        public StatusResponse Status(StatusRequest request)
        {
            return StatusAsync(request).GetAwaiter().GetResult();
        }

        public async Task<ConfirmResponse> ConfirmAsync(ConfirmRequest request)
        {
            var httpRequest = GetRequest(string.Format(ConfirmUrl, _signature), request, Method.POST);
            return await WrappedExecuteAsync<ConfirmResponse>(httpRequest);
        }

        public ConfirmResponse Confirm(ConfirmRequest request)
        {
            return ConfirmAsync(request).GetAwaiter().GetResult();
        }

        public async Task<List<RateResponse>> RatesAsync()
        {
            var httpRequest = GetRequest(RatesUrl, Method.GET);
            return await WrappedExecuteAsync<List<RateResponse>>(httpRequest);
        }

        public List<RateResponse> Rates()
        {
            return RatesAsync().GetAwaiter().GetResult();
        }

        public async Task<decimal> CurrencyConvertAsync(string baseCurrency, string targetCurrency, decimal value)
        {
            var httpRequest = GetRequest(string.Format(ConvertUrl, baseCurrency, targetCurrency, value.ToString("0.00000000")), Method.GET);
            var response = await ExecuteAsync<Response<decimal>>(httpRequest);
            if (response.HasError)
                throw new JeebRequestFailedException(response.ErrorMessage,
                    response.ErrorCode);
            return response.Result;
        }

        public decimal CurrencyConvert(string baseCurrency, string targetCurrency, decimal value)
        {
            return CurrencyConvertAsync(baseCurrency, targetCurrency, value).GetAwaiter().GetResult();
        }
    }
}
