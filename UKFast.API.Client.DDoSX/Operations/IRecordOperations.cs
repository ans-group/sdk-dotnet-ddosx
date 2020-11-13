using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IRecordOperations<T> where T : Record
    {
        Task<IList<T>> GetRecordsAsync(ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetRecordsPaginatedAsync(ClientRequestParameters parameters = null);
    }
}