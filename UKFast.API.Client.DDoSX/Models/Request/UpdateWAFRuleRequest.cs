using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF rule patch request
    /// </summary>
    public class UpdateWAFRuleRequest
    {
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string URI { get; set; }

        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }
    }
}