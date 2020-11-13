using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX CDN rule patch request
    /// </summary>
    public class UpdateCDNRuleRequest
    {
        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string URI { get; set; }

        [JsonProperty("cache_control", NullValueHandling = NullValueHandling.Ignore)]
        public string CacheControl { get; set; }

        [JsonProperty("cache_control_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string CacheControlDuration { get; set; } 

        [JsonProperty("mime_types", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MimeTypes { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}