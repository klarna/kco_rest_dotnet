using System;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Payments;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// The payments API is used to create a session to offer Klarna's payment methods as part of your checkout.
    /// As soon as the purchase is completed the order should be read and handled using the Order Management API.
    /// </summary>
    public class PaymentStore : BaseStore
    {
        internal PaymentStore(ApiSession apiSession, IJsonSerializer jsonSerializer) :
            base(apiSession, ApiControllers.PaymentSessions, jsonSerializer) { }

        /// <summary>
        /// Creates a new credit session
        /// <a href="https://developers.klarna.com/api/#payments-api-create-a-new-credit-session">
        ///     https://developers.klarna.com/api/#payments-api-create-a-new-credit-session
        /// </a>
        /// </summary>
        /// <param name="creditSession">The <see cref="PaymentCreditSession"/>object</param>
        /// <returns><see cref="PaymentCreditSessionResponse"/></returns>
        [Obsolete("CreateCreditSession method with PaymentCreditSession model " +
                  "marked as obsolete. Use Session model instead")]
        public async Task<PaymentCreditSessionResponse> CreateCreditSession(PaymentCreditSession creditSession)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<PaymentCreditSessionResponse>(url, creditSession).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Creates a new credit session
        /// <a href="https://developers.klarna.com/api/#payments-api-create-a-new-credit-session">
        ///     https://developers.klarna.com/api/#payments-api-create-a-new-credit-session
        /// </a>
        /// </summary>
        /// <param name="session">The <see cref="Session"/>object</param>
        /// <returns><see cref="MerchantSession"/></returns>
        public async Task<MerchantSession> CreateCreditSession(Session session)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<MerchantSession>(url, session).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads an existing credit session
        /// <a href="https://developers.klarna.com/api/#payments-api-read-an-existing-credit-session">
        ///     https://developers.klarna.com/api/#payments-api-read-an-existing-credit-session
        /// </a>
        /// </summary>
        /// <param name="sessionId">Id of the credit session to retrieve</param>
        /// <returns><see cref="Session"/></returns>
        public async Task<Session> GetCreditSession(string sessionId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, sessionId);
            return await Get<Session>(url).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing credit session
        /// <a href="https://developers.klarna.com/api/#payments-api-update-an-existing-credit-session">
        ///     https://developers.klarna.com/api/#payments-api-update-an-existing-credit-session
        /// </a>
        /// </summary>
        /// <param name="sessionId">Id of the credit session to update</param>
        /// <param name="creditSession">The <see cref="PaymentCreditSession"/> object</param>
        /// <returns></returns>
        [Obsolete("UpdateCreditSession method with PaymentCreditSession model " +
                  "marked as obsolete. Use Session model instead")]
        public Task UpdateCreditSession(string sessionId, PaymentCreditSession creditSession)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, sessionId);
            return Post(url, creditSession);
        }
        
        /// <summary>
        /// Updates an existing credit session
        /// <a href="https://developers.klarna.com/api/#payments-api-update-an-existing-credit-session">
        ///     https://developers.klarna.com/api/#payments-api-update-an-existing-credit-session
        /// </a>
        /// </summary>
        /// <param name="sessionId">Id of the credit session to update</param>
        /// <param name="session">The <see cref="PaymentsSession"/> object</param>
        /// <returns></returns>
        public Task UpdateCreditSession(string sessionId, Session session)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, sessionId);
            return Post(url, session);
        }

        /// <summary>
        /// Cancels an existing authorization
        /// <a href="https://developers.klarna.com/api/#payments-api-cancel-an-existing-authorization">
        ///     https://developers.klarna.com/api/#payments-api-cancel-an-existing-authorization
        /// </a>
        /// </summary>
        /// <param name="authorizationToken">Authorization token from JS client</param>
        /// <returns></returns>
        public Task CancelAuthorization(string authorizationToken)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.PaymentAuthorizations, authorizationToken);
            return Delete(url);
        }

        /// <summary>
        /// Generates a consumer token
        /// <a href="https://developers.klarna.com/api/#payments-api-generate-a-consumer-token">
        ///     https://developers.klarna.com/api/#payments-api-generate-a-consumer-token
        /// </a>
        /// </summary>
        /// <param name="authorizationToken">Authorization token from JS client</param>
        /// <param name="consumerTokenRequest">The <see cref="PaymentGenerateConsumerTokenRequest"/> object</param>
        /// <returns><see cref="PaymentGenerateConsumerTokenResponse"/></returns>
        [Obsolete("GenerateConsumerToken method with PaymentGenerateConsumerTokenRequest model " +
                  "marked as obsolete. Use CustomerTokenCreationRequest model instead")]
        public async Task<PaymentGenerateConsumerTokenResponse> GenerateConsumerToken(string authorizationToken,
            PaymentGenerateConsumerTokenRequest consumerTokenRequest)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl,
                ApiControllers.PaymentAuthorizations,
                $"{authorizationToken}/customer-token");
            return await Post<PaymentGenerateConsumerTokenResponse>(url, consumerTokenRequest).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Generates a consumer token
        /// <a href="https://developers.klarna.com/api/#payments-api-generate-a-consumer-token">
        ///     https://developers.klarna.com/api/#payments-api-generate-a-consumer-token
        /// </a>
        /// </summary>
        /// <param name="authorizationToken">Authorization token from JS client</param>
        /// <param name="consumerTokenRequest">The <see cref="CustomerTokenCreationRequest"/> object</param>
        /// <returns><see cref="CustomerTokenCreationResponse"/></returns>
        public async Task<CustomerTokenCreationResponse> GenerateConsumerToken(string authorizationToken,
            CustomerTokenCreationRequest consumerTokenRequest)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl,
                ApiControllers.PaymentAuthorizations,
                $"{authorizationToken}/customer-token");
            return await Post<CustomerTokenCreationResponse>(url, consumerTokenRequest).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new order
        /// <a href="https://developers.klarna.com/api/#payments-api-create-a-new-order">
        ///     https://developers.klarna.com/api/#payments-api-create-a-new-order
        /// </a>
        /// </summary>
        /// <param name="authorizationToken">Authorization token from JS client</param>
        /// <param name="order">The <see cref="PaymentOrder"/> object</param>
        /// <returns><see cref="PaymentOrderResponse"/></returns>
        [Obsolete("CreateOrder method with PaymentOrder model " +
                  "marked as obsolete. Use CreateOrderRequest model instead")]
        public async Task<PaymentOrderResponse> CreateOrder(string authorizationToken, PaymentOrder order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl,
                ApiControllers.PaymentAuthorizations,
                $"{authorizationToken}/order");
            return await Post<PaymentOrderResponse>(url, order).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Creates a new order
        /// <a href="https://developers.klarna.com/api/#payments-api-create-a-new-order">
        ///     https://developers.klarna.com/api/#payments-api-create-a-new-order
        /// </a>
        /// </summary>
        /// <param name="authorizationToken">Authorization token from JS client</param>
        /// <param name="order">The <see cref="PaymentOrder"/> object</param>
        /// <returns><see cref="PaymentOrderResponse"/></returns>
        public async Task<Order> CreateOrder(string authorizationToken, CreateOrderRequest order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl,
                ApiControllers.PaymentAuthorizations,
                $"{authorizationToken}/order");
            return await Post<Order>(url, order).ConfigureAwait(false);
        }
    }
}
