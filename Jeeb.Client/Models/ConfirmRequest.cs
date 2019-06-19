using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jeeb.Client.Models
{
    public class ConfirmRequest
    {
        [JsonProperty("token")]
        public string Token { set; get; }
    }
}
