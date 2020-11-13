using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX SSL
    /// </summary>
    public class SSL : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("ukfast_ssl_id")]
        public int UKFastSSLID { get; set; }

        [Newtonsoft.Json.JsonProperty("domains")]
        public string[] Domains { get; set; }

        [Newtonsoft.Json.JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
    }
}