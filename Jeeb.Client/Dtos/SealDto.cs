using Newtonsoft.Json;

namespace Jeeb.Client.Dtos
{
    public class SealDto
    {
        [JsonProperty("token")]
        public string Token { set; get; }
    }
}
