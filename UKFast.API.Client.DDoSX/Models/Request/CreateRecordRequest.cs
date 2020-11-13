using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a request to create a DDoSX record.
    /// </summary>
    public class CreateRecordRequest
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("safedns_record_id", NullValueHandling = NullValueHandling.Ignore)]
        public int SafeDNSRecordID { get; set; }

        [JsonProperty("ssl_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SSLID { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}