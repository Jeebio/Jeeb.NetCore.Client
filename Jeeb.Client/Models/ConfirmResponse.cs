using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace Jeeb.Client.Models
{
    public class ConfirmResponse
    {
        [DeserializeAs(Name = "orderNo")]
        public string OrderNo { set; get; }

        [DeserializeAs(Name = "referenceNo")]
        public string ReferenceNo { set; get; }

        [DeserializeAs(Name = "stateId")]
        public short StateId { set; get; }
        
        [DeserializeAs(Name = "coin")]
        public string Coin { set; get; }
        
        [DeserializeAs(Name = "baseValue")]
        public decimal BaseValue { set; get; }

        [DeserializeAs(Name = "value")]
        public decimal? Value { set; get; }

        [DeserializeAs(Name = "paidValue")]
        public decimal? PaidValue { set; get; }

        [DeserializeAs(Name = "rate")]
        public decimal? Rate { set; get; }

        [DeserializeAs(Name = "isConfirmed")]
        public bool IsConfirmed { set; get; }

        [DeserializeAs(Name = "finalizedTime")]
        public DateTime? FinalizedTime { set; get; }

        [DeserializeAs(Name = "expirationTime")]
        public DateTime ExpirationTime { set; get; }
    }
}
