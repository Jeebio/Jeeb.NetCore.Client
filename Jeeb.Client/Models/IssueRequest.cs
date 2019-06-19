using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jeeb.Client.Models
{
    public class IssueRequest
    {
        [JsonProperty("orderNo")]
        public string OrderNo { set; get; }

        [JsonProperty("value")]
        public decimal Value { set; get; }

        [JsonProperty("coins")]
        public string Coins { set; get; } = "btc";

        [JsonProperty("callbackUrl")]
        public string CallbackUrl { set; get; }

        [JsonProperty("webhookUrl")]
        public string WebhookUrl { set; get; }

        [JsonProperty("language")]
        public string Language { set; get; }

        [JsonProperty("allowReject")]
        public bool AllowReject { set; get; } = true;

        [JsonProperty("allowTestNet")]
        public bool AllowTestNet { set; get; }

        [JsonProperty("expiration")]
        public int? Expiration { set; get; } = 15;
    }
}
