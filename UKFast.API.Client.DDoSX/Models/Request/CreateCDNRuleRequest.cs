using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX CND create request
    /// </summary>
    public class CreateCDNRuleRequest
    {
        [JsonProperty("uri", Required = Required.Always)]
        public string URI { get; set; }

        [JsonProperty("cache_control", Required = Required.Always)]
        public string CacheControl { get; set; }

        [JsonProperty("cache_control_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string CacheControlDuration { get; set; } 

        [JsonProperty("mime_types", Required = Required.Always)]
        public string[] MimeTypes { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }
    }
}