using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public class RecordOperations<T> : DDoSXOperations, IRecordOperations<T> where T : Record
    {
        public RecordOperations(IUKFastDDoSXClient client) : base(client)
        {
        }

        public async Task<IList<T>> GetRecordsAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetAllAsync(GetRecordsPaginatedAsync, parameters);
        }

        public async Task<Paginated<T>> GetRecordsPaginatedAsync(ClientRequestParameters parameters = null)
        {
            return await Client.GetPaginatedAsync<T>("/ddosx/v1/records", parameters);
        }
    }
}