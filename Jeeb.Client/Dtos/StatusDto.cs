using Newtonsoft.Json;

namespace Jeeb.Client.Dtos
{
    public class StatusDto
    {
        [JsonProperty("token")]
        public string Token { set; get; }
    }
}
