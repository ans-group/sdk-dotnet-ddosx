using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface ISSLOperations<T> where T : SSL
    {
        Task<IList<T>> GetSSLsAsync(ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetSSLsPaginatedAsync(ClientRequestParameters parameters = null);

        Task<T> GetSSLAsync(string sslID);

        Task<string> CreateSSLAsync(CreateSSLRequest req);

        Task UpdateSSLAsync(string sslID, UpdateSSLRequest req);

        Task DeleteSSLAsync(string sslID);

        Task<SSLContent> GetSSLContentAsync(string sslID);

        Task<SSLPrivateKey> DeleteSSLPrivateKeyAsync(string sslID);
    }
}