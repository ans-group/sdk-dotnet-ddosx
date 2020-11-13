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
    public class DomainPropertyOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainPropertiesAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<DomainProperty>>(), null).Returns(
                Task.Run<IList<DomainProperty>>(() => new List<DomainProperty>()
                {
                    new DomainProperty(),
                    new DomainProperty()
                }));

            var ops = new DomainPropertyOperations<DomainProperty>(_client);
            var records = await ops.GetDomainPropertiesAsync("test-domain.co.uk");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetDomainPropertiesPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<DomainProperty>("/ddosx/v1/domains/test-domain.co.uk/properties").Returns(
                Task.Run(() => new Paginated<DomainProperty>(_client, "/ddosx/v1/domains/test-domain.co.uk/properties", null,
                    new ClientResponse<IList<DomainProperty>>()
                    {
                        Body = new ClientResponseBody<IList<DomainProperty>>()
                        {
                            Data = new List<DomainProperty>()
                            {
                                new DomainProperty(),
                                new DomainProperty()
                            }
                        }
                    })));

            var ops = new DomainPropertyOperations<DomainProperty>(_client);
            var paginated = await ops.GetDomainPropertiesPaginatedAsync("test-domain.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainPropertyAsync_ValidParameters_ExpectedResult()
        {
            _client
                .GetAsync<DomainProperty>($"/ddosx/v1/domains/test-domain.co.uk/properties/00000000-0000-0000-0000-000000000000")
                .Returns(new DomainProperty()
                {
                    ID = "00000000-0000-0000-0000-000000000000"
                });

            var ops = new DomainPropertyOperations<DomainProperty>(_client);
            var property = await ops.GetDomainPropertyAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", property.ID);
        }

        [TestMethod]
        public async Task GetDomainPropertyAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainPropertyOperations<DomainProperty>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetDomainPropertyAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task GetDomainPropertyAsync_InvalidDomainPropertyID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainPropertyOperations<DomainProperty>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.GetDomainPropertyAsync("test-domain.co.uk", ""));
        }


        [TestMethod]
        public async Task UpdateDomainPropertyAsync_ExpectedResult()
        {
            var req = new UpdateDomainPropertyRequest()
            {
                Value = "test"
            };

            var ops = new DomainPropertyOperations<DomainProperty>(_client);
            await ops.UpdateDomainPropertyAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/properties/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateDomainPropertyAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainPropertyOperations<DomainProperty>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainPropertyAsync("", "00000000-0000-0000-0000-000000000000", new UpdateDomainPropertyRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainPropertyAsync_InvalidDomainPropertyID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainPropertyOperations<DomainProperty>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainPropertyAsync("test-domain.co.uk", "", new UpdateDomainPropertyRequest()));

        }
    }
}