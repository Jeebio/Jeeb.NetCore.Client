using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jeeb.Client.Dtos
{
    public class IssueDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentType Type { set; get; } = Constants.DefaultPaymentType;

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentMode Mode { set; get; } = Constants.DefaultPaymentMode;

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentClient Client { set; get; } = Constants.DefaultPaymentClient;

        public string OrderNo { set; get; }

        public string Language { set; get; }
        

        public string PayableCoins { set; get; }

        public string WebhookUrl { set; get; }
        public string CallbackUrl { set; get; }


        public string BaseCurrencyId { set; get; }

        public decimal? BaseAmount { set; get; }


        public int? Expiration { set; get; } = Constants.DefaultExpiration;

        public bool AllowReject { set; get; } = Constants.DefaultAllowReject;

        public bool AllowTestNets { set; get; } = Constants.DefaultAllowTestNets;
    }
}
