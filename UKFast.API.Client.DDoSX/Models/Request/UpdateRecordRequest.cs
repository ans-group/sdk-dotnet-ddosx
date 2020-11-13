using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX record patch request
    /// </summary>
    public class UpdateRecordRequest
    {
        [JsonProperty("safedns_record_id", NullValueHandling = NullValueHandling.Ignore)]
        public int SafeDNSRecordID { get; set; }

        [JsonProperty("ssl_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SSLID { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
    }
}