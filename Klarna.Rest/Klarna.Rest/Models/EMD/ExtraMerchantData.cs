#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ExtraMerchantData.cs" company="Klarna AB">
//     Copyright 2015 Klarna AB
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
#endregion
namespace Klarna.Rest.Models.EMD
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// The model for the EMD attachment.
    /// </summary>
    public class ExtraMerchantData
    {
        /// <summary>
        /// Format used for formatting dates.
        /// </summary>
        private const string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";

        /// <summary>
        /// Content type.
        /// </summary>
        private const string Type = "application/vnd.klarna.internal.emd-v2+json";

        /// <summary>
        /// Gets the content type.
        /// </summary>
        public string ContentType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Gets or sets the body model.
        /// </summary>
        public ExtraMerchantDataBody Body { get; set; }

        /// <summary>
        /// Cast extra merchant data to an attachment.
        /// </summary>
        /// <param name="emd">The extra merchant data to cast.</param>
        public static implicit operator Attachment(ExtraMerchantData emd)
        {
            return new Attachment
            {
                ContentType = emd.ContentType,
                Body = JsonConvert.SerializeObject(
                    emd.Body,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Converters = new List<JsonConverter>()
                        {
                            new IsoDateTimeConverter
                            {
                                DateTimeFormat = DateTimeFormat
                            }
                        }
                    })
            };
        }

        /// <summary>
        /// Cast an attachment to extra merchant data.
        /// </summary>
        /// <param name="attachment">Attachment to cast.</param>
        public static implicit operator ExtraMerchantData(Attachment attachment)
        {
            if (string.IsNullOrEmpty(attachment.ContentType) || !attachment.ContentType.Equals(Type))
            {
                throw new InvalidCastException("Incorrect Content-Type");
            }

            return new ExtraMerchantData
            {
                Body = JsonConvert.DeserializeObject<ExtraMerchantDataBody>(
                    attachment.Body,
                    new IsoDateTimeConverter
                    {
                        DateTimeFormat = DateTimeFormat
                    })
            };
        }
    }
}
