using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX IP ACL rule mode patch request.
    /// </summary>
    public class UpdateACLGeoIPRulesModeRequest
    {
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }
    }
}