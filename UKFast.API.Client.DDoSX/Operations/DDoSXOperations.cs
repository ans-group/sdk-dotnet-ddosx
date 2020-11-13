using UKFast.API.Client.Operations;

namespace UKFast.API.Client.DDoSX.Operations
{
    public abstract class DDoSXOperations : OperationsBase<IUKFastDDoSXClient>
    {
        public DDoSXOperations(IUKFastDDoSXClient client) : base(client) { }
    }
}
