using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jeeb.Client.Dtos;

namespace Jeeb.Client.Interfaces
{
    public interface IJeebPaymentClient
    {
        Task<PaymentDto> IssueAsync(IssueDto input);

        PaymentDto Issue(IssueDto input);


        Task<PaymentDto> StatusAsync(StatusDto input);

        PaymentDto Status(StatusDto input);


        Task<PaymentDto> SealAsync(SealDto input);

        PaymentDto Seal(SealDto input);

        string GetRedirectUrl(string token);
    }
}