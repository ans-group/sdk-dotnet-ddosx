using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSC HSTS rule create request
    /// </summary>
    public class CreateHSTSRuleRequest
    {
        [JsonProperty("max_age")]
        public int MaxAge { get; set; }

        [JsonProperty("preload")]
        public bool Preload { get; set; }

        [JsonProperty("include_subdomains")]
        public bool IncludeSubdomains { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("record_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RecordName { get; set; }
    }
}