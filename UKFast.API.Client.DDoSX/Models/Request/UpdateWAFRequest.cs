using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF patch request
    /// </summary>
    public class UpdateWAFRequest
    {
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string WAFMode { get; set; }

        [JsonProperty("paranoia_level", NullValueHandling = NullValueHandling.Ignore)]
        public string ParanoiaLevel { get; set; }
    }
}