using Jeeb.Client.Interfaces;
using Jeeb.Client.Services;
using Xunit;

namespace Jeeb.Client.Test
{
    public class JeebMarketClientTests
    {
        private readonly IJeebMarketClient _marketClient;

        public JeebMarketClientTests()
        {
            _marketClient = new JeebMarketClient();
        }

        [Fact]
        public void CurrenciesTest()
        {
            var currencies = _marketClient.ListCurrencies();

            Assert.NotNull(currencies);
            Assert.NotEmpty(currencies);
        }

        [Fact]
        public void RatesTest()
        {
            var rates = _marketClient.ListRates();
            
            Assert.NotNull(rates);
            Assert.NotEmpty(rates);
        }
    }
}