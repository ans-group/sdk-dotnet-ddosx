using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NSubstitute;
using UKFast.API.Client.DDoSX.Models;
using UKFast.API.Client.DDoSX.Models.Request;
using UKFast.API.Client.DDoSX.Operations;
using UKFast.API.Client.Exception;
using UKFast.API.Client.Models;
using UKFast.API.Client.Response;

namespace UKFast.API.Client.DDoSX.Tests.Operations
{
    [TestClass]
    public class DomainRecordOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainRecordsAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Record>>(), null).Returns(
                Task.Run<IList<Record>>(() => new List<Record>()
                {
                    new Record(),
                    new Record()
                }));

            var ops = new DomainRecordOperations<Record>(_client);
            var records = await ops.GetDomainRecordsAsync("test-domain.co.uk");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetDomainRecordsPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<Record>("/ddosx/v1/domains/test-domain.co.uk/records").Returns(
                Task.Run(() => new Paginated<Record>(_client, "/ddosx/v1/domains/test-domain.co.uk/records", null,
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

            var ops = new DomainRecordOperations<Record>(_client);
            var paginated = await ops.GetDomainRecordsPaginatedAsync("test-domain.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainRecordAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<Record>($"/ddosx/v1/domains/test-domain.co.uk/records/00000000-0000-0000-0000-000000000000")
                .Returns(new Record()
                {
                    ID = "00000000-0000-0000-0000-000000000000"
                });

            var ops = new DomainRecordOperations<Record>(_client);
            var record = await ops.GetDomainRecordAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", record.ID);
        }

        [TestMethod]
        public async Task GetDomainRecordAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainRecordAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task GetDomainRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainRecordAsync("test-domain.co.uk", ""));
        }

        [TestMethod]
        public async Task CreateDomainRecordAsync_ExpectedResult()
        {
            var req = new CreateRecordRequest()
            {
                Name = "test-record.test-domain.co.uk"
            };

            _client.PostAsync<Record>($"/ddosx/v1/domains/test-domain.co.uk/records", req).Returns(new Record()
            {
                ID = "00000000-0000-0000-0000-000000000000"
            });

            var ops = new DomainRecordOperations<Record>(_client);
            var recordID = await ops.CreateDomainRecordAsync("test-domain.co.uk", req);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", recordID);
        }

        [TestMethod]
        public async Task CreateDomainRecordAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.CreateDomainRecordAsync("", new CreateRecordRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainRecordAsync_ExpectedResult()
        {
            var req = new UpdateRecordRequest()
            {
                Name = "test-record.test-domain.co.uk"
            };

            var ops = new DomainRecordOperations<Record>(_client);
            await ops.UpdateDomainRecordAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/records/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateDomainRecordAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainRecordAsync("", "00000000-0000-0000-0000-000000000000", new UpdateRecordRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainRecordAsync("test-domain.co.uk", "", new UpdateRecordRequest()));
        }

        [TestMethod]
        public async Task DeleteDomainRecordAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainRecordOperations<Record>(_client);
            await ops.DeleteDomainRecordAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            await _client.Received().DeleteAsync("/ddosx/v1/domains/test-domain.co.uk/records/00000000-0000-0000-0000-000000000000");
        }

        [TestMethod]
        public async Task DeleteDomainRecordAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.DeleteDomainRecordAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task DeleteDomainRecordAsync_InvalidRecordID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainRecordOperations<Record>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.DeleteDomainRecordAsync("test-domain.co.uk", ""));
        }

    }
}