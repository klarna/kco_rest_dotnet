using System;
using System.Collections.Generic;
using System.Text;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication.Dto;
using Klarna.Rest.Core.Serialization;

namespace Klarna.Rest.Core.Examples
{
    public class CustomJsonSerializer
    {
        public static void Main()
        {
            var username = "0_abc";
            var password = "sharedsecret";
            var apiUrl = Klarna.ApiUrlFromEnvironment(KlarnaEnvironment.TestingEurope);
            var useragent = Klarna.GetDefaultUserAgent();
            var apiSession = new ApiSession
            {
                ApiUrl = apiUrl,
                UserAgent = useragent,
                Credentials = new ApiCredentials
                {
                    Username = username,
                    Password = password,
                }
            };
            var jsonSerializer = new JsonSerializerWithLoggingToConsole();

            var client = new Klarna(apiSession, jsonSerializer);

            var order = client.Checkout.GetOrder("12345").Result;
        }
    }

    public class JsonSerializerWithLoggingToConsole : JsonSerializer
    {
        public new string Serialize(object item)
        {
            var json = base.Serialize(item);
            Console.WriteLine(json);
            return json;
        }

        public new T Deserialize<T>(string json)
        {
            Console.WriteLine(json);
            return base.Deserialize<T>(json);
        }
    }
}
