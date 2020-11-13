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
    public class DomainWAFRuleSetOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainWAFRuleSetsAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<WAFRuleSet>>(), null).Returns(
                Task.Run<IList<WAFRuleSet>>(() => new List<WAFRuleSet>()
                {
                    new WAFRuleSet(),
                    new WAFRuleSet()
                }));

            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(_client);
            var records = await ops.GetDomainWAFRuleSetsAsync("test-domain.co.uk");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFRuleSetsPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<WAFRuleSet>("/ddosx/v1/domains/test-domain.co.uk/waf/rulesets").Returns(
                Task.Run(() => new Paginated<WAFRuleSet>(_client, "/ddosx/v1/domains/test-domain.co.uk/waf/rulesets", null,
                    new ClientResponse<IList<WAFRuleSet>>()
                    {
                        Body = new ClientResponseBody<IList<WAFRuleSet>>()
                        {
                            Data = new List<WAFRuleSet>()
                            {
                                new WAFRuleSet(),
                                new WAFRuleSet()
                            }
                        }
                    })));

            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(_client);
            var paginated = await ops.GetDomainWAFRuleSetsPaginatedAsync("test-domain.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFRuleSetAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<WAFRuleSet>($"/ddosx/v1/domains/test-domain.co.uk/waf/rulesets/00000000-0000-0000-0000-000000000000")
                .Returns(new WAFRuleSet()
                {
                    ID = "00000000-0000-0000-0000-000000000000"
                });

            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(_client);
            var ruleset = await ops.GetDomainWAFRuleSetAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", ruleset.ID);
        }

        [TestMethod]
        public async Task GetDomainWAFRuleSetAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFRuleSetAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task GetDomainWAFRuleSetAsync_InvalidWAFRuleSetID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFRuleSetAsync("test-domain.co.uk", ""));
        }


        [TestMethod]
        public async Task UpdateDomainWAFRuleSetAsync_ExpectedResult()
        {
            var req = new UpdateWAFRuleSetRequest()
            {
                Active = false
            };

            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(_client);
            await ops.UpdateDomainWAFRuleSetAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/waf/rulesets/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateDomainWAFRuleSetAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFRuleSetAsync("", "00000000-0000-0000-0000-000000000000", new UpdateWAFRuleSetRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFRuleSetAsync_InvalidWAFRuleSetID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleSetOperations<WAFRuleSet>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFRuleSetAsync("test-domain.co.uk", "", new UpdateWAFRuleSetRequest()));
        }

    }
}