using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Commuication
{
    public abstract class BaseRestClient
    {
        protected readonly ApiSession ApiSession;

        private readonly IJsonSerializer _jsonSerializer;

        protected BaseRestClient(ApiSession apiSession, IJsonSerializer jsonSerializer)
        {
            ApiSession = apiSession;
            _jsonSerializer = jsonSerializer;
        }

        protected async Task Post(string url, object data = null, IDictionary<string, string> headers = null)
        {
            await MakeRequest(HttpMethod.Post, url, data, headers);
        }
        
        protected async Task<T> Post<T>(string url, object data = null, IDictionary<string, string> headers = null)
        {
            var result = await MakeRequest(HttpMethod.Post, url, data, headers);
            return await DeserializeOrDefault<T>(result);
        }

        protected async Task Patch(string url, object data = null, IDictionary<string, string> headers = null)
        {
            await MakeRequest(new HttpMethod("PATCH"), url, data, headers);
        }

        protected async Task Delete(string url, object data = null, IDictionary<string, string> headers = null)
        {
            await MakeRequest(HttpMethod.Delete, url, data, headers);
        }
        
        protected async Task<T> Delete<T>(string url, object data = null, IDictionary<string, string> headers = null)
        {
            var result = await MakeRequest(HttpMethod.Delete, url, data, headers);
            return await DeserializeOrDefault<T>(result);
        }

        protected async Task<T> Put<T>(string url, object data = null, IDictionary<string, string> headers = null)
        {
            
            var result = await MakeRequest(HttpMethod.Put, url, data, headers);
            return await DeserializeOrDefault<T>(result);
        }
        
        protected async Task Put(string url, object data = null, IDictionary<string, string> headers = null)
        {
            await MakeRequest(HttpMethod.Put, url, data, headers);
        }

        protected async Task<T> Get<T>(string url, IDictionary<string, string> headers = null)
        {
            var result = await MakeRequest(HttpMethod.Get, url, null, headers);
            return await DeserializeOrDefault<T>(result);
        }

        protected async Task Get(string url, IDictionary<string, string> headers = null)
        {
            await MakeRequest(HttpMethod.Get, url, null, headers);
        }

        protected async Task<Stream> GetStream(string url)
        {
            using (var client = GetClient())
            {
                var result = await client.SendAsync(GetMessage(HttpMethod.Get, url));

                await ThrowIfError(result);

                return await result.Content.ReadAsStreamAsync();
            }
        }
        
        private async Task<HttpResponseMessage> MakeRequest(
            HttpMethod method, string url, object data = null, IDictionary<string, string> headers = null)
        {
            var message = GetMessage(method, url, headers);
            var json = data == null ? string.Empty : Serialize(data);
            var result = new HttpResponseMessage();
            
            using (message.Content = new StringContent(json, Encoding.UTF8, "application/json"))
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
            return result;
        }

        private static HttpRequestMessage GetMessage(HttpMethod method, string resource, IDictionary<string, string> headers = null)
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

        private HttpClient GetClient()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }

            handler.UseCookies = true;
            handler.Credentials = new NetworkCredential(ApiSession.Credentials.Username, ApiSession.Credentials.Password);

            var client = new HttpClient(handler, true) {Timeout = TimeSpan.FromSeconds(600)};
            client.DefaultRequestHeaders.Add("User-Agent", ApiSession.UserAgent);
            client.DefaultRequestHeaders.ExpectContinue = false;
            return client;
        }

        private async Task<T> DeserializeOrDefault<T>(HttpResponseMessage result)
        {
            var content = await result.Content.ReadAsStringAsync();
            return !string.IsNullOrEmpty(content) ? _jsonSerializer.Deserialize<T>(content) : default(T);
        }

        private string Serialize(object data)
        {
            return _jsonSerializer.Serialize(data);
        }

        private static async Task ThrowIfError(HttpResponseMessage result)
        {
            if (!result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                ErrorMessage errorMessage = null;
                Exception innerException = null;
                
                try
                {
                    errorMessage = JsonConvert.DeserializeObject<ErrorMessage>(content);
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
                throw new ApiException($"Error when calling {result.RequestMessage.Method.ToString().ToUpperInvariant()} {result.RequestMessage.RequestUri}.", result.StatusCode, errorMessage, innerException);
            }
        }
    }
}
