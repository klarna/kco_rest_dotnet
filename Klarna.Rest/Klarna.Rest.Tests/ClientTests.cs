#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ClientTests.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests
{
    using System;
    using Klarna.Rest.Checkout;
    using Klarna.Rest.OrderManagement;
    using Klarna.Rest.Transport;
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Tests the Client class.
    /// </summary>
    [TestFixture]
    public class ClientTests
    {
        /// <summary>
        /// Checkout url.
        /// </summary>
        private readonly Uri checkoutUrl = new Uri("https://localhost/checkout/v3/orders/12345");

        /// <summary>
        /// Order id.
        /// </summary>
        private readonly string orderId = "12345";

        /// <summary>
        /// Order url.
        /// </summary>
        private readonly Uri orderUrl = new Uri("https://localhost/ordermanagement/v1/orders/12345");

        /// <summary>
        /// Capture id.
        /// </summary>
        private readonly string captureId = "23456";

        /// <summary>
        /// The transport connector.
        /// </summary>
        private IConnector connector;

        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.connector = MockRepository.GenerateStub<IConnector>();
            this.client = new Client(this.connector);
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of TestBaseUrl property.
        /// </summary>
        [Test]
        public void Client_TestBaseUrl()
        {
            Uri url = Client.TestBaseUrl;

            Assert.That(url, Is.Not.Null);
        }

        /// <summary>
        /// Basic test of BaseUrl property.
        /// </summary>
        [Test]
        public void Client_BaseUrl()
        {
            Uri url = Client.BaseUrl;

            Assert.That(url, Is.Not.Null);
        }

        /// <summary>
        /// Test the alternate constructor.
        /// </summary>
        [Test]
        public void Client_Constructor()
        {
            Client client = new Client("0", "sharedSecret", new Uri("https://localhost/path"));

            Assert.That(client.Connector, Is.Not.Null);
            Assert.That(client.Connector.UserAgent, Is.Not.Null);
        }

        /// <summary>
        /// Test Connector property.
        /// </summary>
        [Test]
        public void Client_Get_Connector()
        {
            Assert.That(this.client.Connector, Is.SameAs(this.connector));
        }

        /// <summary>
        /// Test factory method for ICheckoutOrder.
        /// </summary>
        [Test]
        public void Client_NewCheckoutOrder()
        {
            ICheckoutOrder checkout = this.client.NewCheckoutOrder();

            Assert.That(checkout, Is.Not.Null);
            Assert.That(checkout.Location, Is.Null);
        }

        /// <summary>
        /// Test factory method for ICheckoutOrder with url.
        /// </summary>
        public void Client_NewCheckoutOrder_Url()
        {
            ICheckoutOrder checkout = this.client.NewCheckoutOrder(this.checkoutUrl);

            Assert.That(checkout, Is.Not.Null);
            Assert.That(checkout.Location, Is.EqualTo(this.checkoutUrl));
        }

        /// <summary>
        /// Test factory method for IOrder.
        /// </summary>
        [Test]
        public void Client_NewOrder()
        {
            IOrder order = this.client.NewOrder(this.orderId);

            Assert.That(order, Is.Not.Null);
            Assert.That(order.Location, Is.Not.Null);
            Assert.That(order.Location.ToString(), Is.EqualTo(((Order)order).Path + "/" + this.orderId));
        }

        /// <summary>
        /// Test factory method for ICapture.
        /// </summary>
        [Test]
        public void Client_NewCapture()
        {
            ICapture capture = this.client.NewCapture(this.orderUrl);

            Assert.That(capture, Is.Not.Null);
            Assert.That(capture.Location.ToString(), Is.EqualTo(this.orderUrl + "/captures"));
        }

        /// <summary>
        /// Test factory method for ICapture with id.
        /// </summary>
        [Test]
        public void Client_NewCaptureId()
        {
            ICapture capture = this.client.NewCapture(this.orderUrl, this.captureId);

            Assert.That(capture, Is.Not.Null);
            Assert.That(capture.Location.ToString(), Is.EqualTo(this.orderUrl + "/captures/" + this.captureId));
        }

        #endregion
    }
}
