using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.Models;
using UKFast.API.Client.Request;

namespace UKFast.API.Client.DDoSX.Operations
{
    public interface IDomainRecordOperations<T> where T : Record
    {
        Task<IList<T>> GetDomainRecordsAsync(string domainName, ClientRequestParameters parameters = null);

        Task<Paginated<T>> GetDomainRecordsPaginatedAsync(string domainName, ClientRequestParameters parameters = null);

        Task<T> GetDomainRecordAsync(string domainName, string recordID);

        Task<string> CreateDomainRecordAsync(string domainName, CreateRecordRequest req);

        Task UpdateDomainRecordAsync(string domainName, string recordID, UpdateRecordRequest req);

        Task DeleteDomainRecordAsync(string domainName, string recordID);
    }
}