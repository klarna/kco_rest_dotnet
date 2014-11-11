#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ResponseTests.cs" company="Klarna AB">
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
    public class ResponseTests
    {
        #region Private Fields

        /// <summary>
        /// The response location
        /// </summary>
        private string location;

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.location = "https://testlocation.com";
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of headers
        /// </summary>
        [Test]
        public void Transport_Response_Headers()
        {
            // Arrange
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;
            HttpStatusCode status = HttpStatusCode.OK;

            // Act
            Response response = new Response(status, headers, string.Empty);

            // Assert
            Assert.AreEqual(response.Headers["Location"], this.location);
        }

        /// <summary>
        /// Test of Location
        /// </summary>
        [Test]
        public void Transport_Response_Location_Null()
        {
            // Arrange
            WebHeaderCollection headers = new WebHeaderCollection();
            HttpStatusCode status = HttpStatusCode.OK;

            // Act
            Response response = new Response(status, headers, string.Empty);

            // Assert
            Assert.That(response.Headers["Location"], Is.Null);
        }

        /// <summary>
        /// Basic test of Data
        /// </summary>
        [Test]
        public void Transport_Response_Data_Basic()
        {
            // Arrange
            Models.CheckoutOrderData checkoutOrderData = TestsHelper.GetCheckoutOrderData1();

            // Act
            Response response = new Response(HttpStatusCode.OK, new WebHeaderCollection(), checkoutOrderData.ConvertToJson());

            // Assert
            var data = response.Data<Models.CheckoutOrderData>();
            Assert.AreEqual(data.PurchaseCountry, checkoutOrderData.PurchaseCountry);
            Assert.AreEqual(data.PurchaseCurrency, checkoutOrderData.PurchaseCurrency);
        }

        #endregion
    }
}
