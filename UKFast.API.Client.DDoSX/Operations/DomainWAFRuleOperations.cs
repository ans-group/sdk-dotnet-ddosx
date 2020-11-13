using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainWAFRuleOperations<T> : DDoSXOperations, IDomainWAFRuleOperations<T> where T : WAFRule
    {
        public DomainWAFRuleOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainWAFRulesAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(funcParams => 
                GetDomainWAFRulesPaginatedAsync(domainName, funcParams), 
                parameters);
        }

        public async Task<Paginated<T>> GetDomainWAFRulesPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetPaginatedAsync<T>($"/ddosx/v1/domains/{domainName}/waf/rules");
        }

        public async Task<T> GetDomainWAFRuleAsync(string domainName, string ruleID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/waf/rules/{ruleID}");
        }

        public async Task<string> CreateDomainWAFRuleAsync(string domainName, CreateWAFRuleRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return (await Client.PostAsync<T>($"/ddosx/v1/domains/{domainName}/waf/rules", req)).ID;
        }

        public async Task UpdateDomainWAFRuleAsync(string domainName, string ruleID, UpdateWAFRuleRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/waf/rules/{ruleID}", req);
        }

        public async Task DeleteDomainWAFRuleAsync(string domainName, string ruleID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            await Client.DeleteAsync($"/ddosx/v1/domains/{domainName}/waf/rules/{ruleID}");
        }
    }
}