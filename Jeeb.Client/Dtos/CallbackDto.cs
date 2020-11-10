using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jeeb.Client.Dtos
{
    public class CallbackDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentType Type { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentState State { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentMode Mode { set; get; }
        
        public string ReferenceNo { get; set; }

        public string OrderNo { get; set; }
        
        public string BaseCurrencyId { set; get; }

        public decimal? BaseAmount { get; set; }
        
        public string PaidCurrencyId { set; get; }

        public decimal? CheckAmount { set; get; }

        public decimal? PaidAmount { set; get; }
        
        public string Address { set; get; }
        
        public string TransactionId { set; get; }
        
        public bool Refund { set; get; }
    }
}