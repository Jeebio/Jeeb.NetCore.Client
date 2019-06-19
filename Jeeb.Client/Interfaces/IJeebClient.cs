using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Models;

namespace Jeeb.Client.Interfaces
{
    public interface IJeebClient
    {
        Task<IssueResponse> IssueAsync(IssueRequest request);

        IssueResponse Issue(IssueRequest request);


        Task<StatusResponse> StatusAsync(StatusRequest request);

        StatusResponse Status(StatusRequest request);


        Task<ConfirmResponse> ConfirmAsync(ConfirmRequest request);

        ConfirmResponse Confirm(ConfirmRequest request);


        Task<List<RateResponse>> RatesAsync();

        List<RateResponse> Rates();


        Task<decimal> CurrencyConvertAsync(string baseCurrency, string targetCurrency, decimal value);

        decimal CurrencyConvert(string baseCurrency, string targetCurrency, decimal value);
    }
}