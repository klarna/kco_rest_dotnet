using System.IO;
using System.Linq;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class CallbackCountryChangeTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackCountryChangeRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackCountryChangeResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackCountryChangeRequest.json"));
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
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "CallbackCountryChangeResponse.json"));
            var response = JsonConvert.DeserializeObject<CallbackAddressUpdateResponse>(json);
            Assert.Equal(1, response.OrderLines.Count);
            Assert.Equal(OrderLineType.physical, response.OrderLines.First().Type);
            Assert.Equal("USD", response.PurchaseCurrency);
        }
    }
}