using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainWAFOperations<T> : DDoSXOperations, IDomainWAFOperations<T> where T : WAF
    {
        public DomainWAFOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<T> GetDomainWAFAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/waf");
        }

        public async Task CreateDomainWAFAsync(string domainName, CreateWAFRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            await Client.PostAsync($"/ddosx/v1/domains/{domainName}/waf", req);
        }

        public async Task UpdateDomainWAFAsync(string domainName, UpdateWAFRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/waf", req);
        }

        public async Task DeleteDomainWAFAsync(string domainName)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            await Client.DeleteAsync($"/ddosx/v1/domains/{domainName}/waf");
        }
    }
}