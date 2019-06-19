using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace Jeeb.Client.Models
{
    public class IssueResponse
    {
        [DeserializeAs(Name = "referenceNo")]
        public string ReferenceNo { get; set; }

        [DeserializeAs(Name = "addresses")]
        public List<IssueDetailResponse> Addresses { get; set; }

        [DeserializeAs(Name = "expirationTime")]
        public DateTime ExpirationTime { set; get; }

        [DeserializeAs(Name = "token")]
        public string Token { set; get; }
    }
}
