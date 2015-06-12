#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="OrderComponentTests.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests.OrderManagement
{
    using System;
    using System.Net;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.Transport;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Component tests of the order class.
    /// </summary>
    [TestFixture]
    public class OrderComponentTests
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
        private string path = "/ordermanagement/v1/orders";

        /// <summary>
        /// The order id.
        /// </summary>
        private string orderId = "0002";

        /// <summary>
        /// The capture id.
        /// </summary>
        private string captureId = "1002";

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
        private Klarna.Rest.OrderManagement.Order order;

        /// <summary>
        /// A location.
        /// </summary>
        private string location = "https://somelocation.test";

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
            this.order = new Klarna.Rest.OrderManagement.Order(this.connector, this.orderId);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Make sure that the request sent and retrieved data is correct when fetching the order.
        /// </summary>
        [Test]
        public void TestFetch()
        {
            // Arrange
            int orderAmount = 1234;
            string description = "A description";
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId)).Return(this.httpWebRequest);

            string json = "{\r\n  \"order_id\": \"" + this.orderId + "\",\r\n  \"order_amount\": " + orderAmount + ",\r\n  \"captures\": [\r\n    {\r\n      \"capture_id\": \"" + this.captureId + "\",\r\n       \"description\": \"" + description + "\",\r\n    }\r\n  ],\r\n}";
            string captureJson = JsonConvert.DeserializeObject<Klarna.Rest.Models.OrderData>(json).Captures[0].ConvertToJson();

            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            IResponse fetchResponse = new Response(HttpStatusCode.OK, headers, json);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(fetchResponse);

            // Act
            Models.OrderData orderData = this.order.Fetch();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.orderId, orderData.OrderId);
            Assert.AreEqual(orderAmount, orderData.OrderAmount);
            Assert.AreEqual(1, orderData.Captures.Count);
            Assert.AreEqual(this.captureId, orderData.Captures[0].CaptureId);
            Assert.AreEqual(description, orderData.Captures[0].Description);
            Assert.AreEqual(0, this.httpWebRequest.ContentLength);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Get);
        }

        /// <summary>
        /// Test acknowledge order managementMake sure that the request sent is correct when acknowledging an order.
        /// </summary>
        [Test]
        public void TestAcknowledge()
        {
            // Arrange
            this.requestMock.Stub(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/acknowledge")).Return(this.httpWebRequest);
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.order.Acknowledge();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(0, this.httpWebRequest.ContentLength);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when cancelling an order.
        /// </summary>
        [Test]
        public void TestCancel()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/cancel")).Return(this.httpWebRequest);
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.order.Cancel();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(0, this.httpWebRequest.ContentLength);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when extending authorization time.
        /// </summary>
        [Test]
        public void TestExtendAuthorizationTime()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/extend-authorization-time")).Return(this.httpWebRequest);
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.order.ExtendAuthorizationTime();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(0, this.httpWebRequest.ContentLength);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when releasing remaining authorization.
        /// </summary>
        [Test]
        public void TestReleaseRemainingAuthorization()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/release-remaining-authorization")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.order.ReleaseRemainingAuthorization();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(0, this.httpWebRequest.ContentLength);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when updating authorization.
        /// </summary>
        [Test]
        public void TestUpdateAuthorization()
        {
            // Arrange
            UpdateAuthorization updateAuthorization = new UpdateAuthorization()
            {
                Description = "TestUpdateAuthorization description"
            };

            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/authorization")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, updateAuthorization.ConvertToJson())).Return(response);

            // Act
            this.order.UpdateAuthorization(updateAuthorization);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, updateAuthorization.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Patch);
        }

        /// <summary>
        /// Make sure that the request sent is correct when updating merchant references.
        /// </summary>
        [Test]
        public void TestUpdateMerchantReferences()
        {
            // Arrange
            UpdateMerchantReferences updateMerchantReferences = new UpdateMerchantReferences()
            {
                MerchantReference1 = "A merchant reference",
                MerchantReference2 = "Another merchant reference"
            };

            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/merchant-references")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, updateMerchantReferences.ConvertToJson())).Return(response);

            // Act
            this.order.UpdateMerchantReferences(updateMerchantReferences);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, updateMerchantReferences.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Patch);
        }

        /// <summary>
        /// Make sure that the request sent is correct when updating customer details.
        /// </summary>
        [Test]
        public void TestUpdateCustomerDetails()
        {
            // Arrange
            UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails()
            {
                ShippingAddress = TestsHelper.GetAddress1(),
                BillingAddress = TestsHelper.GetAddress1()
            };

            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/customer-details")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, updateCustomerDetails.ConvertToJson())).Return(response);

            // Act
            this.order.UpdateCustomerDetails(updateCustomerDetails);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, updateCustomerDetails.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Patch);
        }

        /// <summary>
        /// Make sure that the request sent is correct when performing a refund.
        /// </summary>
        [Test]
        public void TestRefund()
        {
            // Arrange
            Refund refund = new Refund()
            {
                RefundedAmount = 12345,
                Description = "Refund description"
            };

            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.path + '/' + this.orderId + "/refunds")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, refund.ConvertToJson())).Return(response);

            // Act
            this.order.Refund(refund);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, refund.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        #endregion
    }
}
