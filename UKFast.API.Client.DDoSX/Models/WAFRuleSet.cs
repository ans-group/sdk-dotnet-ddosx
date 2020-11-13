using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX WAF rule set
    /// </summary>
    public class WAFRuleSet : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("active")]
        public bool Active { get; set; }
    }
}