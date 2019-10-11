using System;
using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Commuication
{
    /// <summary>
    /// A base class for HTTP clients used to communicate with the Klarna APIs
    /// </summary>
    [Obsolete("Use Communication namespace instead of Commuication")]
    public abstract class BaseRestClient : Communication.BaseRestClient
    {
        protected BaseRestClient(ApiSession apiSession, IJsonSerializer jsonSerializer) : base(apiSession, jsonSerializer)
        { }
    }
}
