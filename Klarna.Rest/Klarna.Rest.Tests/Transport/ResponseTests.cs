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
        /// The response data
        /// </summary>
        private string json;

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
            this.json = "jsondata";
            this.location = "https://testlocation.com";
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of Location
        /// </summary>
        [Test]
        public void Transport_Response_Location_Basic()
        {
            // Arrange

            // Act
            Response responseValidator = new Response(this.json, this.location);

            // Assert
            Assert.AreEqual(responseValidator.Location, this.location);
        }

        /// <summary>
        /// Exception test of Location
        /// </summary>
        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "Response contains location that is null")]
        public void Transport_Response_Location_Exception()
        {
            // Arrange

            // Act
            Response responseValidator = new Response(this.json, null);

            // Assert
            var location = responseValidator.Location;
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
            Response responseValidator = new Response(checkoutOrderData.ConvertToJson(), this.location);

            // Assert
            var data = responseValidator.Data<Models.CheckoutOrderData>();
            Assert.AreEqual(data.PurchaseCountry, checkoutOrderData.PurchaseCountry);
            Assert.AreEqual(data.PurchaseCurrency, checkoutOrderData.PurchaseCurrency);
        }

        #endregion
    }
}
