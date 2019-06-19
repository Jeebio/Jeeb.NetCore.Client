using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace Jeeb.Client.Models
{
    public class RateResponse
    {
        [DeserializeAs(Name = "pair")]
        public string Pair { set; get; }

        [DeserializeAs(Name = "sellRate")]
        public decimal SellRate { set; get; }

        [DeserializeAs(Name = "buyRate")]
        public decimal BuyRate { set; get; }

        [DeserializeAs(Name = "averageRate")]
        public decimal AverageRate { set; get; }

        [DeserializeAs(Name = "change")]
        public double? Change { set; get; }
    }
}
