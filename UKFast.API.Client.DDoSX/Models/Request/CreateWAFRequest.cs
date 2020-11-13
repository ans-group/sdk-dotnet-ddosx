using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a DDoSX WAF create request
    /// </summary>
    public class CreateWAFRequest
    {
        [JsonProperty("mode", Required = Required.Always)]
        public string WAFMode { get; set; }  

        [JsonProperty("paranoia_level", Required = Required.Always)]
        public string ParanoiaLevel { get; set; } 
    }
}