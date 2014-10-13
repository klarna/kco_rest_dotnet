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
            this.responseValidator = new ResponseValidator();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of StatusCode.
        /// </summary>
        [Test]
        public void ResponseValidator_StatusCode_Basic()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.responseValidator.StatusCode(this.statusCode, this.statusCode), this.responseValidator);
        }

        /// <summary>
        /// Exception test of StatusCode.
        /// </summary>
        [Test]
        public void ResponseValidator_StatusCode_Exception()
        {
            // Arrange

            // Act

            // Assert
            try
            {
                this.responseValidator.StatusCode(HttpStatusCode.NotModified, this.statusCode);
                Assert.Fail("No exception was thrown");
            }
            catch (Exception ex)
            {
                string expectedMessage = string.Format("Response has wrong StatusCode. Should be {0} but is {1}", (int)this.statusCode, (int)HttpStatusCode.NotModified);
                Assert.AreEqual(ex.Message, expectedMessage);
            }
        }

        /// <summary>
        /// Basic test of ContentType.
        /// </summary>
        [Test]
        public void ResponseValidator_ContentType_Basic()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.responseValidator.ContentType(this.contentType, this.contentType), this.responseValidator);
        }

        /// <summary>
        /// Exception test of ContentType.
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Response has wrong ContentType")]
        public void ResponseValidator_ContentType_Exception()
        {
            // Arrange

            // Act

            // Assert
            this.responseValidator.ContentType("different/contentType", this.contentType);
        }

        #endregion
    }
}
