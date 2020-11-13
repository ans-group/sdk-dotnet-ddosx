using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainWAFRuleSetOperations<T> : DDoSXOperations, IDomainWAFRuleSetOperations<T> where T : WAFRuleSet
    {
        public DomainWAFRuleSetOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainWAFRuleSetsAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(funcParams =>
                    GetDomainWAFRuleSetsPaginatedAsync(domainName, funcParams),
                    parameters);
        }

        public async Task<Paginated<T>> GetDomainWAFRuleSetsPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetPaginatedAsync<T>($"/ddosx/v1/domains/{domainName}/waf/rulesets");
        }

        public async Task<T> GetDomainWAFRuleSetAsync(string domainName, string ruleSetID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleSetID))
            {
                throw new UKFastClientValidationException("Invalid rule set id");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/waf/rulesets/{ruleSetID}");
        }

        public async Task UpdateDomainWAFRuleSetAsync(string domainName, string ruleSetID, UpdateWAFRuleSetRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleSetID))
            {
                throw new UKFastClientValidationException("Invalid rule set id");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/waf/rulesets/{ruleSetID}", req);
        }
    }
}