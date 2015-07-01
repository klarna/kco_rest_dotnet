#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CaptureComponentTests.cs" company="Klarna AB">
//     Copyright 2014 Klarna AB
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
namespace Klarna.Rest.Tests.Model
{
    using System;
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.EMD;
    using Newtonsoft.Json;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests of the extra merchant data class.
    /// </summary>
    [TestFixture]
    class ExtraMerchantDataTest
    {
        /// <summary>
        /// Expected JSON string.
        /// </summary>
        private const string JSON = "{\"payment_history_full\":[{\"date_of_first_paid_purchase\":\"2015-06-24T00:52:13Z\"}]}";

        /// <summary>
        /// Expected date time ticks.
        /// </summary>
        private const long TICKS = 635707039330000000;

        /// <summary>
        /// Test that extra merchant data can be casted to an attachment.
        /// </summary>
        [Test]
        public void TestCastExtraMerchantDataToAttachment()
        {
            ExtraMerchantData emd = new ExtraMerchantData
            {
                Body = new ExtraMerchantDataBody
                {
                    PaymentHistoryFull = new List<PaymentHistoryFull>
                    {
                        new PaymentHistoryFull
                        {
                            DateOfFirstPaidPurchase = new DateTime(TICKS)
                        }
                    }
                }
            };

            Attachment attachment = emd;

            Assert.AreEqual(emd.ContentType, attachment.ContentType);
            Assert.AreEqual(JSON, attachment.Body);
        }

        /// <summary>
        /// Ensure that an attachment can be casted to extra merchant data.
        /// </summary>
        [Test]
        public void TestCastAttachmentToExtraMerchantData()
        {
            Attachment attachment = new Attachment
            {
                ContentType = "application/vnd.klarna.internal.emd-v2+json",
                Body = JSON
            };

            ExtraMerchantData emd = attachment;

            Assert.AreEqual(TICKS, emd.Body.PaymentHistoryFull[0].DateOfFirstPaidPurchase.Ticks);
        }

        /// <summary>
        /// Ensure that an exception is thrown when the attachment content type does not match.
        /// </summary>
        [TestCase("application/vnd.something.else+json"), TestCase(null), TestCase("")]
        public void TestCastAttachmentToExtraMerchantDataIncorrectContentType(string contentType)
        {
            Attachment attachment = new Attachment
            {
                ContentType = contentType,
                Body = JSON
            };

            InvalidCastException e = Assert.Throws<InvalidCastException>(
                delegate { ExtraMerchantData emd = attachment; } );

            Assert.AreEqual("Incorrect Content-Type", e.Message);
        }

        /// <summary>
        /// Ensure that an exception is thrown when the body could not be parsed.
        /// </summary>
        [Test]
        public void TestCastAttachmentToExtraMerchantDataIncorrectBody()
        {
            Attachment attachment = new Attachment
            {
                ContentType = "application/vnd.klarna.internal.emd-v2+json",
                Body = "{\"payment_history_full\":[{\"date_of_first_paid_purchase\":123}]}"
            };

            Assert.Throws<JsonSerializationException>(
                delegate { ExtraMerchantData emd = attachment; });
        }
    }
}
