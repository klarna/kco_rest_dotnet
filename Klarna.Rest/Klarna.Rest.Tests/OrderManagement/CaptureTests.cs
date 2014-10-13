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
            Assert.AreEqual(this.capture.Location.ToString(), this.orderUrl + this.path + "/" + captureId);
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
            Assert.AreEqual(this.capture.Location, this.orderUrl + this.path);
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
            Assert.AreEqual(this.capture.Path, this.path);
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

            var responseMock = TestsHelper.Mock(HttpMethod.Post, this.capture.Location.ToString(), captureData.ConvertToJson(), HttpStatusCode.Created, this.connectorMock);
            responseMock.Stub(x => x.Location).Return(newTestLocation);

            // Act
            var resource = this.capture.Create(captureData);

            // Assert
            Assert.AreEqual(resource.Location, newTestLocation);
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

            // Act
            var returnedCheckoutOrder = this.capture.Fetch();

            // Assert
            Assert.AreEqual(returnedCheckoutOrder.CapturedAmount, captureData.CapturedAmount);
            Assert.AreEqual(returnedCheckoutOrder.ShippingInfo.Count, captureData.ShippingInfo.Count);
            Assert.AreEqual(returnedCheckoutOrder.ShippingInfo[0].ShippingCompany, captureData.ShippingInfo[0].ShippingCompany);
        }

        /// <summary>
        /// Basic test of AddShippingInfo.
        /// </summary>
        [Test]
        public void Capture_AddShippingInfo_Basic()
        {
            // Arrange
            var shippingInfo = TestsHelper.GetAddShippingInfo();

            TestsHelper.Mock(HttpMethod.Post, this.capture.Location + "/shipping-info", shippingInfo.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            var resource = this.capture.AddShippingInfo(shippingInfo);

            // Assert
            Assert.AreEqual(resource, this.capture);
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

            var resource = this.capture.UpdateCustomerDetails(updateCustomerDetails);

            // Assert
            Assert.AreEqual(resource, this.capture);
        }

        /// <summary>
        /// Basic test of TriggerSendOut.
        /// </summary>
        [Test]
        public void Capture_TriggerSendOut_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.capture.Location + "/trigger-send-out", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            var resource = this.capture.TriggerSendOut();

            // Assert
            Assert.AreEqual(resource, this.capture);
        }

        #endregion
    }
}
