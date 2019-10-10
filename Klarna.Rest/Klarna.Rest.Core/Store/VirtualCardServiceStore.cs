using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
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
        /// <returns>A single <see cref="VirtualCardSettlement"/> object</returns>
        public async Task<VirtualCardSettlement> CreateSettlement(VirtualCardCreateSettlementRequest request)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<VirtualCardSettlement>(url, request).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves an existing settlement
        /// To read the settlement resource provide the settlement identifier.
        /// </summary>
        /// <param name="settlementId">Unique settlement identifier.</param>
        /// <param name="keyId">Unique identifier for the public key used for encryption of the card data</param>
        /// <returns>A single <see cref="VirtualCardSettlement"/> object</returns>
        public async Task<VirtualCardSettlement> GetSettlement(string settlementId, string keyId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, settlementId);
            return await Get<VirtualCardSettlement>(url, new Dictionary<string, string>{ { "KeyId", keyId } }).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a settled order's settlement
        /// To read the order's settlement resource provide the order identifier.
        /// </summary>
        /// <param name="orderId">Unique identifier for the order associated to the settlement.</param>
        /// <param name="keyId">Unique identifier for the public key used for encryption of the card data.</param>
        /// <returns>A single <see cref="VirtualCardSettlement"/> object</returns>
        public async Task<VirtualCardSettlement> GetSettlementForOrder(string orderId, string keyId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"order/{orderId}");
            return await Get<VirtualCardSettlement>(url, new Dictionary<string, string> { { "KeyId", keyId } }).ConfigureAwait(false);
        }
    }
}
