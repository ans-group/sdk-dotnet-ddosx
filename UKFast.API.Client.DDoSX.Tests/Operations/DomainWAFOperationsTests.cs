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
    public class DomainWAFOperationsTests
    {
        private IUKFastDDoSXClient _client;

        [TestInitialize]
        public void Setup()
        {
            _client = Substitute.For<IUKFastDDoSXClient>();
        }

        [TestMethod]
        public async Task GetDomainWAFAsync_ValidParameters_ExpectedResult()
        {
            _client.GetAsync<WAF>($"/ddosx/v1/domains/test-domain.co.uk/waf")
                .Returns(new WAF()
                {
                    Mode = "On"
                });

            var ops = new DomainWAFOperations<WAF>(_client);
            var waf = await ops.GetDomainWAFAsync("test-domain.co.uk");

            Assert.AreEqual("On", waf.Mode);
        }

        [TestMethod]
        public async Task GetDomainWAFAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFOperations<WAF>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.GetDomainWAFAsync(""));
        }

        [TestMethod]
        public async Task CreateDomainWAFAsync_ExpectedResult()
        {
            var req = new CreateWAFRequest()
            {
                WAFMode = "On",
                ParanoiaLevel = "Medium"
            };

            var ops = new DomainWAFOperations<WAF>(_client);
            await ops.CreateDomainWAFAsync("test-domain.co.uk", req);

            await _client.Received().PostAsync($"/ddosx/v1/domains/test-domain.co.uk/waf", req);
        }

        [TestMethod]
        public async Task CreateDomainWAFAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFOperations<WAF>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.CreateDomainWAFAsync("", new CreateWAFRequest()));
        }

        [TestMethod]
        public async Task UpdateDomainWAFAsync_ExpectedResult()
        {
            var req = new UpdateWAFRequest()
            {
                WAFMode = "On"
            };

            var ops = new DomainWAFOperations<WAF>(_client);
            await ops.UpdateDomainWAFAsync("test-domain.co.uk", req);

            await _client.Received()
                .PatchAsync($"/ddosx/v1/domains/test-domain.co.uk/waf", req);
        }

        [TestMethod]
        public async Task UpdateDomainWAFAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFOperations<WAF>(null);

            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() =>
                ops.UpdateDomainWAFAsync("", new UpdateWAFRequest()));
        }

        [TestMethod]
        public async Task DeleteDomainWAFAsync_ValidParameters_ExpectedClientCall()
        {
            var ops = new DomainWAFOperations<WAF>(_client);
            await ops.DeleteDomainWAFAsync("test-domain.co.uk");

            await _client.Received().DeleteAsync("/ddosx/v1/domains/test-domain.co.uk/waf");
        }

        [TestMethod]
        public async Task DeleteDomainWAFAsync_InvalidDomainName_ThrowsUKFastClientValidationException()
        {
            var ops = new DomainWAFOperations<WAF>(null);
            await Assert.ThrowsExceptionAsync<UKFastClientValidationException>(() => 
                ops.DeleteDomainWAFAsync(""));
        }
    }
}