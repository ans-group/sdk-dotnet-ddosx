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
    public class DomainWAFAdvancedRuleOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainWAFAdvancedRulesAsync_ExpectedResult()
        {
            _client.GetAllAsync(Arg.Any<UKFastClient.GetPaginatedAsyncFunc<WAFAdvancedRule>>(), null).Returns(
                Task.Run<IList<WAFAdvancedRule>>(() => new List<WAFAdvancedRule>()
                {
                    new WAFAdvancedRule(),
                    new WAFAdvancedRule()
                }));

            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            var records = await ops.GetDomainWAFAdvancedRulesAsync("test-domain.co.uk");

            Assert.AreEqual(2, records.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFAdvancedRulesPaginatedAsync_ExpectedResult()
        {
            _client.GetPaginatedAsync<WAFAdvancedRule>("/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules").Returns(
                Task.Run(() => new Paginated<WAFAdvancedRule>(_client, "/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules", null,
                    new ClientResponse<IList<WAFAdvancedRule>>()
                    {
                        Body = new ClientResponseBody<IList<WAFAdvancedRule>>()
                        {
                            Data = new List<WAFAdvancedRule>()
                            {
                                new WAFAdvancedRule(),
                                new WAFAdvancedRule()
                            }
                        }
                    })));

            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            var paginated = await ops.GetDomainWAFAdvancedRulesPaginatedAsync("test-domain.co.uk");

            Assert.AreEqual(2, paginated.Items.Count);
        }

        [TestMethod]
        public async Task GetDomainWAFAdvancedRuleAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<WAFAdvancedRule>($"/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules/00000000-0000-0000-0000-000000000000")
                .Returns(new WAFAdvancedRule()
                {
                    ID = "00000000-0000-0000-0000-000000000000"
                });

            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            var rule = await ops.GetDomainWAFAdvancedRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", rule.ID);
        }

        [TestMethod]
        public async Task GetDomainWAFAdvancedRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFAdvancedRuleAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task GetDomainWAFAdvancedRuleAsync_InvalidWAFAdvancedRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFAdvancedRuleAsync("test-domain.co.uk", ""));
        }

        [TestMethod]
        public async Task CreateDomainWAFAdvancedRuleAsync_ExpectedResult()
        {
            var req = new CreateWAFAdvancedRuleRequest()
            {
                Section = "REQUEST_URI",
                Phrase = "test",
                IP = "1.2.3.4"
            };

            _client.PostAsync<WAFAdvancedRule>($"/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules", req).Returns(new WAFAdvancedRule()
            {
                ID = "00000000-0000-0000-0000-000000000000"
            });

            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            var ruleID = await ops.CreateDomainWAFAdvancedRuleAsync("test-domain.co.uk", req);

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", ruleID);
        }

        [TestMethod]
        public async Task CreateDomainWAFAdvancedRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.CreateDomainWAFAdvancedRuleAsync("", new CreateWAFAdvancedRuleRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFAdvancedRuleAsync_ExpectedResult()
        {
            var req = new UpdateWAFAdvancedRuleRequest()
            {
                Phrase = "test"
            };

            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            await ops.UpdateDomainWAFAdvancedRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules/00000000-0000-0000-0000-000000000000", req);
        }

        [TestMethod]
        public async Task UpdateDomainWAFAdvancedRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFAdvancedRuleAsync("", "00000000-0000-0000-0000-000000000000", new UpdateWAFAdvancedRuleRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFAdvancedRuleAsync_InvalidWAFAdvancedRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFAdvancedRuleAsync("test-domain.co.uk", "", new UpdateWAFAdvancedRuleRequest()));
        }

        [TestMethod]
        public async Task DeleteDomainWAFAdvancedRuleAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(_client);
            await ops.DeleteDomainWAFAdvancedRuleAsync("test-domain.co.uk", "00000000-0000-0000-0000-000000000000");

            await _client.Received().DeleteAsync("/ddosx/v1/domains/test-domain.co.uk/waf/advanced-rules/00000000-0000-0000-0000-000000000000");
        }

        [TestMethod]
        public async Task DeleteDomainWAFAdvancedRuleAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.DeleteDomainWAFAdvancedRuleAsync("", "00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public async Task DeleteDomainWAFAdvancedRuleAsync_InvalidWAFAdvancedRuleID_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFAdvancedRuleOperations<WAFAdvancedRule>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.DeleteDomainWAFAdvancedRuleAsync("test-domain.co.uk", ""));
        }

    }
}