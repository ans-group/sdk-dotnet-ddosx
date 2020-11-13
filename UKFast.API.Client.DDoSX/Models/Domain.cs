using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX Domain
    /// </summary>
    public class Domain : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("safedns_zone_id")]
        public int SafeDNSZoneID { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("dns_active")]
        public bool DNSActive { get; set; }

        [Newtonsoft.Json.JsonProperty("cdn_active")]
        public bool CDNActive { get; set; }

        [Newtonsoft.Json.JsonProperty("waf_active")]
        public bool WAFActive { get; set; }

        [Newtonsoft.Json.JsonProperty("external_dns")]
        public DomainExternalDNS DomainExternalDNS { get; set; }
    }


    /// <summary>
    /// Represents a DDoSX Domain external DNS configuration
    /// </summary>
    public class DomainExternalDNS
    {
        [Newtonsoft.Json.JsonProperty("verified")]
        public bool? Verified { get; set; }

        [Newtonsoft.Json.JsonProperty("verification_string")]
        public string VerificationString { get; set; }

        [Newtonsoft.Json.JsonProperty("target")]
        public string Target { get; set; }
    }
}