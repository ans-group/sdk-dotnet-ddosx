using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainWAFRuleOperations<T> where T : WAFRule
    {
        Task<IList<T>> GetDomainWAFRulesAsync(string domainName, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainWAFRulesPaginatedAsync(string domainName, ClientRequestParameters parameters = null);

        Task<T> GetDomainWAFRuleAsync(string domainName, string ruleID);

        Task<string> CreateDomainWAFRuleAsync(string domainName, CreateWAFRuleRequest req);

        Task UpdateDomainWAFRuleAsync(string domainName, string ruleID, UpdateWAFRuleRequest req);

        Task DeleteDomainWAFRuleAsync(string domainName, string ruleID);
    }
}