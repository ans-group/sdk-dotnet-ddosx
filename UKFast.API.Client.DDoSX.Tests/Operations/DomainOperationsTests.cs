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
    public class DomainOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainsAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<Domain>>(), null).Returns(
                Task.Run<IList<Domain>>(() => new List<Domain>()
                {
                    new Domain(),
                    new Domain()
                }));

            var ops = new DomainOperations<Domain>(_client);
            var domains = await ops.GetDomainsAsync();

            Assert.AreEqual(2, domains.Count);
        }

        [TestMethod]
        public async Task GetDomainsPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<Domain>("/ddosx/v1/domains").Returns(
                Task.Run(() => new Paginated<Domain>(_client, "/ddosx/v1/domains", null,
                    new ClientResponse<IList<Domain>>()
                    {
                        Body = new ClientResponseBody<IList<Domain>>()
                        {
                            Data = new List<Domain>()
                            {
                                new Domain(),
                                new Domain()
                            }
                        }
                    })));

            var ops = new DomainOperations<Domain>(_client);
            var paginated = await ops.GetDomainsPaginatedAsync();

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<Domain>($"/ddosx/v1/domains/test-domain.co.uk").Returns(new Domain()
            {
                Name = "test-domain.co.uk"
            });

            var ops = new DomainOperations<Domain>(_client);
            var domain = await ops.GetDomainAsync("test-domain.co.uk");

            Assert.AreEqual("test-domain.co.uk", domain.Name);
        }

        [TestMethod]
        public async Task GetDomainAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainOperations<Domain>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.GetDomainAsync(""));
        }

        [TestMethod]
        public async Task CreateDomainAsync_ExpectedResult()
        {
            var req = new CreateDomainRequest()
            {
                Name = "test-domain.co.uk"
            };

            var ops = new DomainOperations<Domain>(_client);
            await ops.CreateDomainAsync(req);

            await _client.Received().PostAsync("/ddosx/v1/domains", req);
        }

        [TestMethod]
        public async Task DeleteDomainAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainOperations<Domain>(_client);
            await ops.DeleteDomainAsync("test-domain.co.uk");

            await _client.Received().DeleteAsync("/ddosx/v1/domains/test-domain.co.uk");
        }

        [TestMethod]
        public async Task DeleteDomainAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainOperations<Domain>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeleteDomainAsync(""));
        }

        [TestMethod]
        public async Task DeployDomainAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainOperations<Domain>(_client);
            await ops.DeployDomainAsync("test-domain.co.uk");

            await _client.Received().PostAsync("/ddosx/v1/domains/test-domain.co.uk/deploy");
        }

        [TestMethod]
        public async Task DeployDomainAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainOperations<Domain>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => ops.DeployDomainAsync(""));
        }
    }
}