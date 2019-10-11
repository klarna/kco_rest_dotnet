using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Communication
{
    /// <summary>
    ///  A client store to keep API results
    /// </summary>
    public abstract class BaseStore : BaseRestClient
    {
        /// <summary>
        /// The API endpoint this store is interacting with
        /// </summary>
        protected readonly string ApiControllerUri;

        /// <summary>
        /// BaseStore Constructor
        /// </summary>
        /// <param name="apiSession">The API session instance used to communicate with Klarna APIs</param>
        /// <param name="apiControllerUri">The API endpoint to call</param>
        /// <param name="jsonSerializer">The JSON Serializer instance to use when sending / receiving data</param>
        /// <returns></returns>
        protected BaseStore(ApiSession apiSession, string apiControllerUri, IJsonSerializer jsonSerializer) :
            base(apiSession, jsonSerializer)
        {
            ApiControllerUri = apiControllerUri;
        }
    }
}