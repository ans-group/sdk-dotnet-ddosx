using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainRecordOperations<T> : DDoSXOperations, IDomainRecordOperations<T> where T : Record
    {
        public DomainRecordOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainRecordsAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(funcParams => 
                    GetDomainRecordsPaginatedAsync(domainName, funcParams),
                    parameters);
        }

        public async Task<Paginated<T>> GetDomainRecordsPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetPaginatedAsync<T>($"/ddosx/v1/domains/{domainName}/records", parameters);
        }

        public async Task<T> GetDomainRecordAsync(string domainName, string recordID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(recordID))
            {
                throw new UKFastClientValidationException("Invalid record id");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/records/{recordID}");
        }

        public async Task<string> CreateDomainRecordAsync(string domainName, CreateRecordRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return (await Client.PostAsync<Record>($"/ddosx/v1/domains/{domainName}/records", req)).ID;
        }

        public async Task UpdateDomainRecordAsync(string domainName, string recordID, UpdateRecordRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(recordID))
            {
                throw new UKFastClientValidationException("Invalid record id");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/records/{recordID}", req);
        }

        public async Task DeleteDomainRecordAsync(string domainName, string recordID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(recordID))
            {
                throw new UKFastClientValidationException("Invalid record id");
            }

            await Client.DeleteAsync($"/ddosx/v1/domains/{domainName}/records/{recordID}");
        }
    }
}