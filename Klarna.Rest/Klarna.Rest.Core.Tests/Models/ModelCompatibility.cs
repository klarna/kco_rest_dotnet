using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.CustomerToken;
using Klarna.Rest.Core.Model.HostedPaymentPage;

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
        public void CustomerTokenCompatibility()
        {
            Assert.True(typeof(CustomerTokenV1).IsSubclassOf(typeof(CustomerTokenDetails)));
        }
    }
}