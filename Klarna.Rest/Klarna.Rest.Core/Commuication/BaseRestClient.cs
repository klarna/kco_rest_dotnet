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

        protected async Task<T> Post<T>(string url, object data)
        {
            var message = GetMessage(HttpMethod.Post, url);
            var json = Serialize(data);
            using (message.Content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (var client = GetClient())
                {
                    var result = await client.SendAsync(message);

                    await ThrowIfError(result);

                    return await DeserializeOrDefault<T>(result);
                }
            }
        }

        protected async Task Post(string url, object data = null)
        {
            var message = GetMessage(HttpMethod.Post, url);
            var json = data == null ? string.Empty : Serialize(data);
            using (message.Content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (var client = GetClient())
                {
                    var result = await client.SendAsync(message);

                    await ThrowIfError(result);
                }
            }
        }

        protected async Task Patch(string url, object data)
        {
            var message = GetMessage(new HttpMethod("PATCH"), url);
            var json = data == null ? string.Empty : Serialize(data);
            using (message.Content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (var client = GetClient())
                {
                    var result = await client.SendAsync(message);

                    await ThrowIfError(result);
                }
            }
        }

        protected async Task Delete(string url)
        {
            using (var client = GetClient())
            {
                var result = await client.SendAsync(GetMessage(HttpMethod.Delete, url));

                await ThrowIfError(result);
            }
        }

        protected async Task<T> Put<T>(string url, object data)
        {
            var message = GetMessage(HttpMethod.Put, url);
            var json = Serialize(data);
            using (message.Content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                using (var client = GetClient())
                {
                    var result = await client.SendAsync(message);

                    await ThrowIfError(result);

                    return await DeserializeOrDefault<T>(result);
                }
            }
        }

        protected async Task<T> Get<T>(string url, IDictionary<string, string> headers = null)
        {
            using (var client = GetClient())
            {
                var result = await client.SendAsync(GetMessage(HttpMethod.Get, url));

                await ThrowIfError(result);

                return await DeserializeOrDefault<T>(result);
            }
        }

        protected async Task Get(string url)
        {
            using (var client = GetClient())
            {
                var result = await client.SendAsync(GetMessage(HttpMethod.Get, url));

                await ThrowIfError(result);
            }
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

        private HttpRequestMessage GetMessage(HttpMethod method, string resource, IDictionary<string, string> headers = null)
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
            if (!string.IsNullOrEmpty(content))
            {
                return _jsonSerializer.Deserialize<T>(content);
            }
            return default(T);
        }

        private string Serialize(object data)
        {
            return _jsonSerializer.Serialize(data);
        }

        private async Task ThrowIfError(HttpResponseMessage result)
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
