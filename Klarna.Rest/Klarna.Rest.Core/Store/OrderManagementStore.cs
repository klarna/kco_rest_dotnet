using System.Collections.Generic;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// The Order Management API is used for handling an order after the customer has completed the purchase. It is used for updating, capturing and refunding an order as well as to see the history of events that have affected this order.
    /// </summary>
    public class OrderManagementStore : BaseStore
    {
        internal OrderManagementStore(ApiSession apiSession, IJsonSerializer jsonSerializer) : base(apiSession, ApiControllers.OrderManagement, jsonSerializer) { }

        /// <summary>
        /// Release remaining authorization
        /// <a href="https://developers.klarna.com/api/#order-management-api-release-remaining-authorization">https://developers.klarna.com/api/#order-management-api-release-remaining-authorization</a>
        /// </summary>
        /// <param name="orderId">Id of order to release</param>
        /// <returns></returns>
        public async Task ReleaseRemainingAuthorization(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/release-remaining_authorization");

            await Post(url);
        }

        /// <summary>
        /// Extend authorization time
        /// <a href="https://developers.klarna.com/api/#order-management-api-extend-authorization-time">https://developers.klarna.com/api/#order-management-api-extend-authorization-time</a>
        /// </summary>
        /// <param name="orderId">Id of order to extend</param>
        /// <returns></returns>
        public async Task ExtendAuthorizationTime(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/extend-authorization-time");

            await Post(url);
        }

        /// <summary>
        /// Update customer addresses
        /// <a href="https://developers.klarna.com/api/#order-management-api-update-customer-addresses">https://developers.klarna.com/api/#order-management-api-update-customer-addresses</a>
        /// </summary>
        /// <param name="orderId">Id of order to update</param>
        /// <param name="customerAddresses">The <see cref="UpdateCustomerAddresses"/> object</param>
        /// <returns></returns>
        public async Task UpdateCustomerAddresses(string orderId, OrderManagementCustomerAddresses customerAddresses)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/customer-details");

            await Patch(url, customerAddresses);
        }

        /// <summary>
        /// Cancel order
        /// <a href="https://developers.klarna.com/api/#order-management-api-cancel-order">https://developers.klarna.com/api/#order-management-api-cancel-order</a>
        /// </summary>
        /// <param name="orderId">Id of order to cancel</param>
        /// <returns></returns>
        public async Task CancelOrder(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/cancel");

            await Post(url);
        }

        /// <summary>
        /// Update merchant references
        /// <a href="https://developers.klarna.com/api/#order-management-api-update-merchant-references">https://developers.klarna.com/api/#order-management-api-update-merchant-references</a>
        /// </summary>
        /// <param name="orderId">Id of order to update</param>
        /// <param name="merchantReferences">The <see cref="OrderManagementMerchantReferences"/> object</param>
        /// <returns></returns>
        public async Task UpdateMerchantReferences(string orderId, OrderManagementMerchantReferences merchantReferences)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/merchant-references");

            await Patch(url, merchantReferences);
        }

        /// <summary>
        /// Acknowledge order
        /// <a href="https://developers.klarna.com/api/#order-management-api-acknowledge-order">https://developers.klarna.com/api/#order-management-api-acknowledge-order</a>
        /// </summary>
        /// <param name="orderId">Id of order to acknowledge</param>
        /// <returns></returns>
        public async Task AcknowledgeOrder(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/acknowledge");

            await Post(url);
        }

        /// <summary>
        /// Get order
        /// <a href="https://developers.klarna.com/api/#order-management-api-get-order">https://developers.klarna.com/api/#order-management-api-get-order</a>
        /// </summary>
        /// <param name="orderId">Id of order to retrieve</param>
        /// <returns><see cref="OrderManagementOrder"/></returns>
        public async Task<OrderManagementOrder> GetOrder(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}");

            var response = await Get<OrderManagementOrder>(url);

            return response;
        }

        /// <summary>
        /// Set new order amount and order lines
        /// <a href="https://developers.klarna.com/api/#order-management-api-set-new-order-amount-and-order-lines">https://developers.klarna.com/api/#order-management-api-set-new-order-amount-and-order-lines</a>
        /// </summary>
        /// <param name="orderId">Id of order to update</param>
        /// <param name="newOrderAmountAndLines">The <see cref="OrderManagementSetNewOrderAmountAndLines"/> object</param>
        /// <returns></returns>
        public async Task SetNewOrderAmountAndOrderLines(string orderId, OrderManagementSetNewOrderAmountAndLines newOrderAmountAndLines)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/authorization");

            await Patch(url, newOrderAmountAndLines);
        }

        /// <summary>
        /// Get one capture
        /// <a href="https://developers.klarna.com/api/#order-management-api-get-one-capture">https://developers.klarna.com/api/#order-management-api-get-one-capture</a>
        /// </summary>
        /// <param name="orderId">Id of order that contains the capture</param>
        /// <param name="captureId">Id of capture to retrieve</param>
        /// <returns><see cref="OrderManagementCapture"/></returns>
        public async Task<OrderManagementCapture> GetCapture(string orderId, string captureId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/captures/{captureId}");

            var response = await Get<OrderManagementCapture>(url);

            return response;
        }

        /// <summary>
        /// Trigger resend of customer communication
        /// <a href="https://developers.klarna.com/api/#order-management-api-trigger-resend-of-customer-communication">https://developers.klarna.com/api/#order-management-api-trigger-resend-of-customer-communication</a>
        /// </summary>
        /// <param name="orderId">Id of order that contains the capture</param>
        /// <param name="captureId">Id of capture to resend</param>
        /// <returns></returns>
        public async Task TriggerResendOfCustomerCommunication(string orderId, string captureId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/captures/{captureId}/trigger-send-out");

            await Post(url);
        }

        /// <summary>
        /// Get all captures for one order
        /// <a href="https://developers.klarna.com/api/#order-management-api-get-all-captures-for-one-order">https://developers.klarna.com/api/#order-management-api-get-all-captures-for-one-order</a>
        /// </summary>
        /// <param name="orderId">Id of order to retrieve captures</param>
        /// <returns>Collection of <see cref="OrderManagementCapture"/></returns>
        public async Task<ICollection<OrderManagementCapture>> GetCapturesForOrder(string orderId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/captures");

            var response = await Get<ICollection<OrderManagementCapture>>(url);

            return response;
        }

        /// <summary>
        /// Create capture
        /// <a href="https://developers.klarna.com/api/#order-management-api-create-capture">https://developers.klarna.com/api/#order-management-api-create-capture</a>
        /// </summary>
        /// <param name="orderId">Id of order to create capture</param>
        /// <param name="capture">The <see cref="OrderManagementCapture"/> object</param>
        /// <returns>Object of <see cref="OrderManagementCapture"/> </returns>
        public async Task<OrderManagementCapture> CreateCapture(string orderId, OrderManagementCreateCapture capture)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/captures");

            OrderManagementCapture response = await Post<OrderManagementCapture>(url, capture);
            return response;
        }

        /// <summary>
        /// Add shipping info to a capture
        /// <a href="https://developers.klarna.com/api/#order-management-api-add-shipping-info-to-a-capture">https://developers.klarna.com/api/#order-management-api-add-shipping-info-to-a-capture</a>
        /// </summary>
        /// <param name="orderId">Id of order to add shipping info</param>
        /// <param name="captureId">Id of capture to add shipping info</param>
        /// <param name="shippingInfo">The <see cref="OrderManagementAddShippingInfo"/> object</param>
        /// <returns></returns>
        public async Task AddShippingInfoToCapture(string orderId, string captureId, OrderManagementAddShippingInfo shippingInfo)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/captures/{captureId}/shipping-info");

            await Post(url, shippingInfo);
        }

        /// <summary>
        /// Create a refund
        /// <a href="https://developers.klarna.com/api/#order-management-api-create-a-refund">https://developers.klarna.com/api/#order-management-api-create-a-refund</a>
        /// </summary>
        /// <param name="orderId">Id of order to create a refund</param>
        /// <param name="refund">The <see cref="OrderManagementRefund"/> object</param>
        /// <returns></returns>
        public async Task CreateRefund(string orderId, OrderManagementRefund refund)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/refunds");

            await Post(url, refund);
        }

        /// <summary>
        /// Get refund
        /// <a href="https://developers.klarna.com/api/#order-management-api-get-refund">https://developers.klarna.com/api/#order-management-api-get-refund</a>
        /// </summary>
        /// <param name="orderId">Id of order to get refund</param>
        /// <param name="refundId">Id of refund</param>
        /// <returns></returns>
        public async Task<OrderManagementGetRefundResponse> GetRefundForOrder(string orderId, string refundId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{orderId}/refunds/{refundId}");

            return await Get<OrderManagementGetRefundResponse>(url);
        }
    }
}