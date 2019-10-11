using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Serialization;
using Klarna.Rest.Core.Store;

namespace Klarna.Rest.Core
{
    /// <summary>
    /// Client interface for the API resources
    /// </summary>
    public class Klarna
    {
        /// <summary>
        /// Checkout API
        /// The checkout API is used to create a checkout with Klarna and update the checkout order during the purchase.
        /// As soon as the purchase is completed the order should be read and handled using the Order Management API.
        /// <a href="https://developers.klarna.com/api/#checkout-api">
        ///     https://developers.klarna.com/api/#checkout-api
        /// </a>
        /// </summary>
        public CheckoutStore Checkout { get; }
        
        /// <summary>
        /// Payments API
        /// The payments API is used to create a session to offer Klarna's payment methods as part of your checkout.
        /// As soon as the purchase is completed the order should be read and handled using the Order Management API.
        /// <a href="https://developers.klarna.com/api/#payments-api">
        ///     https://developers.klarna.com/api/#payments-api
        /// </a>
        /// </summary>
        public PaymentStore Payment { get; }
        
        /// <summary>
        /// Order Management API
        /// The Order Management API is used for handling an order after the customer has completed the purchase.
        /// It is used for updating, capturing and refunding an order as well as to see the history of events that have
        /// affected this order.
        /// <a href="https://developers.klarna.com/api/#order-management-api">
        ///     https://developers.klarna.com/api/#order-management-api
        /// </a>
        /// </summary>
        public OrderManagementStore OrderManagement { get; }
        
        /// <summary>
        /// Settlements API
        /// This API gives you access to your payouts and transactions.
        /// Resources are split into two broad types:
        /// * Collections, including pagination information: collections are queryable, typically by the attributes of
        /// the sub-resource as well as pagination.
        /// * Entity resources containing a single entity.
        /// <a href="https://developers.klarna.com/api/#settlements-api">
        ///     https://developers.klarna.com/api/#settlements-api
        /// </a>
        /// </summary>
        public SettlementStore Settlement { get; }
        
        /// <summary>
        /// Customer Token API
        /// The Customer Token API is used to charge customers with a tokenized Klarna payment method and can be used
        /// for recurring purchases, subscriptions and for storing a customer's payment method. Tokens are created
        /// using the generate a customer token call in the payments API.
        /// <a href="https://developers.klarna.com/api/#customer-token-api">
        ///     https://developers.klarna.com/api/#customer-token-api
        /// </a>
        /// </summary>
        public CustomerTokenStore CustomerToken { get; }
        
        /// <summary>
        /// Hosted Payment Page API
        /// Hosted Payment Page (HPP) API is a service that lets you integrate Klarna Payments without the need of
        /// hosting the web page that manages the client side of Klarna Payments.
        /// A complete HPP payment session will involve three of Klarna services:
        /// * Klarna Payments API to start a payment session.
        /// * Hosted Payment Page API to distribute a payment session.
        /// * Order Management API to capture payment or refund consumer.
        /// <a href="https://developers.klarna.com/api/#hosted-payment-page-api">
        ///     https://developers.klarna.com/api/#hosted-payment-page-api
        /// </a>
        /// </summary>
        public HostedPaymentPageStore HostedPaymentPage { get; }
        
        /// <summary>
        /// Merchant Card Service API
        /// The Merchant Card Service (MCS) API is used to settle orders with virtual credit cards.
        /// <a href="https://developers.klarna.com/api/#merchant-card-service-api-virtual-credit-card-settlements">
        ///     https://developers.klarna.com/api/#merchant-card-service-api-virtual-credit-card-settlements
        /// </a>
        /// </summary>
        public VirtualCardServiceStore VirtualCardService { get; }
        
