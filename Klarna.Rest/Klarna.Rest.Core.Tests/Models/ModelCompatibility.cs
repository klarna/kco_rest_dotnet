
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.CustomerToken;
using Klarna.Rest.Core.Model.HostedPaymentPage;
using Klarna.Rest.Core.Model.Payments;
using Checkout = Klarna.Rest.Core.Model.Checkout;
using MerchantCardService = Klarna.Rest.Core.Model.MerchantCardService;
using OrderManagement = Klarna.Rest.Core.Model.OrderManagement;
using Settlements = Klarna.Rest.Core.Model.Settlements;

using Xunit;

namespace Klarna.Rest.Core.Tests.Models
{
    /// <summary>
    /// Test backward compatibility mode. Remove tests after removing obsolete models.
    /// </summary>
    public class ModelCompatibility
    {
        [Fact]
        public void PaymentsSessionCompatibility()
        {
            Assert.True(typeof(Session).IsSubclassOf(typeof(PaymentCreditSession)));
        }

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

        [Fact]
        public void OrderManagementCaptureCompatibility()
        {
            Assert.True(typeof(OrderManagement.Capture).IsSubclassOf(typeof(OrderManagementCapture)));
        }

        [Fact]
        public void OrderManagementOrderCompatibility()
        {
            Assert.True(typeof(OrderManagement.Order).IsSubclassOf(typeof(OrderManagementOrder)));
        }

        [Fact]
        public void OrderManagementRefundCompatibility()
        {
            Assert.True(typeof(OrderManagement.Refund).IsSubclassOf(typeof(OrderManagementGetRefundResponse)));
        }

        [Fact]
        public void CheckoutOrderCompatibility()
        {
            Assert.True(typeof(Checkout.Order).IsSubclassOf(typeof(CheckoutOrder)));
        }

        [Fact]
        public void SettlementsPayoutSummaryCompatibility()
        {
            Assert.True(typeof(Settlements.PayoutSummary).IsSubclassOf(typeof(SettlementsPayoutSummary)));
        }

        [Fact]
        public void SettlementsPayoutCompatibility()
        {
            Assert.True(typeof(Settlements.Payout).IsSubclassOf(typeof(SettlementsPayout)));
        }

        [Fact]
        public void SettlementsPayoutCollectionCompatibility()
        {
            Assert.True(typeof(Settlements.PayoutCollection).IsSubclassOf(typeof(SettlementsGetAllPayoutsResponse)));
        }

        [Fact]
        public void SettlementsTransactionCollectionCompatibility()
        {
            Assert.True(typeof(Settlements.TransactionCollection).IsSubclassOf(typeof(SettlementsGetTransactionsResponse)));
        }

        [Fact]
        public void SettlementsTransactionCompatibility()
        {
            Assert.True(typeof(Settlements.Transaction).IsSubclassOf(typeof(Transaction)));
        }

        [Fact]
        public void SettlementsTotalsCompatibility()
        {
            Assert.True(typeof(Settlements.Totals).IsSubclassOf(typeof(SettlementsPayoutTotals)));
        }

        [Fact]
        public void SettlementsPaginationCompatibility()
        {
            Assert.True(typeof(Settlements.Pagination).IsSubclassOf(typeof(Pagination)));
        }

        [Fact]
        public void SettlementsErrorResponseCompatibility()
        {
            Assert.True(typeof(Settlements.ErrorResponse).IsSubclassOf(typeof(ErrorMessage)));
        }

        [Fact]
        public void MerchantCardServiceCardCompatibility()
        {
            Assert.True(typeof(MerchantCardService.Card).IsSubclassOf(typeof(VirtualCardCard)));
        }

        [Fact]
        public void MerchantCardServiceSettlementRequestCompatibility()
        {
            Assert.True(typeof(MerchantCardService.SettlementRequest).IsSubclassOf(typeof(VirtualCardCreateSettlementRequest)));
        }
    }
}