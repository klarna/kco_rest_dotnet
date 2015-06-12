#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CaptureTests.cs" company="Klarna AB">
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
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Tests the Order class.
    /// </summary>
    [TestFixture]
    public class CaptureTests
    {
        #region Private Fields

        /// <summary>
        /// The connector.
        /// </summary>
        private IConnector connectorMock;

        /// <summary>
        /// The response content type.
        /// </summary>
        private Klarna.Rest.OrderManagement.Capture capture;

        /// <summary>
        /// The order url.
        /// </summary>
        private Uri orderUrl = new Uri("https://orderurl.test");

        /// <summary>
        /// The path.
        /// </summary>
        private string path = "/captures";

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.connectorMock = MockRepository.GenerateStub<IConnector>();
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connectorMock, this.orderUrl, string.Empty);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test of Constructor with capture id.
        /// </summary>
        [Test]
        public void Capture_Constructor_CaptureId()
        {
            // Arrange
            string captureId = "captureId";

            // Act
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connectorMock, this.orderUrl, captureId);

            // Assert
            Assert.AreEqual(this.orderUrl + this.path + "/" + captureId, this.capture.Location.ToString());
        }

        /// <summary>
        /// Test of Constructor without capture id.
        /// </summary>
        [Test]
        public void Capture_Constructor_NoCaptureId()
        {
            // Arrange

            // Act
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connectorMock, this.orderUrl, string.Empty);

            // Assert
            Assert.AreEqual(this.orderUrl + this.path, this.capture.Location.OriginalString);
        }

        /// <summary>
        /// Test of Path.
        /// </summary>
        [Test]
        public void Capture_Path_Basic()
        {
            // Arrange
            Uri newTestLocation = new Uri("https://newTestLocation.test");

            // Act
            this.capture = new Klarna.Rest.OrderManagement.Capture(this.connectorMock, newTestLocation, string.Empty);

            // Assert
            Assert.AreEqual(this.path, this.capture.Path);
        }

        /// <summary>
        /// Basic test of Create.
        /// </summary>
        [Test]
        public void Capture_Create_Basic()
        {
            // Arrange
            CaptureData captureData = TestsHelper.GetCapture();

            Uri newTestLocation = new Uri("https://newTestLocation.test");
            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Location"] = newTestLocation.OriginalString;

            var responseMock = TestsHelper.Mock(HttpMethod.Post, this.capture.Location.ToString(), captureData.ConvertToJson(), HttpStatusCode.Created, this.connectorMock);
            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            this.capture.Create(captureData);

            // Assert
            Assert.AreEqual(newTestLocation, this.capture.Location);
        }

        /// <summary>
        /// Basic test of Fetch.
        /// </summary>
        [Test]
        public void Capture_Fetch_Basic()
        {
            // Arrange
            CaptureData captureData = TestsHelper.GetCapture();

            var responseMock = TestsHelper.Mock(HttpMethod.Get, this.capture.Location.ToString(), string.Empty, HttpStatusCode.OK, this.connectorMock);
            responseMock.Stub(x => x.Data<CaptureData>()).Return(captureData);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers["Content-Type"] = "application/json";

            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            var returnedCheckoutOrder = this.capture.Fetch();

            // Assert
            Assert.AreEqual(captureData.CapturedAmount, returnedCheckoutOrder.CapturedAmount);
            Assert.AreEqual(captureData.ShippingInfo.Count, returnedCheckoutOrder.ShippingInfo.Count);
            Assert.AreEqual(captureData.ShippingInfo[0].ShippingCompany, returnedCheckoutOrder.ShippingInfo[0].ShippingCompany);
        }

        /// <summary>
        /// Basic test of AddShippingInfo.
        /// </summary>
        [Test]
        public void Capture_AddShippingInfo_Basic()
        {
            // Arrange
            var shippingInfo = TestsHelper.GetAddShippingInfo();

            IResponse response = TestsHelper.Mock(HttpMethod.Post, this.capture.Location + "/shipping-info", shippingInfo.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            this.capture.AddShippingInfo(shippingInfo);
        }

        /// <summary>
        /// Basic test of UpdateCustomerDetails.
        /// </summary>
        [Test]
        public void Capture_UpdateCustomerDetails_Basic()
        {
            // Arrange
            UpdateCustomerDetails updateCustomerDetails = TestsHelper.GetUpdateCustomerDetails();

            TestsHelper.Mock(HttpMethod.Patch, this.capture.Location + "/customer-details", updateCustomerDetails.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            this.capture.UpdateCustomerDetails(updateCustomerDetails);
        }

        /// <summary>
        /// Basic test of TriggerSendOut.
        /// </summary>
        [Test]
        public void Capture_TriggerSendOut_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.capture.Location + "/trigger-send-out", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            this.capture.TriggerSendOut();
        }

        #endregion
    }
}
