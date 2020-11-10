using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jeeb.Client.Dtos
{
    public class PaymentDetail
    {
        public int Index { set; get; }

        public string CurrencyId { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentDetailState State { set; get; }

        public string Address { set; get; }

        public string TransactionId { set; get; }

        
        public decimal? Amount { set; get; }

        public decimal? PaidAmount { set; get; }


        public decimal Rate { set; get; }
    }
}