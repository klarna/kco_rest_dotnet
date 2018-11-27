namespace Klarna.Rest.Core.Common
{
    internal class ApiControllers
    {
        public const string Checkout = "checkout/v3/orders";
        public const string PaymentSessions = "payments/v1/sessions";
        public const string PaymentAuthorizations = "payments/v1/authorizations";
        public const string OrderManagement = "ordermanagement/v1/orders";
        public const string SettlementPayouts = "settlements/v1/payouts";
        public const string SettlementTransactions = "settlements/v1/transactions";
        public const string SettlementReports = "settlements/v1/reports";
        public const string CustomerToken = "customer-token/v1/tokens";
        public const string HostedPaymentPage = "hpp/v1/sessions";
        public const string VirtualCardService = "merchantcard/v3/settlements";
    }
}
