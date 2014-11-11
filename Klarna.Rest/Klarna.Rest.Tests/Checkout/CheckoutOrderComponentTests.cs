#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOrderComponentTests.cs" company="Klarna AB">
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
    /// Component tests of the order class.
    /// </summary>
    [TestFixture]
    public class CheckoutOrderComponentTests
    {
        #region Private Fields

        /// <summary>
        /// The merchant id.
        /// </summary>
        private string merchantId = "1234";

        /// <summary>
        /// The shared secret.
        /// </summary>
        private string secret = "MySecret";

        /// <summary>
        /// The path.
        /// </summary>
        private string path = "/checkout/v3/orders";

        /// <summary>
        /// The base url.
        /// </summary>
        private Uri baseUrl = new Uri("https://dummytesturi.test");

        /// <summary>
        /// The HTTP request.
        /// </summary>
        private UserAgent userAgent = UserAgent.WithDefaultFields();

        /// <summary>
        /// The HTTP request.
        /// </summary>
        private HttpWebRequest httpWebRequest;

        /// <summary>
        /// The request factory.
        /// </summary>
        private IRequestFactory requestMock;

        /// <summary>
        /// The connector.
        /// </summary>
        private IConnector connector;

        /// <summary>
        /// The order.
        /// </summary>
        private Klarna.Rest.Checkout.CheckoutOrder checkoutOrder;

        /// <summary>
        /// A location.
        /// </summary>
        private string location = "https://somelocation.test/";

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.httpWebRequest = (HttpWebRequest)WebRequest.Create(this.baseUrl);
            this.requestMock = MockRepository.GenerateStub<IRequestFactory>();

            this.connector = ConnectorFactory.Create(this.requestMock, this.merchantId, this.secret, this.userAgent, this.baseUrl);
            this.checkoutOrder = new Klarna.Rest.Checkout.CheckoutOrder(this.connector, null);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Make sure that the request sent and retrieved data is correct when fetching the order.
        /// </summary>
        [Test]
        public void TestCreate()
        {
            // Arrange
            CheckoutOrderData orderData = TestsHelper.GetCheckoutOrderData1();
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl + this.path.TrimStart('/'))).Return(this.httpWebRequest);
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;
            HttpStatusCode status = HttpStatusCode.Created;
            IResponse response = new Response(status, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, orderData.ConvertToJson())).Return(response);

            // Act
            this.checkoutOrder.Create(orderData);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.checkoutOrder.Location, this.location);
            Assert.AreEqual(this.httpWebRequest.ContentLength, orderData.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct and that the updated data is accessible.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            // Arrange
            CheckoutOrderData orderData1 = TestsHelper.GetCheckoutOrderData1();
            CheckoutOrderData orderData2 = TestsHelper.GetCheckoutOrderData2();

            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl + this.path.TrimStart('/'))).Return(this.httpWebRequest);
            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.Location] = this.location;

            IResponse response = new Response(HttpStatusCode.Created, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, orderData1.ConvertToJson())).Return(response);

            this.httpWebRequest = (HttpWebRequest)WebRequest.Create(this.baseUrl);
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl + this.location)).Return(this.httpWebRequest);

            WebHeaderCollection headers2 = new WebHeaderCollection();
            headers2[HttpResponseHeader.ContentType] = "application/json";

            IResponse response2 = new Response(HttpStatusCode.OK, headers2, orderData2.ConvertToJson());
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, orderData2.ConvertToJson())).Return(response2);

            // Act
            this.checkoutOrder.Create(orderData1);
            CheckoutOrderData updatedCheckoutOrderData = this.checkoutOrder.Update(orderData2);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.checkoutOrder.Location, this.location);
            Assert.AreEqual(this.httpWebRequest.ContentLength, orderData2.ConvertToJson().Length);
            Assert.AreEqual(updatedCheckoutOrderData.PurchaseCountry, orderData2.PurchaseCountry);
            Assert.AreEqual(updatedCheckoutOrderData.PurchaseCurrency, orderData2.PurchaseCurrency);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent and retrieved data is correct.
        /// </summary>
        [Test]
        public void TestFetch()
        {
            // Arrange
            string orderId = "0002";
            Uri orderUrl = new Uri(this.baseUrl.ToString() + orderId);
            int orderAmount = 1234;
            this.requestMock.Expect(x => x.CreateRequest(orderUrl.ToString())).Return(this.httpWebRequest);

            string json = "{\r\n  \"order_id\": \"" + orderId + "\",\r\n  \"order_amount\": " + orderAmount + ",\r\n }";
            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            IResponse response = new Response(HttpStatusCode.OK, headers, json);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.checkoutOrder = new Klarna.Rest.Checkout.CheckoutOrder(this.connector, orderUrl);
            CheckoutOrderData checkoutOrderData = this.checkoutOrder.Fetch();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, 0);
            Assert.AreEqual(checkoutOrderData.OrderId, orderId);
            Assert.AreEqual(checkoutOrderData.OrderAmount, orderAmount);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Get);
        }

        #endregion
    }
}
