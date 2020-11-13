using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF rule set patch request
    /// </summary>
    public class UpdateWAFRuleSetRequest
    {
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        public bool Active { get; set; }
    }
}