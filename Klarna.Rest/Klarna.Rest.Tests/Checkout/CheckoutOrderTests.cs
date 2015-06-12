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
    /// Tests the CheckoutOrder class.
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
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, "0002");
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test of Constructor with order url.
        /// </summary>
        [Test]
        public void CheckoutOrder_Constructor_OrderUrl()
        {
            Assert.AreEqual("/checkout/v3/orders/0002", this.order.Location.OriginalString);
        }

        /// <summary>
        /// Test of Constructor without order url.
        /// </summary>
        [Test]
        public void CheckoutOrder_Constructor_NoOrderUrl()
        {
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, null);

            Assert.IsNull(this.order.Location);
        }

        /// <summary>
        /// Test of Path.
        /// </summary>
        [Test]
        public void CheckoutOrder_Path_Basic()
        {
            this.order = new Klarna.Rest.Checkout.CheckoutOrder(this.connectorMock, null);

            Assert.AreEqual(this.path, this.order.Path);
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

            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.Location] = newTestLocation.ToString();

            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            this.order.Create(checkoutOrderData);

            // Assert
            Assert.AreEqual(newTestLocation, this.order.Location);
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

            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            var returnedCheckoutOrderData = this.order.Update(checkoutOrderData1);

            // Assert
            Assert.AreEqual(checkoutOrderData2.PurchaseCountry, returnedCheckoutOrderData.PurchaseCountry);
            Assert.AreEqual(checkoutOrderData2.PurchaseCurrency, returnedCheckoutOrderData.PurchaseCurrency);
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

            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            var returnedCheckoutOrderData = this.order.Fetch();

            // Assert
            Assert.AreEqual(checkoutOrderData.PurchaseCountry, returnedCheckoutOrderData.PurchaseCountry);
            Assert.AreEqual(checkoutOrderData.PurchaseCurrency, returnedCheckoutOrderData.PurchaseCurrency);
        }

        #endregion
    }
}
