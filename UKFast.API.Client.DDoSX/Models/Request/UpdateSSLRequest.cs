using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX SSL patch request
    /// </summary>
    public class UpdateSSLRequest
    {
        [JsonProperty("friendly_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FriendlyName { get; set; }

        [JsonProperty("ukfast_ssl_id", NullValueHandling = NullValueHandling.Ignore)]
        public int UKFastSSLID { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("certificate", NullValueHandling = NullValueHandling.Ignore)]
        public string Certificate { get; set; }

        [JsonProperty("ca_bundle", NullValueHandling = NullValueHandling.Ignore)]
        public string CABundle { get; set; }
    }
}