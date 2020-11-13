using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Operations;

namespace UKFast.API.Client.DDoSX
{
    public class UKFastDDoSXClient : UKFastClient, IUKFastDDoSXClient
    {
        public UKFastDDoSXClient(IConnection connection) : base(connection)
        {
        }

        public UKFastDDoSXClient(IConnection connection, ClientConfig config) : base(connection, config)
        {
        }

        public IDomainOperations<Domain> DomainOperations()
        {
            return new DomainOperations<Domain>(this);
        }

        public IDomainRecordOperations<Record> DomainRecordOperations()
        {
            return new DomainRecordOperations<Record>(this);
        }

        public IDomainPropertyOperations<DomainProperty> DomainPropertyOperations()
        {
            return new DomainPropertyOperations<DomainProperty>(this);
        }

        public IRecordOperations<Record> RecordOperations()
        {
            return new RecordOperations<Record>(this);
        }

        public IDomainWAFOperations<WAF> DomainWAFOperations()
        {
            return new DomainWAFOperations<WAF>(this);
        }

        public IDomainWAFRuleSetOperations<WAFRuleSet> DomainWAFRuleSetOperations()
        {
            return new DomainWAFRuleSetOperations<WAFRuleSet>(this);
        }

        public IDomainWAFRuleOperations<WAFRule> DomainWAFRuleOperations()
        {
            return new DomainWAFRuleOperations<WAFRule>(this);
        }

        public IDomainWAFAdvancedRuleOperations<WAFAdvancedRule> DomainWAFAdvancedRuleOperations()
        {
            return new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(this);
        }
    }
}