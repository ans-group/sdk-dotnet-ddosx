using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents the content of a DDoSX SSL
    /// </summary>
    public class SSLContent : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("certificate")]
        public string Certificate { get; set; }

        [Newtonsoft.Json.JsonProperty("ca_bundle")]
        public string CABundle { get; set; }

    }
}