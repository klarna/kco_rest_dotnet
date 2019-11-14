using System;
using System.Threading.Tasks;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using HppModel = Klarna.Rest.Core.Model.HostedPaymentPage;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Store
{
    /// <summary>
    /// Hosted Payment Page API
    /// Hosted Payment Page (HPP) API is a service that lets you integrate Klarna Payments without the need of hosting
    /// the web page that manages the client side of Klarna Payments.
    /// 
    /// A complete HPP payment session will involve three of Klarna services:
    /// * Klarna Payments API to start a payment session.
    /// * Hosted Payment Page API to distribute a payment session.
    /// * Order Management API to capture payment or refund consumer.
    /// </summary>
    public class HostedPaymentPageStore : BaseStore
    {
        internal HostedPaymentPageStore(ApiSession apiSession, IJsonSerializer jsonSerializer) :
            base(apiSession, ApiControllers.HostedPaymentPage, jsonSerializer) { }

        /// <summary>
        /// Creates a new HPP session
        /// </summary>
        /// <param name="session">The <see cref="HostedPaymentPageCreateSessionRequest"/> object</param>
        /// <returns>A single <see cref="HostedPaymentPageCreateSessionResponse"/> object</returns>
        [Obsolete("HostedPaymentPageCreateSessionResponse and HostedPaymentPageCreateSessionRequest are " +
                  "using the old model. Please use SessionCreationResponseV1 and SessionCreationRequestV1 instead")]
        public async Task<HostedPaymentPageCreateSessionResponse> CreateSession(
            HostedPaymentPageCreateSessionRequest session)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<HostedPaymentPageCreateSessionResponse>(url, session).ConfigureAwait(false);
        }

        /// <summary>
        /// Creates a new HPP session
        /// </summary>
        /// <param name="session">The <see cref="HppModel.SessionCreationRequestV1"/> object</param>
        /// <returns>A single <see cref="HppModel.SessionCreationResponseV1"/> object</returns>
        public async Task<HppModel.SessionCreationResponseV1> CreateSession(
            HppModel.SessionCreationRequestV1 session)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri);
            return await Post<HppModel.SessionCreationResponseV1>(url, session).ConfigureAwait(false);
        }

        /// <summary>
        /// Distributes link to the HPP session
        /// </summary>
        /// <param name="sessionId">HPP session id</param>
        /// <param name="distribution">The <see cref="HostedPaymentPageDistributeLink"/>object</param>
        /// <returns></returns>
        [Obsolete("HostedPaymentPageDistributeLink using the old model. Please use DistributionRequestV1 instead")]
        public Task DistributeLinkToSession(string sessionId, HostedPaymentPageDistributeLink distribution)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{sessionId}/distribution");
            return Post(url, distribution);
        }

        /// <summary>
        /// Distributes link to the HPP session
        /// </summary>
        /// <param name="sessionId">HPP session id</param>
        /// <param name="distribution">The <see cref="HppModel.DistributionRequestV1"/>object</param>
        /// <returns></returns>
        public Task DistributeLinkToSession(string sessionId, HppModel.DistributionRequestV1 distribution)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{sessionId}/distribution");
            return Post(url, distribution);
        }

        /// <summary>
        /// Gets HPP session status
        /// </summary>
        /// <param name="sessionId">HPP session id</param>
        /// <returns>A single <see cref="HppModel.SessionResponseV1"/> object</returns>
        public async Task<HppModel.SessionResponseV1> GetSessionStatus(string sessionId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{sessionId}");
            return await Get<HppModel.SessionResponseV1>(url).ConfigureAwait(false);
        }

        /// <summary>
        /// Disables HPP session
        /// </summary>
        /// <param name="sessionId">HPP session id</param>
        /// <returns></returns>
        public Task DisableSession(string sessionId)
        {
            var url = ApiUrlHelper.GetApiUrlForController(ApiSession.ApiUrl, ApiControllerUri, $"{sessionId}");
            return Delete(url);
        }
    }
}
