using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp.Deserializers;

namespace Jeeb.Client.Dtos
{
    public class RateDto
    {
        public string Id { set; get; }

        public string BaseCurrencyId { set; get; }

        public string TargetCurrencyId { set; get; }

        public string BaseCurrencyName { set; get; }

        public string TargetCurrencyName { set; get; }

        public int BaseCurrencyPrecision { set; get; }

        public int TargetCurrencyPrecision { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.CurrencyType BaseCurrencyType { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.CurrencyType TargetCurrencyType { set; get; }

        
        public decimal BuyRate { set; get; }

        public decimal SellRate { set; get; }
        public decimal AverageRate { set; get; }


        public double? Change24 { set; get; }

        public override string ToString()
        {
            return $"[{Id}(~{AverageRate})]";
        }
    }
}
