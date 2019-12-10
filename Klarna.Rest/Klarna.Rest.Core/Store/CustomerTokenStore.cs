using System;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.CustomerToken;
using Klarna.Rest.Core.Serialization;
using CustomerTokenOrder = Klarna.Rest.Core.Model.CustomerTokenOrder;
using TokenOrder = Klarna.Rest.Core.Model.CustomerToken.CustomerTokenOrder;
using TokenOrderResponse = Klarna.Rest.Core.Model.CustomerToken.Order;
using CustomerTokenStatusUpdateRequest = Klarna.Rest.Core.Model.CustomerTokenStatusUpdateRequest;
using StatusUpdateRequest = Klarna.Rest.Core.Model.CustomerToken.CustomerTokenStatusUpdateRequest;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// Customer Token API
    /// The Customer Token API is used to charge customers with a tokenized Klarna payment method and can be used
    /// for recurring purchases, subscriptions and for storing a customer's payment method. Tokens are created using
    /// the generate a customer token call in the payments API.
    /// </summary>
    public class CustomerTokenStore : BaseStore
    {
        internal CustomerTokenStore(ApiSession apiSession, IJsonSerializer jsonSerializer) :
            base(apiSession, ApiControllers.CustomerToken, jsonSerializer) { }

        /// <summary>
        /// Reads customer tokens details
        /// </summary>
        /// <param name="customerToken">Customer token</param>
        /// <returns><see cref="CustomerTokenDetails"/></returns>
        public async Task<CustomerTokenV1> GetCustomerTokenDetails(string customerToken)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, customerToken);

            return await Get<CustomerTokenV1>(url).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new order using the customer token
        /// </summary>
        /// <param name="customerToken">Customer token</param>
        /// <param name="order">A <see cref="Model.CustomerTokenOrder"/> object</param>
        /// <returns><see cref="CustomerTokenCreateOrderResponse"/></returns>
        [Obsolete("CreateOrder method with CustomerTokenOrder model marked as obsolete." +
                  "Use CustomerTokenOrder model from Klarna.Rest.Core.Model.CustomerToken namespace instead")]
        public async Task<CustomerTokenCreateOrderResponse> CreateOrder(string customerToken, CustomerTokenOrder order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{customerToken}/order");
            return await Post<CustomerTokenCreateOrderResponse>(url, order).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Creates a new order using the customer token
        /// </summary>
        /// <param name="customerToken">Customer token</param>
        /// <param name="order">A <see cref="TokenOrder"/> object</param>
        /// <returns><see cref="TokenOrderResponse"/></returns>
        public async Task<TokenOrderResponse> CreateOrder(string customerToken, TokenOrder order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{customerToken}/order");
            return await Post<TokenOrderResponse>(url, order).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the status of a customer token
        /// </summary>
        /// <param name="customerToken">Customer token</param>
        /// <param name="update">A <see cref="Model.CustomerTokenStatusUpdateRequest"/> object</param>
        /// <returns><see cref="CustomerTokenCreateOrderResponse"/></returns>
        [Obsolete("UpdateStatus method with CustomerTokenStatusUpdateRequest model marked as obsolete." +
                  "Use CustomerTokenStatusUpdateRequest model from Klarna.Rest.Core.Model.CustomerToken namespace instead")]
        public Task UpdateStatus(string customerToken, CustomerTokenStatusUpdateRequest update)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{customerToken}/status");
            return Patch(url, update);
        }
        
        /// <summary>
        /// Updates the status of a customer token
        /// </summary>
        /// <param name="customerToken">Customer token</param>
        /// <param name="update">A <see cref="Model.CustomerToken.CustomerTokenStatusUpdateRequest"/> object</param>
        /// <returns><see cref="StatusUpdateRequest"/></returns>
        public Task UpdateStatus(string customerToken, StatusUpdateRequest update)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{customerToken}/status");
            return Patch(url, update);
        }
    }
}