        /// <summary>
        /// The current API session object
        /// </summary>
        public ApiSession ApiSession { get; }

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="username">
        ///     Consists of your Merchant ID (eid) - a unique number that identifies your e-store, combined with a random string.
        /// </param>
        /// <param name="password">
        ///     a string which is associated with your Merchant ID and is used to authorize use of Klarna's APIs
        /// </param>
        /// <param name="environment">
        ///     The API is accessible through a few different URLS. There are different URLs for testing and for making
        ///     live purchases as well as different URLs for depending on if you are based in Europe or in the U.S.
        /// </param>
        /// <param name="userAgent">The user agent string used when calling the Klarna API</param>
        public Klarna(string username, string password, KlarnaEnvironment environment, string userAgent = "") :
            this(username, password, ApiUrlFromEnvironment(environment), userAgent) { }

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="credentials">DTO class for Klarna API Credentials</param>
        /// <param name="environment">
        ///     The API is accessible through a few different URLS. There are different URLs for testing and for making
        ///     live purchases as well as different URLs for depending on if you are based in Europe or in the U.S.
        /// </param>
        /// <param name="userAgent">The user agent string used when calling the Klarna API</param>
        public Klarna(ApiCredentials credentials, KlarnaEnvironment environment, string userAgent = "") :
            this(new ApiSession
            {
                ApiUrl = ApiUrlFromEnvironment(environment),
                UserAgent = userAgent,
                Credentials = credentials
            }) {}

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="username">
        ///     Consists of your Merchant ID (eid) - a unique number that identifies your e-store, combined with
        ///     a random string.
        /// </param>
        /// <param name="password">
        ///     a string which is associated with your Merchant ID and is used to authorize use of Klarna's APIs
        /// </param>
        /// <param name="apiUrl">
        ///     The API is accessible through a few different URLS. There are different URLs for testing and for
        ///     making live purchases as well as different URLs for depending on if you are based in Europe or
        ///     in the U.S.
        /// </param>
        /// <param name="userAgent">The user agent string used when calling the Klarna API</param>
        public Klarna(string username, string password, string apiUrl, string userAgent = "") :
            this(new ApiSession
            {
                ApiUrl = apiUrl,
                UserAgent = userAgent,
                Credentials = new ApiCredentials
                {
                    Username = username,
                    Password = password
                }
            }) {}

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="credentials">DTO class for Klarna API Credentials</param>
        /// <param name="apiUrl">
        ///     The API is accessible through a few different URLS. There are different URLs for testing and for
        ///     making live purchases as well as different URLs for depending on if you are based in
        ///     Europe or in the U.S.
        /// </param>
        /// <param name="userAgent">The user agent string used when calling the Klarna API</param>
        public Klarna(ApiCredentials credentials, string apiUrl, string userAgent = "") :
            this(new ApiSession { ApiUrl = apiUrl, UserAgent = userAgent, Credentials = credentials}) { }

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="apiSession">Session representation object for communicating with the Klarna API</param>
        public Klarna(ApiSession apiSession) : this(apiSession, new JsonSerializer()) { }

        /// <summary>
        /// Creates an instance of the Klarna client.
        /// </summary>
        /// <param name="apiSession">Session representation object for communicating with the Klarna API</param>
        /// <param name="jsonSerializer">Instance of a class implementing the IJsonSerializer interface</param>
        public Klarna(ApiSession apiSession, IJsonSerializer jsonSerializer)
        {
            if (string.IsNullOrEmpty(apiSession.UserAgent))
            {
                apiSession.UserAgent = GetDefaultUserAgent();
            }
            Checkout = new CheckoutStore(apiSession, jsonSerializer);
            Payment = new PaymentStore(apiSession, jsonSerializer);
            OrderManagement = new OrderManagementStore(apiSession, jsonSerializer);
            Settlement = new SettlementStore(apiSession, jsonSerializer);
            CustomerToken = new CustomerTokenStore(apiSession, jsonSerializer);
            HostedPaymentPage = new HostedPaymentPageStore(apiSession, jsonSerializer);
            VirtualCardService = new VirtualCardServiceStore(apiSession, jsonSerializer);
            ApiSession = apiSession;
        }
        
        /// <summary>
        /// Gets API URL from the environment.
        /// </summary>
        /// <param name="environment">Klarna environment</param>
        /// <returns>Klarna API URL</returns>
        public static string ApiUrlFromEnvironment(KlarnaEnvironment environment)
        {
            switch (environment)
            {
                case KlarnaEnvironment.LiveEurope: return Constants.ProdUrlEurope;
                case KlarnaEnvironment.LiveNorthAmerica: return Constants.ProdUrlNorthAmerica;
                case KlarnaEnvironment.TestingEurope: return Constants.TestUrlEurope;
                case KlarnaEnvironment.TestingNorthAmerica: return Constants.TestUrlNorthAmerica;
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Sets and provides default User Agent.
        /// </summary>
        /// <returns>Klarna User-Agent</returns>
        public static string GetDefaultUserAgent()
        {
            return $"Klarna .NET SDK/{Constants.Version} (+Klarna)";
        }
    }
}
