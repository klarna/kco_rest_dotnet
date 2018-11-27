using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Commuication
{
    public abstract class BaseStore : BaseRestClient
    {
        protected readonly string ApiControllerUri;

        protected BaseStore(ApiSession apiSession, string apiControllerUri, IJsonSerializer jsonSerializer) : base(apiSession, jsonSerializer)
        {
            ApiControllerUri = apiControllerUri;
        }
    }
}