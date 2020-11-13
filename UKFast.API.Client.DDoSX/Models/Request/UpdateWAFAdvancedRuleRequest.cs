using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF advanced rule patch request
    /// </summary>
    public class UpdateWAFAdvancedRuleRequest
    {
        [JsonProperty("section", NullValueHandling = NullValueHandling.Ignore)]
        public string Section { get; set; }

        [JsonProperty("modifier", NullValueHandling = NullValueHandling.Ignore)]
        public string Modifier { get; set; }

        [JsonProperty("phrase", NullValueHandling = NullValueHandling.Ignore)]
        public string Phrase { get; set; }

        [JsonProperty("ip", NullValueHandling = NullValueHandling.Ignore)]
        public string IP { get; set; }
    }
}