namespace Klarna.Rest.Core.Common
{
    /// <summary>
    /// API Contollers Urls
    /// </summary>
    internal class ApiControllers
    {
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#checkout-api-create-a-new-order
        /// </summary>
        public const string Checkout = "checkout/v3/orders";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#payments-api-create-a-new-credit-session
        /// </summary>
        public const string PaymentSessions = "payments/v1/sessions";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#payments-api-cancel-an-existing-authorization
        /// </summary>
        public const string PaymentAuthorizations = "payments/v1/authorizations";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#order-management-api-release-remaining-authorization
        /// </summary>
        public const string OrderManagement = "ordermanagement/v1/orders";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#settlements-api-get-summary-of-payouts
        /// </summary>
        public const string SettlementPayouts = "settlements/v1/payouts";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#settlements-api-transactions
        /// </summary>
        public const string SettlementTransactions = "settlements/v1/transactions";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#settlements-api-get-pdf-payout-summary-report
        /// </summary>
        public const string SettlementReports = "settlements/v1/reports";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#customer-token-api-tokens
        /// </summary>
        public const string CustomerToken = "customer-token/v1/tokens";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#hosted-payment-page-api-create-a-new-hpp-session
        /// </summary>
        public const string HostedPaymentPage = "hpp/v1/sessions";
        
        /// <summary>
        /// Endpoint for https://developers.klarna.com/api/#merchant-card-service-api-create-a-new-settlement
        /// </summary>
        public const string VirtualCardService = "merchantcard/v3/settlements";
    }
}
