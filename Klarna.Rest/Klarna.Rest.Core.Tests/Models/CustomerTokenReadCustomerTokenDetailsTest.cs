using System.IO;
using Klarna.Rest.Core.Model;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class CustomerTokenReadCustomerTokenDetailsTest
    {
        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenReadCustomerTokenResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenReadCustomerTokenResponse.json"));
            var response = JsonConvert.DeserializeObject<CustomerTokenDetails>(json);
        }
    }

    public class CustomerTokenCreateOrderTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenCreateNewOrderRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenCreateNewOrderResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenCreateNewOrderRequest.json"));
            var request = JsonConvert.DeserializeObject<CustomerTokenOrder>(json);
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CustomerTokenCreateNewOrderResponse.json"));
            var response = JsonConvert.DeserializeObject<CustomerTokenCreateOrderResponse>(json);
        }
    }

    public class HostedPaymentPageCreateSessionTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageCreateSessionRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageCreateSessionResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageCreateSessionRequest.json"));
            var request = JsonConvert.DeserializeObject<HostedPaymentPageCreateSessionRequest>(json);
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageCreateSessionResponse.json"));
            var response = JsonConvert.DeserializeObject<HostedPaymentPageCreateSessionResponse>(json);
        }
    }

    public class HostedPaymentPageDistributeLinkTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageDistributeLinkToSessionRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageDistributeLinkToSessionRequest.json"));
            var request = JsonConvert.DeserializeObject<HostedPaymentPageDistributeLink>(json);
        }
    }

    public class HostedPaymentPageGetSessionStatusTest
    {
        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageGetSessionStatusResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "HostedPaymentPageGetSessionStatusResponse.json"));
            var response = JsonConvert.DeserializeObject<HostedPaymentPageSessionStatus>(json);
        }
    }

    public class VirtualCardServiceCreateSettlementTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceCreateSettlementRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceCreateSettlementResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceCreateSettlementRequest.json"));
            var request = JsonConvert.DeserializeObject<VirtualCardCreateSettlementRequest>(json);
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceCreateSettlementResponse.json"));
            var response = JsonConvert.DeserializeObject<VirtualCardSettlement>(json);
        }
    }

    public class VirtualCardServiceRetrieveSettlementTest
    {
        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceGetExistingSettlementResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceGetExistingSettlementResponse.json"));
            var response = JsonConvert.DeserializeObject<VirtualCardSettlement>(json);
        }
    }

    public class VirtualCardServiceRetrieveSettledOrdersSettlementTest
    {
        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceGetSettledOrdersSettlementResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "VirtualCardServiceGetSettledOrdersSettlementResponse.json"));
            var response = JsonConvert.DeserializeObject<VirtualCardSettlement>(json);
        }
    }

}