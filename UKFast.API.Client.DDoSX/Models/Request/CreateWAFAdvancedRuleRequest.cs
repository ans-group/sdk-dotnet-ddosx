using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF advanced rule create request
    /// </summary>
    public class CreateWAFAdvancedRuleRequest
    {
        [JsonProperty("section", Required = Required.Always)]
        public string Section { get; set; }  // TODO: WAFAdvancedRuleSection type

        [JsonProperty("modifier", Required = Required.Always)]
        public string Modifier { get; set; }  //TODO: WAFAdvancedRuleModifier type

        [JsonProperty("phrase", Required = Required.Always)]
        public string Phrase { get; set; }

        [JsonProperty("ip", Required = Required.Always)]
        public string IP { get; set; }  //TODO: ip validation
    }
}