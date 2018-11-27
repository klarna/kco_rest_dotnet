using System.IO;
using System.Linq;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class CheckoutOrderTest
    {
        [Fact]
        public void CanReadJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CheckoutOrder.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserialize()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CheckoutOrder.json"));
            var checkoutOrder = JsonConvert.DeserializeObject<CheckoutOrder>(json);
            Assert.Equal("f3392f8b-6116-4073-ab96-e330819e2c07", checkoutOrder.OrderId);
        }
    }

    public class CallbackAddressUpdateTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackAddressUpdateRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackAddressUpdateResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackAddressUpdateRequest.json"));
            var request = JsonConvert.DeserializeObject<CallbackAddressUpdateRequest>(json);
            Assert.Equal(1, request.OrderLines.Count);
            Assert.Equal("john@doe.com", request.BillingCheckoutAddress.Email);
            Assert.Equal("333444555", request.ShippingCheckoutAddress.Phone);
            Assert.Equal("express_priority", request.SelectedShippingOption.Id);
            Assert.Equal("USD", request.PurchaseCurrency);
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackAddressUpdateResponse.json"));
            var response = JsonConvert.DeserializeObject<CallbackAddressUpdateResponse>(json);
            Assert.Equal(1, response.OrderLines.Count);
            Assert.Equal(OrderLineType.physical, response.OrderLines.First().Type);
            Assert.Equal("USD", response.PurchaseCurrency);
        }
    }
}
