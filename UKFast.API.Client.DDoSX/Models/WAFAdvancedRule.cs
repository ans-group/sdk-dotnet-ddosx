using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX WAF advanced rule
    /// </summary>
    public class WAFAdvancedRule : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("section")]
        public string Section { get; set; }

        [Newtonsoft.Json.JsonProperty("modifier")]
        public string Modifier { get; set; }

        [Newtonsoft.Json.JsonProperty("phrase")]
        public string Phrase { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string IP { get; set; }
    }
}