using Newtonsoft.Json;

namespace UKFast.API.Client.DDoSX.Models.Request
{
    /// <summary>
    /// Represents a request to create a DDoSX domain
    /// </summary>
    public class CreateDomainRequest
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
    }
}