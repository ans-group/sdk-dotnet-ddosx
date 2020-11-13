using UKFast.API.Client.Models;

namespace UKFast.API.Client.DDoSX.Models
{
    /// <summary>
    /// Represents a DDoSX SSL private key
    /// </summary>
    public class SSLPrivateKey : ModelBase
    {
        [Newtonsoft.Json.JsonProperty("key")]
        public string Key { get; set; }
    }
}