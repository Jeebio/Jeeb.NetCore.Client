using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace Jeeb.Client.Models
{
    public class IssueDetailResponse
    {
        [DeserializeAs(Name = "coin")]
        public string Coin { set; get; }

        [DeserializeAs(Name = "address")]
        public string Address { set; get; }

        [DeserializeAs(Name = "rate")]
        public decimal Rate { set; get; }

        [DeserializeAs(Name = "strRate")]
        public string StrRate { set; get; }

        [DeserializeAs(Name = "value")]
        public decimal Value { set; get; }

        [DeserializeAs(Name = "strValue")]
        public string StrValue { set; get; }
    }
}
