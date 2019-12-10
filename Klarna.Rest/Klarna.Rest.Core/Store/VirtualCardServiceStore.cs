using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.MerchantCardService;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// Merchant Card Service API
    /// The Merchant Card Service (MCS) API is used to settle orders with virtual credit cards.
    /// </summary>
    public class VirtualCardServiceStore : BaseStore
    {
        internal VirtualCardServiceStore(ApiSession apiSession, IJsonSerializer jsonSerializer) :
            base(apiSession, ApiControllers.VirtualCardService, jsonSerializer) { }

        /// <summary>
        /// Creates a new settlement
        /// To create a settlement resource provide a completed order identifier and (optionally) a promise identifier.
        /// </summary>
        /// <param name="request">The <see cref="VirtualCardCreateSettlementRequest"/> object</param>
        /// <returns>A single <see cref="SettlementResponse"/> object</returns>
        [Obsolete("VirtualCardCreateSettlementRequest and VirtualCardSettlement are using deprecated models. " +
                  "Please use SettlementRequest and SettlementResponse instead")]
        public async Task<SettlementResponse> CreateSettlement(VirtualCardCreateSettlementRequest request)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<SettlementResponse>(url, request).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Creates a new settlement
        /// To create a settlement resource provide a completed order identifier and (optionally) a promise identifier.
        /// </summary>
        /// <param name="request">The <see cref="VirtualCardCreateSettlementRequest"/> object</param>
        /// <returns>A single <see cref="SettlementResponse"/> object</returns>
        public async Task<SettlementResponse> CreateSettlement(SettlementRequest request)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<SettlementResponse>(url, request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an existing settlement
        /// To read the settlement resource provide the settlement identifier.
        /// </summary>
        /// <param name="settlementId">Unique settlement identifier.</param>
        /// <param name="keyId">Unique identifier for the public key used for encryption of the card data</param>
        /// <returns>A single <see cref="SettlementResponse"/> object</returns>
        public async Task<SettlementResponse> GetSettlement(string settlementId, string keyId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, settlementId);
            return await Get<SettlementResponse>(url, new Dictionary<string, string>{ { "KeyId", keyId } }).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Retrieves a settled order's settlement
        /// To read the order's settlement resource provide the order identifier.
        /// </summary>
        /// <param name="orderId">Unique identifier for the order associated to the settlement.</param>
        /// <param name="keyId">Unique identifier for the public key used for encryption of the card data.</param>
        /// <returns>A single <see cref="SettlementResponse"/> object</returns>
        public async Task<SettlementResponse> GetSettlementForOrder(string orderId, string keyId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"order/{orderId}");
            return await Get<SettlementResponse>(url, new Dictionary<string, string> { { "KeyId", keyId } }).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Create a new promise To create promise provide a purchase currency and the cards to be created.
        /// The old promise is automatically invalidated if a new promise is created for an order
        /// </summary>
        /// <param name="request">The <see cref="PromiseRequest"/> object</param>
        /// <returns>A single <see cref="PromiseCreatedResponse"/> object</returns>
        public async Task<PromiseCreatedResponse> CreatePromise(PromiseRequest request)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.VirtualCreditCardPromise);
            return await Post<PromiseCreatedResponse>(url, request).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Retrieve an existing promise.
        /// To read the promise resource simply provide a promise identifier.
        /// </summary>
        /// <param name="promiseId"></param>
        /// <returns>A single <see cref="SettlementResponse"/> object</returns>
        public async Task<SettlementResponse> ReadPromise(string promiseId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllers.VirtualCreditCardPromise, promiseId);
            return await Get<SettlementResponse>(url).ConfigureAwait(false);
        }
    }
}
