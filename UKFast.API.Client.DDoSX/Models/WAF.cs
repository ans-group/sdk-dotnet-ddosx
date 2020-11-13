using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX WAF configuration
    /// </summary>
    public class WAF : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("mode")]
        public string Mode { get; set; }

        [Newtonsoft.Json.JsonProperty("paranoia_level")]
        public string ParanoiaLevel { get; set; }
    }
}