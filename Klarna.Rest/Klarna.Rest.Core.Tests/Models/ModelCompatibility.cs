using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.HostedPaymentPage;
using Klarna.Rest.Core.Model.OrderManagement;
using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    /// <summary>
    /// Test backward compatibility mode. Remove tests after removing obsolete models.
    /// </summary>
    public class ModelCompatibility
    {
        [Fact]
        public void HppSessionCreationCompatibility()
        {
            Assert.True(typeof(SessionResponseV1).IsSubclassOf(typeof(HostedPaymentPageSessionStatus)));
        }
        
        [Fact]
        public void OrderManagementCaptureCompatibility()
        {
            Assert.True(typeof(Capture).IsSubclassOf(typeof(OrderManagementCapture)));
        }
        
        [Fact]
        public void OrderManagementOrderCompatibility()
        {
            Assert.True(typeof(Order).IsSubclassOf(typeof(OrderManagementOrder)));
        }
        
        [Fact]
        public void OrderManagementRefundCompatibility()
        {
            Assert.True(typeof(Refund).IsSubclassOf(typeof(OrderManagementGetRefundResponse)));
        }
    }
}