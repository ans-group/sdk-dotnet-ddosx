using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainWAFAdvancedRuleOperations<T> where T : WAFAdvancedRule
    {
        Task<IList<T>> GetDomainWAFAdvancedRulesAsync(string domainName, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainWAFAdvancedRulesPaginatedAsync(string domainName, ClientRequestParameters parameters = null);

        Task<T> GetDomainWAFAdvancedRuleAsync(string domainName, string ruleID);

        Task<string> CreateDomainWAFAdvancedRuleAsync(string domainName, CreateWAFAdvancedRuleRequest req);

        Task UpdateDomainWAFAdvancedRuleAsync(string domainName, string ruleID, UpdateWAFAdvancedRuleRequest req);

        Task DeleteDomainWAFAdvancedRuleAsync(string domainName, string ruleID);
    }
}