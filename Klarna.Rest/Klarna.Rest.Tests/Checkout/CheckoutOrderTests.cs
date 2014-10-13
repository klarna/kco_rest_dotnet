#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOrderTests.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests.Checkout
{
    using System;
    using System.Net;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;
    using NUnit.Framework;
    using Rhino.Mocks;
    
    /// <summary>
    /// Tests the Order class.
    /// </summary>
    [TestFixture]
    public class CheckoutOrderTests
    {
        #region Private Fields

        /// <summary>
        /// The connector.
        /// </summary>
        private IConnector connectorMock;

        /// <summary>
        /// The response content type.
        /// </summary>
        private Klarna.Rest.Checkout.CheckoutOrder order;

        /// <summary>
        /// The path.
        /// </summary>
        private string path = "/checkout/v3/orders";

        /// <summary>
        /// Test url.
        /// </summary>
        private Uri testUrl = new Uri("https://testUrl.test");

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.connectorMock = MockRepository.GenerateStub<IConnector>();
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, this.testUrl);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test of Constructor with order url.
        /// </summary>
        [Test]
        public void CheckoutOrder_Constructor_OrderUrl()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(this.order.Location, this.testUrl);
        }

        /// <summary>
        /// Test of Constructor without order url.
        /// </summary>
        [Test]
        public void CheckoutOrder_Constructor_NoOrderUrl()
        {
            // Arrange

            // Act
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, null);

            // Assert
            Assert.AreEqual(this.order.Location, null);
        }

        /// <summary>
        /// Test of Path.
        /// </summary>
        [Test]
        public void CheckoutOrder_Path_Basic()
        {
            // Arrange

            // Act
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, null);

            // Assert
            Assert.AreEqual(this.order.Path, this.path);
        }

        /// <summary>
        /// Basic test of Create.
        /// </summary>
        [Test]
        public void CheckoutOrder_Create_Basic()
        {
            // Arrange
            CheckoutOrderData checkoutOrderData = TestsHelper.GetCheckoutOrderData1();

            Uri newTestLocation = new Uri("https://newTestUrl.test");

            var responseMock = TestsHelper.Mock(HttpMethod.Post, this.order.Path, checkoutOrderData.ConvertToJson(), HttpStatusCode.Created, this.connectorMock);

            responseMock.Stub(x => x.Location).Return(newTestLocation);
            responseMock.Stub(x => x.Data<CheckoutOrderData>()).Return(checkoutOrderData);

            // Act
            var resource = this.order.Create(checkoutOrderData);

            // Assert
            Assert.AreEqual(resource.Location, newTestLocation);
        }

        /// <summary>
        /// Basic test of Update.
        /// </summary>
        [Test]
        public void CheckoutOrder_Update_Basic()
        {
            // Arrange
            CheckoutOrderData checkoutOrderData1 = TestsHelper.GetCheckoutOrderData1();

            CheckoutOrderData checkoutOrderData2 = TestsHelper.GetCheckoutOrderData2();

            var responseMock = TestsHelper.Mock(HttpMethod.Post, this.order.Location.ToString(), checkoutOrderData1.ConvertToJson(), HttpStatusCode.OK, this.connectorMock);
            responseMock.Stub(x => x.Data<CheckoutOrderData>()).Return(checkoutOrderData2);

            // Act
            var returnedCheckoutOrderData = this.order.Update(checkoutOrderData1);

            // Assert
            Assert.AreEqual(returnedCheckoutOrderData.PurchaseCountry, checkoutOrderData2.PurchaseCountry);
            Assert.AreEqual(returnedCheckoutOrderData.PurchaseCurrency, checkoutOrderData2.PurchaseCurrency);
        }

        /// <summary>
        /// Basic test of Fetch.
        /// </summary>
        [Test]
        public void CheckoutOrder_Fetch_Basic()
        {
            // Arrange
            CheckoutOrderData checkoutOrderData = TestsHelper.GetCheckoutOrderData1();

            var responseMock = TestsHelper.Mock(HttpMethod.Get, this.order.Location.ToString(), string.Empty, HttpStatusCode.OK, this.connectorMock);
            responseMock.Stub(x => x.Data<CheckoutOrderData>()).Return(checkoutOrderData);

            // Act
            var returnedCheckoutOrderData = this.order.Fetch();

            // Assert
            Assert.AreEqual(returnedCheckoutOrderData.PurchaseCountry, checkoutOrderData.PurchaseCountry);
            Assert.AreEqual(returnedCheckoutOrderData.PurchaseCurrency, checkoutOrderData.PurchaseCurrency);
        }

        #endregion
    }
}
