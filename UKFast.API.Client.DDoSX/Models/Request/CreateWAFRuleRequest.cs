using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF rule create request
    /// </summary>
    public class CreateWAFRuleRequest
    {
        [JsonProperty("uri", Required = Required.Always)]
        public string URI { get; set; }

        [JsonProperty("ip", Required = Required.Always)]
        public string IP { get; set; }
    }
}