using System.IO;
using Klarna.Rest.Core.Model;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class OrderManagementSetNewOrderAmountAndOrderLinesTest
    {
        [Fact]
        public void CanReadRequestJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "OrderManagementSetNewOrderAmountAndOrderLinesRequest.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeRequest()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "OrderManagementSetNewOrderAmountAndOrderLinesRequest.json"));
            var request = JsonConvert.DeserializeObject<OrderManagementSetNewOrderAmountAndLines>(json);
        }
    }
}