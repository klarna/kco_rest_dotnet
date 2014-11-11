#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="OrderTests.cs" company="Klarna AB">
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
    public class OrderTests
    {
        #region Private Fields

        /// <summary>
        /// The connector.
        /// </summary>
        private IConnector connectorMock;

        /// <summary>
        /// The response content type
        /// </summary>
        private Klarna.Rest.OrderManagement.Order order;

        /// <summary>
        /// The order url.
        /// </summary>
        private string orderUrl = "orderUrl";

        /// <summary>
        /// The path.
        /// </summary>
        private string path = "/ordermanagement/v1/orders";

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.connectorMock = MockRepository.GenerateStub<IConnector>();
            this.order = new Klarna.Rest.OrderManagement.Order(this.connectorMock, this.orderUrl);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Test of Constructor with order id.
        /// </summary>
        [Test]
        public void Order_Constructor_OrderId()
        {
            // Arrange

            // Act
            this.order = new Klarna.Rest.OrderManagement.Order(this.connectorMock, this.orderUrl);

            // Assert
            Assert.AreEqual(this.order.Location, this.order.Path + "/" + this.orderUrl);
        }

        /// <summary>
        /// Test of Constructor without order id.
        /// </summary>
        [Test]
        public void Order_Constructor_NoOrderId()
        {
            // Arrange

            // Act
            this.order = new Klarna.Rest.OrderManagement.Order(this.connectorMock, string.Empty);

            // Assert
            Assert.AreEqual(this.order.Location, null);
        }

        /// <summary>
        /// Test of Path.
        /// </summary>
        [Test]
        public void Order_Path_Basic()
        {
            // Arrange

            // Act
            this.order = new Klarna.Rest.OrderManagement.Order(this.connectorMock, string.Empty);

            // Assert
            Assert.AreEqual(this.order.Path, this.path);
        }

        /// <summary>
        /// Basic test of Fetch.
        /// </summary>
        [Test]
        public void Order_Fetch_Basic()
        {
            // Arrange
            OrderData orderData = TestsHelper.GetOrderData();

            var responseMock = TestsHelper.Mock(HttpMethod.Get, this.order.Location.ToString(), string.Empty, HttpStatusCode.OK, this.connectorMock);
            responseMock.Stub(x => x.Data<OrderData>()).Return(orderData);

            WebHeaderCollection headers = new WebHeaderCollection();
            headers[HttpResponseHeader.ContentType] = "application/json";

            responseMock.Stub(x => x.Headers).Return(headers);

            // Act
            var returnedCheckoutOrder = this.order.Fetch();

            // Assert
            Assert.AreEqual(returnedCheckoutOrder.PurchaseCountry, orderData.PurchaseCountry);
            Assert.AreEqual(returnedCheckoutOrder.PurchaseCurrency, orderData.PurchaseCurrency);
        }

        /// <summary>
        /// Basic test of Acknowledge.
        /// </summary>
        [Test]
        public void Order_Acknowledge_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.order.Location + "/acknowledge", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            // Act
            this.order.Acknowledge();
        }

        /// <summary>
        /// Basic test of Cancel.
        /// </summary>
        [Test]
        public void Order_Cancel_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.order.Location + "/cancel", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            this.order.Cancel();
        }

        /// <summary>
        /// Basic test of UpdateAuthorization.
        /// </summary>
        [Test]
        public void OrderManagement_Order_UpdateAuthorization_Basic()
        {
            // Arrange
            UpdateAuthorization updateAuthorization = TestsHelper.GetUpdateAuthorization();

            TestsHelper.Mock(HttpMethod.Patch, this.order.Location + "/authorization", updateAuthorization.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            this.order.UpdateAuthorization(updateAuthorization);
        }

        /// <summary>
        /// Basic test of ExtendAuthorizationTime.
        /// </summary>
        [Test]
        public void Order_ExtendAuthorizationTime_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.order.Location + "/extend-authorization-time", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            this.order.ExtendAuthorizationTime();
        }

        /// <summary>
        /// Basic test of UpdateMerchantReferences.
        /// </summary>
        [Test]
        public void Order_UpdateMerchantReferences_Basic()
        {
            // Arrange
            UpdateMerchantReferences updateMerchantReferences = TestsHelper.GetUpdateMerchantReferences();

            TestsHelper.Mock(HttpMethod.Patch, this.order.Location + "/merchant-references", updateMerchantReferences.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            // Act
            this.order.UpdateMerchantReferences(updateMerchantReferences);
        }

        /// <summary>
        /// Basic test of UpdateCustomerDetails.
        /// </summary>
        [Test]
        public void Order_UpdateCustomerDetails_Basic()
        {
            // Arrange
            UpdateCustomerDetails updateCustomerDetails = TestsHelper.GetUpdateCustomerDetails();

            TestsHelper.Mock(HttpMethod.Patch, this.order.Location + "/customer-details", updateCustomerDetails.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            this.order.UpdateCustomerDetails(updateCustomerDetails);
        }

        /// <summary>
        /// Basic test of Refund.
        /// </summary>
        [Test]
        public void Order_Refund_Basic()
        {
            // Arrange
            Refund refund = TestsHelper.GetRefund();

            TestsHelper.Mock(HttpMethod.Post, this.order.Location + "/refunds", refund.ConvertToJson(), HttpStatusCode.NoContent, this.connectorMock);

            this.order.Refund(refund);
        }

        /// <summary>
        /// Basic test of ReleaseRemainingAuthorization.
        /// </summary>
        [Test]
        public void Order_ReleaseRemainingAuthorization_Basic()
        {
            // Arrange
            TestsHelper.Mock(HttpMethod.Post, this.order.Location + "/release-remaining-authorization", string.Empty, HttpStatusCode.NoContent, this.connectorMock);

            this.order.ReleaseRemainingAuthorization();
        }

        #endregion
    }
}
