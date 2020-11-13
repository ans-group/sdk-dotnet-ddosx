using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX HSTS rule patch request
    /// </summary>
    public class UpdateHSTSRuleRequest
    {
        [JsonProperty("max_age", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAge { get; set; }

        [JsonProperty("preload", NullValueHandling = NullValueHandling.Ignore)]
        public bool Preload { get; set; }

        [JsonProperty("include_subdomains", NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeSubdomains { get; set; }
    }
}