using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainPropertyOperations<T> : DDoSXOperations, IDomainPropertyOperations<T> where T : DomainProperty
    {
        public DomainPropertyOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainPropertiesAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(funcParams => 
                    GetDomainPropertiesPaginatedAsync(domainName, funcParams),
                    parameters);
        }

        public async Task<Paginated<T>> GetDomainPropertiesPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetPaginatedAsync<T>($"/ddosx/v1/domains/{domainName}/properties", parameters);
        }

        public async Task<T> GetDomainPropertyAsync(string domainName, string propertyID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(propertyID))
            {
                throw new UKFastClientValidationException("Invalid property id");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/properties/{propertyID}");
        }

        public async Task UpdateDomainPropertyAsync(string domainName, string propertyID, UpdateDomainPropertyRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(propertyID))
            {
                throw new UKFastClientValidationException("Invalid property id");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/properties/{propertyID}", req);
        }
    }
}