#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="Klarna AB">
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
namespace Klarna.Rest
{
    using System;
    using Klarna.Rest.Checkout;
    using Klarna.Rest.OrderManagement;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Client interface for the API resources.
    /// </summary>
    public class Client
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        public Client(IConnector connector)
        {
            this.Connector = connector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="merchantId">the merchant id</param>
        /// <param name="sharedSecret">the shared secret</param>
        /// <param name="baseUrl">the base url</param>
        public Client(string merchantId, string sharedSecret, Uri baseUrl)
        {
            this.Connector = ConnectorFactory.Create(merchantId, sharedSecret, baseUrl);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the base url.
        /// </summary>
        public static Uri BaseUrl
        {
            get
            {
                return new Uri("https://api.klarna.com");
            }
        }

        /// <summary>
        /// Gets the test base url.
        /// </summary>
        public static Uri TestBaseUrl
        {
            get
            {
                return new Uri("https://api.playground.klarna.com");
            }
        }

        /// <summary>
        /// Gets the connector.
        /// </summary>
        public IConnector Connector { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new instance of the <see cref="ICapture"/> interface.
        /// </summary>
        /// <param name="orderUrl">location of the order</param>
        /// <returns>the capture</returns>
        public ICapture NewCapture(Uri orderUrl)
        {
            return this.NewCapture(orderUrl, null);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ICapture"/> interface.
        /// </summary>
        /// <param name="orderUrl">location of the order</param>
        /// <param name="captureId">the capture id</param>
        /// <returns>the capture</returns>
        public ICapture NewCapture(Uri orderUrl, string captureId)
        {
            Capture capture = new Capture(this.Connector, orderUrl, captureId);

            return capture;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="IOrder"/> interface.
        /// </summary>
        /// <param name="orderId">the order id</param>
        /// <returns>the order</returns>
        public IOrder NewOrder(string orderId)
        {
            Order order = new Order(this.Connector, orderId);

            return order;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ICheckoutOrder"/> interface.
        /// </summary>
        /// <returns>the checkout order</returns>
        public ICheckoutOrder NewCheckoutOrder()
        {
            return this.NewCheckoutOrder(null);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ICheckoutOrder"/> interface.
        /// </summary>
        /// <param name="orderID">id of the checkout order</param>
        /// <returns>the checkout order</returns>
        public ICheckoutOrder NewCheckoutOrder(string orderID)
        {
            CheckoutOrder order = new CheckoutOrder(this.Connector, orderID);

            return order;
        }

        #endregion
    }
}
