using Klarna.Rest.Core.Common;
using Xunit;

namespace Klarna.Rest.Core.Tests
{
    public class ClientTest
    {
        [Fact]
        public void Client_TestEULiveUrl()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.LiveEurope);
            Assert.Equal("https://api.klarna.com/", client.ApiSession.ApiUrl);
        }

        [Fact]
        public void Client_TestNALiveUrl()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.LiveNorthAmerica);
            Assert.Equal("https://api-na.klarna.com/", client.ApiSession.ApiUrl);
        }

        [Fact]
        public void Client_TestEUTestingUrl()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.TestingEurope);
            Assert.Equal("https://api.playground.klarna.com/", client.ApiSession.ApiUrl);
        }

        [Fact]
        public void Client_TestNATestingUrl()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.TestingNorthAmerica);
            Assert.Equal("https://api-na.playground.klarna.com/", client.ApiSession.ApiUrl);
        }

        [Fact]
        public void Client_CheckoutStoreInitiated()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.TestingNorthAmerica);
            Assert.NotNull(client.Checkout);
        }

        [Fact]
        public void Client_PaymentStoreInitiated()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.TestingNorthAmerica);
            Assert.NotNull(client.Payment);
        }

        [Fact]
        public void Client_OrderManagementStoreInitiated()
        {
            var client = new Klarna(string.Empty, string.Empty, KlarnaEnvironment.TestingNorthAmerica);
            Assert.NotNull(client.OrderManagement);
        }
    }
}
