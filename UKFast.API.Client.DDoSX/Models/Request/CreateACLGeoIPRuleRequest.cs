using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX GeoIP ACL rule create request
    /// </summary>
    public class CreateACLGeoIPRuleRequest
    {
        [JsonProperty("code", Required = Required.Always)]
        public string Code { get; set; }
    }
}