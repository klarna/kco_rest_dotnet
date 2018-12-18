using System.Collections.Generic;
using System.IO;
using Klarna.Rest.Core.Model;
using Newtonsoft.Json;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    public class OrderManagementGetAllCapturesForOneOrderTest
    {
        [Fact]
        public void CanReadResponseJson()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "OrderManagementGetAllCapturesForOneOrderResponse.json"));
            Assert.True(!string.IsNullOrEmpty(json));
        }

        [Fact]
        public void CanDeserializeResponse()
        {
            var json = File.ReadAllText(Path.Combine(System.Environment.CurrentDirectory, "Data", "OrderManagementGetAllCapturesForOneOrderResponse.json"));
            var response = JsonConvert.DeserializeObject<List<OrderManagementCapture>>(json);
        }
    }
}