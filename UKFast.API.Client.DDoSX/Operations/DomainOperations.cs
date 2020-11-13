using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainOperations<T> : DDoSXOperations, IDomainOperations<T> where T : Domain
    {
        public DomainOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainsAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(GetDomainsPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetDomainsPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetPaginatedAsync<T>("/ddosx/v1/domains", parameters);
        }

        public async Task<T> GetDomainAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}");
        }

        public async Task CreateDomainAsync(CreateDomainRequest req)
        {
            await Client.PostAsync("/ddosx/v1/domains", req);
        }

        public async Task DeleteDomainAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            await Client.DeleteAsync($"/ddosx/v1/domains/{domainName}");
        }

        public async Task DeployDomainAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            await Client.PostAsync($"/ddosx/v1/domains/{domainName}/deploy");
        }
    }
}