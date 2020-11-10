using Jeeb.Client.Common;
using Jeeb.Client.Dtos;
using Xunit;
using Jeeb.Client.Interfaces;
using Jeeb.Client.Services;

namespace Jeeb.Client.Test
{
    public class JeebClientTests
    {
        private const string ApiKey = "kvmJOGGukdcU9pqoVqrTd31YENcs2eVBg";

        private readonly IJeebPaymentClient _paymentClient;
        private readonly IJeebMarketClient _marketClient;

        public JeebClientTests()
        {
            _paymentClient = new JeebPaymentClient(ApiKey);
            _marketClient = new JeebMarketClient();
        }

        [Fact]
        public void IssueRestrictedTest()
        {
            const decimal baseAmount = 100M;
            var input = new IssueDto
            {
                OrderNo = "SAMPLE_ORDER",

                Type = Constants.PaymentType.Restricted,
                BaseAmount = baseAmount,
                BaseCurrencyId = "USD",

                CallbackUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2",
                WebhookUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2"
            };

            var payment = _paymentClient.Issue(input);
            Assert.Equal(payment.BaseAmount, baseAmount);
        }


        [Fact]
        public void IssueArbitraryTest()
        {
            var input = new IssueDto
            {
                OrderNo = "SAMPLE_ORDER",

                Type = Constants.PaymentType.Arbitrary,

                CallbackUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2",
                WebhookUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2"
            };

            var payment = _paymentClient.Issue(input);
            Assert.Null(payment.BaseAmount);
        }

        [Fact]
        public void IssueBtcAndLtcOnlyTest()
        {
            const decimal baseAmount = 100M;
            var input = new IssueDto
            {
                OrderNo = "SAMPLE_ORDER",

                PayableCoins = "BTC/LTC",

                BaseAmount = baseAmount,
                BaseCurrencyId = "USD",

                CallbackUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2",
                WebhookUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2"
            };

            var payment = _paymentClient.Issue(input);
            Assert.Equal(2, payment.Details.Count);
        }


        [Fact]
        public void IssueExternalTest()
        {
            const decimal baseAmount = 100M;
            var input = new IssueDto
            {
                OrderNo = "SAMPLE_ORDER",

                Client = Constants.PaymentClient.External,

                BaseAmount = baseAmount,
                BaseCurrencyId = "USD",

                CallbackUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2",
                WebhookUrl = "https://webhook.site/61644883-020e-4827-8d33-2a8541bffba2"
            };

            var payment = _paymentClient.Issue(input);
            Assert.All(payment.Details, detail =>
            {
                Assert.NotNull(detail.Address);
                Assert.Equal(Constants.PaymentDetailState.Deployed, detail.State);
            });
        }


        [Fact]
        public void StatusTest()
        {
            var input = new StatusDto
            {
                Token = "YOUR_PAYMENT_TOKEN"
            };

            var payment = _paymentClient.Status(input);
            Assert.NotNull(payment);
        }

        [Fact]
        public void SealTest()
        {
            var input = new SealDto()
            {
                Token = "YOUR_PAYMENT_TOKEN"
            };

            var payment = _paymentClient.Seal(input);
            Assert.NotNull(payment);
        }
    }
}