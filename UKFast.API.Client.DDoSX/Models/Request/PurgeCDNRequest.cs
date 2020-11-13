using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX CDN purge request
    /// </summary>
    public class PurgeCDNRequest
    {
        [JsonProperty("record_name", Required = Required.Always)]
        public string RecordName { get; set; }

        [JsonProperty("uri", Required = Required.Always)]
        public string URI { get; set; }
    }
}