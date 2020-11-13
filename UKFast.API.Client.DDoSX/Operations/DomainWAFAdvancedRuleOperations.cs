using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class DomainWAFAdvancedRuleOperations<T> : DDoSXOperations, IDomainWAFAdvancedRuleOperations<T> where T : WAFAdvancedRule
    {
        public DomainWAFAdvancedRuleOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetDomainWAFAdvancedRulesAsync(string domainName, ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(funcParams =>
                    GetDomainWAFAdvancedRulesPaginatedAsync(domainName, funcParams),
                    parameters);
        }

        public async Task<Paginated<T>> GetDomainWAFAdvancedRulesPaginatedAsync(string domainName, ClientRequestParameters parameters = null)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return await Client.GetPaginatedAsync<T>($"/ddosx/v1/domains/{domainName}/waf/advanced-rules");
        }

        public async Task<T> GetDomainWAFAdvancedRuleAsync(string domainName, string ruleID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            return await Client.GetAsync<T>($"/ddosx/v1/domains/{domainName}/waf/advanced-rules/{ruleID}");
        }

        public async Task<string> CreateDomainWAFAdvancedRuleAsync(string domainName, CreateWAFAdvancedRuleRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }

            return (await Client.PostAsync<T>($"/ddosx/v1/domains/{domainName}/waf/advanced-rules", req)).ID;
        }

        public async Task UpdateDomainWAFAdvancedRuleAsync(string domainName, string ruleID, UpdateWAFAdvancedRuleRequest req)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            await Client.PatchAsync($"/ddosx/v1/domains/{domainName}/waf/advanced-rules/{ruleID}", req);
        }

        public async Task DeleteDomainWAFAdvancedRuleAsync(string domainName, string ruleID)
        {
            if (string.IsNullOrWhiteSpace(domainName))
            {
                throw new UKFastClientValidationException("Invalid domain name");
            }
            if (string.IsNullOrWhiteSpace(ruleID))
            {
                throw new UKFastClientValidationException("Invalid rule id");
            }

            await Client.DeleteAsync($"/ddosx/v1/domains/{domainName}/waf/advanced-rules/{ruleID}");
        }
    }
}