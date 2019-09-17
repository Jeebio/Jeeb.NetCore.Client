using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jeeb.Client.Models
{
    public class WebhookResponse
    {
        [JsonProperty("attempts")]
        public int Attempts { set; get; }

        [JsonProperty("referenceNo")]
        public string ReferenceNo { set; get; }

        [JsonProperty("orderNo")]
        public string OrderNo { set; get; }

        [JsonProperty("stateId")]
        public short StateId { set; get; }

        [JsonProperty("baseValue")]
        public decimal BaseValue { set; get; }

        [JsonProperty("coin")]
        public string Coin { set; get; }

        [JsonProperty("value")]
        public decimal? Value { set; get; }

        [JsonProperty("paidValue")]
        public decimal? PaidValue { set; get; }

        [JsonProperty("rate")]
        public decimal? Rate { set; get; }

        [JsonProperty("expirationTime")]
        public DateTime ExpirationTime { set; get; }

        [JsonProperty("finalizedTime")]
        public DateTime? FinalizedTime { set; get; }

        [JsonProperty("token")]
        public string Token { set; get; }

        [JsonProperty("signature")]
        public string Signature { set; get; }

        [JsonProperty("webhookUrl")]
        public string WebhookUrl { set; get; }

        [JsonProperty("callbackUrl")]
        public string CallbackUrl { set; get; }
    }
}
