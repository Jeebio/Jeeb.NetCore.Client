using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jeeb.Client.Models
{
    public class StatusRequest
    {
        [JsonProperty("token")]
        public string Token { set; get; }
    }
}
