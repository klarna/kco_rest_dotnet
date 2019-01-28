using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Serialization
{
    /// <summary>
    /// Default implementation of the IJsonSerializer interface.
    /// Inherit or nest and instance of this class and override its methods
    /// to allow inspection of payload.
    /// </summary>
    public class JsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// Default json serialization settings for the Klarna API
        /// </summary>
        protected JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Include,
            Converters = new List<JsonConverter>()
            {
                new IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"
                }
            }
        };

        /// <inheritdoc/>
        public string Serialize(object item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented, SerializerSettings);
        }

        /// <inheritdoc/>
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
