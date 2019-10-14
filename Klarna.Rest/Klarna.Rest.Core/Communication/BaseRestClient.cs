using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Klarna.Rest.Core.Communication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Communication
{
    /// <summary>
    /// A base class for HTTP clients used to communicate with the Klarna APIs
    /// </summary>
    public abstract class BaseRestClient
    {
        /// <summary>
        /// Session information related to this RestClient
        /// </summary>
        protected readonly ApiSession ApiSession;

        private readonly IJsonSerializer _jsonSerializer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiSession">The API session instance used to communicate with Klarna APIs</param>
        /// <param name="jsonSerializer">The JSON Serializer instance to use when sending / receiving data</param>
        protected BaseRestClient(ApiSession apiSession, IJsonSerializer jsonSerializer)
        {
            ApiSession = apiSession;
            _jsonSerializer = jsonSerializer;
        }

        /// <summary>
        /// Handles HTTP POST calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <returns></returns>
        protected Task Post(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            return MakeRequest(HttpMethod.Post, url, data, headers, outResponse);
        }
        
        /// <summary>
        /// Handles HTTP POST calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <typeparam name="T">Type to convert response message to</typeparam>
        /// <returns>HTTP response deserialized to T type</returns>
        protected async Task<T> Post<T>(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            var result = await MakeRequest(HttpMethod.Post, url, data, headers, outResponse).ConfigureAwait(false);
            return await DeserializeOrDefault<T>(result).ConfigureAwait(false);
        }

        /// <summary>
        /// Handles HTTP PATCH calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <returns></returns>
        protected Task Patch(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            return MakeRequest(new HttpMethod("PATCH"), url, data, headers, outResponse);
        }

        /// <summary>
        /// Handles HTTP DELETE calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <returns></returns>
        protected Task Delete(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            return MakeRequest(HttpMethod.Delete, url, data, headers, outResponse);
        }
        
        /// <summary>
        /// Handles HTTP PATCH calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <typeparam name="T">Type to convert response message to</typeparam>
        /// <returns>HTTP response deserialized to T type</returns>
        protected async Task<T> Delete<T>(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            var result = await MakeRequest(HttpMethod.Delete, url, data, headers, outResponse).ConfigureAwait(false);
            return await DeserializeOrDefault<T>(result).ConfigureAwait(false);
        }

        /// <summary>
        /// Handles HTTP PUT calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <typeparam name="T">Type to convert response message to</typeparam>
        /// <returns>HTTP response deserialized to T type</returns>
        protected async Task<T> Put<T>(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            
            var result = await MakeRequest(HttpMethod.Put, url, data, headers, outResponse).ConfigureAwait(false);
            return await DeserializeOrDefault<T>(result).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Handles HTTP PUT calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="data">The data to send</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <returns></returns>
        protected Task Put(string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            return MakeRequest(HttpMethod.Put, url, data, headers, outResponse);
        }

        /// <summary>
        /// Handles HTTP GET calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="outResponse">Ref to raw HttpResponseMessage message</param>
        /// <typeparam name="T">Type to convert response message to</typeparam>
        /// <returns>HTTP response deserialized to T type</returns>
        protected async Task<T> Get<T>(string url,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            var result = await MakeRequest(HttpMethod.Get, url, null, headers, outResponse).ConfigureAwait(false);
            return await DeserializeOrDefault<T>(result).ConfigureAwait(false);
        }

        /// <summary>
        /// Handles HTTP GET calls
        /// </summary>
        /// <param name="url">The URL to call</param>
        /// <param name="headers">The HTTP headers to send when performing a request</param>
        /// <param name="response">Ref to raw HttpResponseMessage message</param>
        /// <returns></returns>
        protected Task Get(string url,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> response = null)
        {
            return MakeRequest(HttpMethod.Get, url, null, headers, response);
        }

        /// <summary>
        /// Performs an HTTP call and returns result as a binary stream.
        /// Used to download binary/text files, like CSVs and PDFs.
        /// </summary>
        /// <param name="url">Stream endpoint</param>
        /// <returns>Stream</returns>
        protected async Task<Stream> GetStream(string url)
        {
            using (var client = GetClient())
            {
                var result = await client.SendAsync(GetHttpMessage(HttpMethod.Get, url)).
                    ConfigureAwait(false);

                await ThrowIfError(result).ConfigureAwait(false);

                return await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
        }
        
        /// <summary>
        /// Executes an HTTP call to specified endpoint.
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <param name="url">Endpoint</param>
        /// <param name="data">Payload data</param>
        /// <param name="headers">HTTP headers</param>
        /// <param name="outResponse">Ref variable to return raw HttpResponseMessage instance</param>
        /// <returns>HTTP call result</returns>
        private async Task<HttpResponseMessage> MakeRequest(
            HttpMethod method,
            string url,
            object data = null,
            IDictionary<string, string> headers = null,
            Ref<HttpResponseMessage> outResponse = null)
        {
            var message = GetHttpMessage(method, url, headers);
            HttpResponseMessage result;
            
            using (message.Content = GetMessageContent(data))
            {
                using (var client = GetClient())
                {
//                     Console.WriteLine("DEBUG MODE: Request\n"
//                              + ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n"
//                              + method + ": " + url + "\n"
//                              + "Headers: " + headers + "\n"
//                              + "Payout: " + json + "\n");
                    
                    result = await client.SendAsync(message);
                    
//                    Console.WriteLine("DEBUG MODE: Response\n"
//                                      + "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\n"
//                                      + "Code: " + result.StatusCode + "\n"
//                                      + "Headers: " + Serialize(result.Headers) + "\n"
//                                      + "Body: " + await result.Content.ReadAsStringAsync() + "\n");

                    await ThrowIfError(result);
                }
            }

            if (outResponse != null)
            {
                outResponse.Value = result;
            }
            return result;
        }

        /// <summary>
        /// Builds HttpRequestMessage instance based on HTTP Method, endpoint and HTTP headers.
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <param name="resource">Resource endpoint</param>
        /// <param name="headers">HTTP headers</param>
        /// <returns>HttpRequestMessage instance</returns>
        private static HttpRequestMessage GetHttpMessage(HttpMethod method,
            string resource,
            IDictionary<string, string> headers = null)
        {
            var message = new HttpRequestMessage(method, resource);
            message.Headers.Accept.Clear();
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (headers != null)
            {
                foreach (var kvp in headers)
                {
                    message.Headers.Add(kvp.Key, kvp.Value);
                }
            }
            return message;
        }

        /// <summary>
        /// Builds default HttpClient instance.
        /// </summary>
        /// <returns>HttpClient instance</returns>
        private HttpClient GetClient()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            if (ApiSession.Proxy != null)
            {
                handler.Proxy = ApiSession.Proxy;
                handler.UseProxy = true;
            }

            handler.UseCookies = true;
            handler.Credentials = new NetworkCredential(ApiSession.Credentials.Username, ApiSession.Credentials.Password);

            var client = new HttpClient(handler, true) {Timeout = TimeSpan.FromSeconds(600)};
            client.DefaultRequestHeaders.Add("User-Agent", ApiSession.UserAgent);
            client.DefaultRequestHeaders.ExpectContinue = false;
            return client;
        }

        /// <summary>
        /// Serializes data to the HttpContent compatible structure. 
        /// </summary>
        /// <param name="data">Data to be sent to the server</param>
        /// <returns>HttpContent-based data</returns>
        private HttpContent GetMessageContent(object data)
        {
            if (data == null) return null;

            return new StringContent(Serialize(data), Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Deserializes HttpResponseMessage data to specified type. Returns default value in case of failure. 
        /// </summary>
        /// <param name="result">HttpResponseMessage instance</param>
        /// <typeparam name="T">Type to convert message to</typeparam>
        /// <returns>Instance of T type</returns>
        private async Task<T> DeserializeOrDefault<T>(HttpResponseMessage result)
        {
            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            return !string.IsNullOrEmpty(content) ? _jsonSerializer.Deserialize<T>(content) : default(T);
        }

        /// <summary>
        /// Serializes data to JSON.
        /// </summary>
        /// <param name="data">Data to be serialized</param>
        /// <returns>JSON representation of data</returns>
        private string Serialize(object data)
        {
            return _jsonSerializer.Serialize(data);
        }

        /// <summary>
        /// Checks the HttpResponseMessage status code and throw an ApiException in case of non 2xx response.
        /// </summary>
        /// <param name="result">HttpResponseMessage instance</param>
        /// <returns></returns>
        /// <exception cref="ApiException">Throws in case of non 2xx response</exception>
        private static async Task ThrowIfError(HttpResponseMessage result)
        {
            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                var errorMessage = new ErrorMessage();

                try
                {
                    errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }
                catch (Exception)
                {
                    errorMessage.ErrorMessages = new []{content};
                }

                // We still throw an obsolete ApiException in order to keep the backward compatibility
                // Will be removed in future versions (after v3.1.4).
                throw new Commuication.ApiException(
                    $"Error when calling {result.RequestMessage.Method.ToString().ToUpperInvariant()} " +
                    $"{result.RequestMessage.RequestUri}.",
                    result.StatusCode,
                    errorMessage,
                    null);
            }
        }
    }
}
