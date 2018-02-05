using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YouBikeApi.Models
{
    public class YouBikeOriginalModel
    {
        [JsonProperty("retCode")]
        public int RetuenCode { get; set; }

        [JsonProperty("retVal")]
        public JObject ReturnValue { get; set; }
    }
}