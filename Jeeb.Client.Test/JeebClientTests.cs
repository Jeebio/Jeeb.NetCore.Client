using Xunit;
using Jeeb.Client.Interfaces;
using Jeeb.Client.Models;
using Jeeb.Client.Services;
using Jeeb.Client.Test.Tools;

namespace Jeeb.Client.Test
{
    public class JeebClientTests
    {
        private const string Signature = "YOUR_SIGNATURE_GOES_HERE";

        private readonly IJeebClient _jeebClient;

        public JeebClientTests()
        {
            _jeebClient = new JeebClient(Signature);
        }

        [Fact]
        public void IssueTest()
        {
            var issueRequest = new IssueRequest
            {
                OrderNo = RandomUtils.RandomStringGenerator(),
                Value = 0.001M,
                Coins = "tbtc/tltc",
                AllowReject = true,
                AllowTestNet = true,
                Language = "auto",
                CallbackUrl = "https://webhook.site/205a985d-f43e-4b45-8588-dd5047b34bd5",
                WebhookUrl = "https://webhook.site/205a985d-f43e-4b45-8588-dd5047b34bd5",
                Expiration = 30
            };

            var issueResponse = _jeebClient.Issue(issueRequest);
            Assert.NotNull(issueResponse);
            Assert.NotNull(issueResponse.Addresses);
            Assert.NotNull(issueResponse.Token);
            Assert.NotNull(issueResponse.ReferenceNo);
        }

        [Fact]
        public void StatusTest()
        {
            var statusRequest = new StatusRequest
            {
                Token = "PAYMENT_TOKEN"
            };

            var issueResponse = _jeebClient.Status(statusRequest);
            Assert.NotNull(issueResponse);
        }

        [Fact]
        public void ConfirmTest()
        {
            var confirmRequest = new ConfirmRequest()
            {
                Token = "PAYMENT_TOKEN"
            };

            var issueResponse = _jeebClient.Confirm(confirmRequest);
            Assert.NotNull(issueResponse);
        }

        [Fact]
        public void RatesTest()
        {
            var rates = _jeebClient.Rates();
            Assert.NotNull(rates);
            Assert.NotEmpty(rates);
        }


        [Fact]
        public void ConvertTest()
        {
            var btcValue = 1M;
            var ltcValue = _jeebClient.CurrencyConvert("btc", "ltc", btcValue);
            var irrValue = _jeebClient.CurrencyConvert("btc", "irr", btcValue);
            var usdValue = _jeebClient.CurrencyConvert("btc", "usd", btcValue);
            Assert.True(ltcValue > 0);
            Assert.True(irrValue > 0);
            Assert.True(usdValue > 0);
        }
    }
}
