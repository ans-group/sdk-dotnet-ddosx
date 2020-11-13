using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Operations;
using UKFast.API.Client.Models;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.DDoSX.Tests.Operations
{
    [TestClass]
    public class RecordOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetRecordsAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Record>>(), null).Returns(
                Task.Run<IList<Record>>(() => new List<Record>()
                {
                    new Record(),
                    new Record()
                }));

            var ops = new RecordOperations<Record>(_client);
            var domains = await ops.GetRecordsAsync();

            Assert.AreEqual(2, domains.Count);
        }

        [TestMethod]
        public async Task GetRecordsPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<Record>("/ddosx/v1/records").Returns(
                Task.Run(() => new Paginated<Record>(_client, "/ddosx/v1/records", null,
                    new ClientResponse<IList<Record>>()
                    {
                        Body = new ClientResponseBody<IList<Record>>()
                        {
                            Data = new List<Record>()
                            {
                                new Record(),
                                new Record()
                            }
                        }
                    })));

            var ops = new RecordOperations<Record>(_client);
            var paginated = await ops.GetRecordsPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }
    }
}