using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Operations;

namespace UKFast.API.Client.DDoSX
{
    public interface IUKFastDDoSXClient : IUKFastClient
    {
        IDomainOperations<Domain> DomainOperations();

        IDomainRecordOperations<Record> DomainRecordOperations();

        IDomainPropertyOperations<DomainProperty> DomainPropertyOperations();

        IRecordOperations<Record> RecordOperations();

        IDomainWAFOperations<WAF> DomainWAFOperations();

        IDomainWAFRuleSetOperations<WAFRuleSet> DomainWAFRuleSetOperations();

        IDomainWAFRuleOperations<WAFRule> DomainWAFRuleOperations();

        IDomainWAFAdvancedRuleOperations<WAFAdvancedRule> DomainWAFAdvancedRuleOperations();
    }
}