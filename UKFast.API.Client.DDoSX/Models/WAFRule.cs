using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX WAF rule
    /// </summary>
    public class WAFRule : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("uri")]
        public string URI { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public string IP { get; set; }
    }
}