using System.IO;
using Klarna.Rest.Core.Model;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class PaymentGenerateConsumerTokenTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "PaymentGenerateConsumerTokenRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "PaymentGenerateConsumerTokenResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "PaymentGenerateConsumerTokenRequest.json"));
            var request = JsonConvert.DeserializeObject<PaymentGenerateConsumerTokenRequest>(json);
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "PaymentGenerateConsumerTokenResponse.json"));
            var response = JsonConvert.DeserializeObject<PaymentGenerateConsumerTokenResponse>(json);
        }
    }
}