using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainOperations<T> where T : Domain
    {
        Task<IList<T>> GetDomainsAsync(ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainsPaginatedAsync(ClientRequestParameters parameters = null);

        Task<T> GetDomainAsync(string domainName);

        Task CreateDomainAsync(CreateDomainRequest req);

        Task DeleteDomainAsync(string domainName);

        Task DeployDomainAsync(string domainName);
    }
}