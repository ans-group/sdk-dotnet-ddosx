using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainPropertyOperations<T> where T : DomainProperty
    {
        Task<IList<T>> GetDomainPropertiesAsync(string domainName, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainPropertiesPaginatedAsync(string domainName, ClientRequestParameters parameters = null);

        Task<T> GetDomainPropertyAsync(string domainName, string propertyID);

        Task UpdateDomainPropertyAsync(string domainName, string propertyID, UpdateDomainPropertyRequest req);
    }
}