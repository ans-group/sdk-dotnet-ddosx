using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainWAFOperations<T> where T : WAF
    {
        Task<T> GetDomainWAFAsync(string domainName);

        Task CreateDomainWAFAsync(string domainName, CreateWAFRequest req);

        Task UpdateDomainWAFAsync(string domainName, UpdateWAFRequest req);

        Task DeleteDomainWAFAsync(string domainName);
    }
}