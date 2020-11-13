using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainWAFRuleSetOperations<T> where T : WAFRuleSet
    {
        Task<IList<T>> GetDomainWAFRuleSetsAsync(string domainName, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainWAFRuleSetsPaginatedAsync(string domainName, ClientRequestParameters parameters = null);

        Task<T> GetDomainWAFRuleSetAsync(string domainName, string ruleSetID);

        Task UpdateDomainWAFRuleSetAsync(string domainName, string ruleSetID, UpdateWAFRuleSetRequest req);
    }
}