using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX domain record property
    /// </summary>
    public class Record : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string ID { get; set; }

        [Newtonsoft.Json.JsonProperty("domain_name")]
        public string DomainName { get; set; }

        [Newtonsoft.Json.JsonProperty("ssl_id")]
        public string SSLID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("type")]
        public string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("content")]
        public string Content { get; set; }

        [Newtonsoft.Json.JsonProperty("safedns_record_id")]
        public int? SafeDNSRecordID { get; set; }

        public bool IsIPV4()
        {
            return this.Type == "A";
        }

        public bool IsIPV6()
        {
            return this.Type == "AAAA";
        }
    }
}