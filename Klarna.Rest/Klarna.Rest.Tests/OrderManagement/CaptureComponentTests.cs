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
    /// Component tests of the capture class.
    /// </summary>
    [TestFixture]
    public class CaptureComponentTests
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
        private string path = "/captures";

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
        private Klarna.Rest.OrderManagement.Capture capture;

        /// <summary>
        /// The order url.
        /// </summary>
        private Uri orderUrl = new Uri("/path", UriKind.Relative);

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
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connector, this.orderUrl, "1002");
        }

        #endregion

        #region Tests

        /// <summary>
        /// Make sure that the request sent and retrieved data is correct.
        /// </summary>
        [Test]
        public void TestFetch()
        {
            // Arrange
            string description = "capture description";
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.orderUrl + this.path + "/1002")).Return(this.httpWebRequest);

            string json = "{\r\n  \"capture_id\": \"" + this.captureId + "\",\r\n  \"description\": \"" + description + "\",\r\n  }";
            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            HttpStatusCode status = HttpStatusCode.OK;
            IResponse response = new Response(status, headers, json);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            CaptureData captureData = this.capture.Fetch();

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(captureData.CaptureId, this.captureId);
            Assert.AreEqual(captureData.Description, description);
            Assert.AreEqual(this.httpWebRequest.ContentLength, 0);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Get);
        }

        /// <summary>
        /// Make sure that the request sent is correct and that the location is updated when creating the capture.
        /// </summary>
        [Test]
        public void TestCreate()
        {
            // Arrange
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connector, this.orderUrl, string.Empty);
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.orderUrl + this.path)).Return(this.httpWebRequest);

            CaptureData captureData = new CaptureData()
            {
                Description = "the desc...",
                CapturedAmount = 111
            };
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.Created, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, captureData.ConvertToJson())).Return(response);

            // Act
            this.capture.Create(captureData);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.capture.Location, this.location);
            Assert.AreEqual(this.httpWebRequest.ContentLength, captureData.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when appending shipping info.
        /// </summary>
        [Test]
        public void TestAddShippingInfo()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.orderUrl + this.path + "/" + this.captureId  + "/shipping-info")).Return(this.httpWebRequest);

            var shippingInfo = TestsHelper.GetAddShippingInfo();
            string json = shippingInfo.ConvertToJson();
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, json)).Return(response);

            // Act
            this.capture.AddShippingInfo(shippingInfo);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, json.Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Make sure that the request sent is correct when updating customer details.
        /// </summary>
        [Test]
        public void TestUpdateCustomerDetails()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.orderUrl + this.path + "/" + this.captureId + "/customer-details")).Return(this.httpWebRequest);

            UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails()
            {
                BillingAddress = TestsHelper.GetAddress1()
            };

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, updateCustomerDetails.ConvertToJson())).Return(response);

            // Act
            this.capture.UpdateCustomerDetails(updateCustomerDetails);

            // Assert
            this.requestMock.VerifyAllExpectations();
            Assert.AreEqual(this.httpWebRequest.ContentLength, updateCustomerDetails.ConvertToJson().Length);
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Patch);
        }

        /// <summary>
        /// Make sure that the request sent is correct when triggering a send-out.
        /// </summary>
        [Test]
        public void TestTriggerSendOut()
        {
            // Arrange
            this.requestMock.Expect(x => x.CreateRequest(this.baseUrl.ToString().TrimEnd('/') + this.orderUrl + this.path + "/" + this.captureId + "/trigger-send-out")).Return(this.httpWebRequest);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = this.location;

            IResponse response = new Response(HttpStatusCode.NoContent, headers, string.Empty);
            this.requestMock.Expect(x => x.Send(this.httpWebRequest, string.Empty)).Return(response);

            // Act
            this.capture.TriggerSendOut();

            // Assert
            TestsHelper.AssertRequest(this.merchantId, this.secret, this.httpWebRequest, HttpMethod.Post);
        }

        #endregion
    }
}
