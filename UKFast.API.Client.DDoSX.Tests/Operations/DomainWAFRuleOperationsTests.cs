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
    public class DomainWAFRuleOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainWAFRulesAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<WAFRule>>(), null).Returns(
                Task.Run<IList<WAFRule>>(() => new List<WAFRule>()
                {
                    new WAFRule(),
                    new WAFRule()
                }));

            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            var records = await ops.GetDomainWAFRulesAsync("test-domain.co.uk");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFRulesPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<WAFRule>("/ddosx/v1/domains/test-domain.co.uk/waf/rules").Returns(
                Task.Run(() => new Paginated<WAFRule>(_client, "/ddosx/v1/domains/test-domain.co.uk/waf/rules", null,
                    new ClientResponse<IList<WAFRule>>()
                    {
                        Body = new ClientResponseBody<IList<WAFRule>>()
                        {
                            Data = new List<WAFRule>()
                            {
                                new WAFRule(),
                                new WAFRule()
                            }
                        }
                    })));

            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            var paginated = await ops.GetDomainWAFRulesPaginatedAsync("test-domain.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFRuleAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<WAFRule>($"/ddosx/v1/domains/test-domain.co.uk/waf/rules/00000000-0000-0000-0000-000000000000")
                .Returns(new WAFRule()
                {
                    ID = "00000000-0000-0000-0000-000000000000"
                });

            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            var rule = await ops.GetDomainWAFRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", rule.ID);
        }

        [TestMethod]
        public async Task GetDomainWAFRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFRuleAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task GetDomainWAFRuleAsync_InvalidWAFRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFRuleAsync("test-domain.co.uk", ""));
        }

        [TestMethod]
        public async Task CreateDomainWAFRuleAsync_ExpectedResult()
        {
            var req = new CreateWAFRuleRequest()
            {
                URI = "test.html",
                IP = "1.2.3.4"
            };

            _client.PostAsync<WAFRule>($"/ddosx/v1/domains/test-domain.co.uk/waf/rules", req).Returns(new WAFRule()
            {
                ID = "00000000-0000-0000-0000-000000000000"
            });

            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            var ruleID = await ops.CreateDomainWAFRuleAsync("test-domain.co.uk", req);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", ruleID);
        }

        [TestMethod]
        public async Task CreateDomainWAFRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.CreateDomainWAFRuleAsync("", new CreateWAFRuleRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFRuleAsync_ExpectedResult()
        {
            var req = new UpdateWAFRuleRequest()
            {
                URI = "test.html"
            };

            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            await ops.UpdateDomainWAFRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/waf/rules/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateDomainWAFRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFRuleAsync("", "00000000-0000-0000-0000-000000000000", new UpdateWAFRuleRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFRuleAsync_InvalidWAFRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFRuleAsync("test-domain.co.uk", "", new UpdateWAFRuleRequest()));
        }

        [TestMethod]
        public async Task DeleteDomainWAFRuleAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(_client);
            await ops.DeleteDomainWAFRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            await _client.Received().DeleteAsync("/ddosx/v1/domains/test-domain.co.uk/waf/rules/00000000-0000-0000-0000-000000000000");
        }

        [TestMethod]
        public async Task DeleteDomainWAFRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.DeleteDomainWAFRuleAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task DeleteDomainWAFRuleAsync_InvalidWAFRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFRuleOperations<WAFRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.DeleteDomainWAFRuleAsync("test-domain.co.uk", ""));
        }

    }
}