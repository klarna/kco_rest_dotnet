#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ResponseValidatorTests.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests.Transport
{
    using System;
    using System.Net;
    using Klarna.Rest.Transport;
    using NUnit.Framework;

    /// <summary>
    /// Tests the ResponseValidator class.
    /// </summary>
    [TestFixture]
    public class ResponseValidatorTests
    {
        #region Private Fields

        /// <summary>
        /// The response status code.
        /// </summary>
        private HttpStatusCode statusCode;

        /// <summary>
        /// The response content type.
        /// </summary>
        private string contentType;

        /// <summary>
        /// The response headers.
        /// </summary>
        private WebHeaderCollection headers;

        /// <summary>
        /// The response.
        /// </summary>
        private Response response;

        /// <summary>
        /// The response validator.
        /// </summary>
        private ResponseValidator responseValidator;

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.statusCode = HttpStatusCode.OK;
            this.contentType = "application/json";
            this.headers = new WebHeaderCollection();
            this.headers["Content-Type"] = this.contentType;
            this.response = new Response(this.statusCode, this.headers, string.Empty);
            this.responseValidator = new ResponseValidator(this.response);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of Status.
        /// </summary>
        [Test]
        public void ResponseValidator_Status_Basic()
        {
            Assert.AreEqual(this.responseValidator, this.responseValidator.Status(this.statusCode));
        }

        /// <summary>
        /// Basic test of Status.
        /// </summary>
        [Test]
        public void ResponseValidator_Statuses_Basic()
        {
            Assert.AreEqual(this.responseValidator, this.responseValidator.Status(HttpStatusCode.Created, this.statusCode));
        }

        /// <summary>
        /// Exception test of StatusCode.
        /// </summary>
        [Test]
        public void ResponseValidator_StatusCode_Exception()
        {
            Exception ex = Assert.Throws<Exception>(
                delegate { this.responseValidator.Status(HttpStatusCode.NotModified); });

            string expectedMessage = string.Format("Response has wrong StatusCode. Should be {0} but is {1}", (int)HttpStatusCode.NotModified, (int)this.statusCode);
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        /// <summary>
        /// Exception test of StatusCode.
        /// </summary>
        [Test]
        public void ResponseValidator_StatusCodes_Exception()
        {
            Exception ex = Assert.Throws<Exception>(
                delegate { this.responseValidator.Status(HttpStatusCode.NotModified, HttpStatusCode.NoContent); });

            string expectedMessage = string.Format("Response has wrong StatusCode {0}", (int)this.statusCode);
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        /// <summary>
        /// Basic test of ContentType.
        /// </summary>
        [Test]
        public void ResponseValidator_ContentType_Basic()
        {
            Assert.AreEqual(this.responseValidator, this.responseValidator.ContentType(this.contentType));
        }

        /// <summary>
        /// Exception test of ContentType.
        /// </summary>
        [Test]
        public void ResponseValidator_ContentType_Exception()
        {
            Exception ex = Assert.Throws<Exception>(
                delegate { this.responseValidator.ContentType("different/contentType"); });

            string expectedMessage = string.Format("Response has wrong Content-Type. Should be {0} but is {1}", "different/contentType", this.headers[HttpResponseHeader.ContentType]);
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        /// <summary>
        /// Exception test of ContentType.
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Response has no Content-Type header.")]
        public void ResponseValidator_ContentType_ExceptionMissing()
        {
            this.headers.Clear();
            this.responseValidator.ContentType("different/contentType");
        }

        #endregion
    }
}
