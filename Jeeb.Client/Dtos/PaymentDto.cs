using System;
using System.Collections.Generic;
using Jeeb.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Jeeb.Client.Dtos
{
    public class PaymentDto
    {
        public long Id { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentType Type { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentState State { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentMode Mode { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Constants.PaymentClient Client { set; get; }


        public string ReferenceNo { get; set; }

        public string OrderNo { get; set; }

        public string Language { set; get; }

        public string PayableCoins { set; get; }


        public string WebhookUrl { get; set; }

        public string CallbackUrl { get; set; }


        public string BaseCurrencyId { set; get; }

        public decimal? BaseAmount { get; set; }

        public decimal? BaseBtcAmount { set; get; }



        public string PaidCurrencyId { set; get; }

        public decimal? CheckAmount { set; get; }

        public decimal? PaidAmount { set; get; }

        public decimal? PaidBtcAmount { set; get; }


        public bool IsSealed { set; get; }

        public DateTime? SealTime { get; set; }


        public int? Expiration { set; get; }

        public bool AllowReject { get; set; }

        public bool AllowTestNets { set; get; }


        public bool Refund { set; get; }

             
        public DateTime? ExpirationTime { set; get; }

        public DateTime? CompletionTime { set; get; }

        public DateTime CreationTime { get; set; }

        public List<PaymentDetail> Details { set; get; }

        public string Token { set; get; }
    }
}