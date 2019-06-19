using Xunit;
using Jeeb.Client.Interfaces;
using Jeeb.Client.Models;
using Jeeb.Client.Services;
using Jeeb.Client.Test.Tools;

namespace Jeeb.Client.Test
{
    public class JeebClientTests
    {
        private const string Signature = "PWJWH6IDVKL7HNBF5JMQL2SOAI2XBNPQASKWB2CVSL6C4OXAUXVQ";

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
                AllowTestNet = true,
                Language = "auto",
                CallbackUrl = "https://webhook.site/56eba40c-9a52-4161-834a-9cceb58cd910",
                WebhookUrl = "https://webhook.site/56eba40c-9a52-4161-834a-9cceb58cd910",
                Expiration = 30
            };

            var issueResponse = _jeebClient.Issue(issueRequest);
            Assert.NotNull(issueResponse);
            Assert.NotNull(issueResponse.Addresses);
        }

        [Fact]
        public void StatusTest()
        {
            var statusRequest = new StatusRequest
            {
                Token = "LNQE25SCAZD2NMCALMFDQH7434NGVEITVKSZ2UU2BVWA6PCVSWORPTTWWXWZ2UIIL24OZ5MVVQN7TMA2BWVOLBQ7O6XODZJF3KC6I6QPED4D2VK7CYDFALARGKCAY5Y5Q"
            };

            var issueResponse = _jeebClient.Status(statusRequest);
            Assert.NotNull(issueResponse);
        }

        [Fact]
        public void ConfirmTest()
        {
            var confirmRequest = new ConfirmRequest()
            {
                Token = "LNQE25SCAZD2NMCALMFDQH7434NGVEITVKSZ2UU2BVWA6PCVSWORPTTWWXWZ2UIIL24OZ5MVVQN7TMA2BWVOLBQ7O6XODZJF3KC6I6QPED4D2VK7CYDFALARGKCAY5Y5Q"
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
