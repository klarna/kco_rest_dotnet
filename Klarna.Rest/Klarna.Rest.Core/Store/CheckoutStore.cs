using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// The checkout API is used to create a checkout with Klarna and update the checkout order during the purchase.
    /// As soon as the purchase is completed the order should be read and handled using the Order Management API.
    /// </summary>
    public class CheckoutStore : BaseStore
    {
        internal CheckoutStore(ApiSession apiSession, IJsonSerializer jsonSerializer) : 
            base(apiSession, ApiControllers.Checkout, jsonSerializer) { }

        /// <summary>
        /// Use this API call to create a new order. 
        /// <a href="https://developers.klarna.com/api/#checkout-api-create-a-new-order">
        ///     https://developers.klarna.com/api/#checkout-api-create-a-new-order
        /// </a>
        /// </summary>
        /// <param name="order">The <see cref="CheckoutOrder"/> object</param>
        /// <returns><see cref="CheckoutOrder"/></returns>
        public async Task<CheckoutOrder> CreateOrder(CheckoutOrder order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<CheckoutOrder>(url, order).ConfigureAwait(false);
        }

        /// <summary>
        /// Use this API call to read an order from Klarna.
        /// Note that orders should only be read from the checkout API until the order is completed.
        /// Completed orders should be read using the order management API
        /// <a href="https://developers.klarna.com/api/#checkout-api-retrieve-an-order">
        ///     https://developers.klarna.com/api/#checkout-api-retrieve-an-order
        /// </a>
        /// </summary>
        /// <param name="orderId">ID of the order to retrieve</param>
        /// <returns><see cref="CheckoutOrder"/></returns>
        public async Task<CheckoutOrder> GetOrder(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, orderId);
            return await Get<CheckoutOrder>(url).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates an existing order.
        /// Please note: an order can only be updated when the status is 'checkout_incomplete'.
        /// <a href="https://developers.klarna.com/api/#checkout-api-update-an-order">
        ///     https://developers.klarna.com/api/#checkout-api-update-an-order
        /// </a>
        /// </summary>
        /// <param name="order">The <see cref="CheckoutOrder"/> object</param>
        /// <returns><see cref="CheckoutOrder"/></returns>
        public async Task<CheckoutOrder> UpdateOrder(CheckoutOrder order)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, order.OrderId);
            return await Post<CheckoutOrder>(url, order).ConfigureAwait(false);
        }
    }
}
