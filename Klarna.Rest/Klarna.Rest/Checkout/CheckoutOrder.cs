#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOrder.cs" company="Klarna AB">
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
namespace Klarna.Rest.Checkout
{
    using System;
    using System.Net;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Checkout order resource.
    /// </summary>
    internal class CheckoutOrder : Resource, ICheckoutOrder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutOrder" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderID">the order id</param>
        internal CheckoutOrder(IConnector connector, string orderID)
            : base(connector)
        {
            this.Location = null;

            if (!string.IsNullOrEmpty(orderID))
            {
                this.Location = new Uri(
                    string.Concat(this.Path, "/", orderID),
                    UriKind.RelativeOrAbsolute);
            }
        }

        #endregion

        #region Implementation of ICheckoutOrder

        /// <summary>
        /// The orders path.
        /// </summary>
        internal override string Path
        {
            get
            {
                return "/checkout/v3/orders";
            }
        }

        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order data</param>
        public void Create(CheckoutOrderData checkoutOrderData)
        {
            this.Location = Post(this.Path, checkoutOrderData)
                .Status(HttpStatusCode.Created)
                .Location;
        }

        /// <summary>
        /// Updates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order data</param>
        /// <returns>the updated checkout order data</returns>
        public CheckoutOrderData Update(CheckoutOrderData checkoutOrderData)
        {
            return Post(this.Location.ToString(), checkoutOrderData)
                .Status(HttpStatusCode.OK)
                .ContentType("application/json")
                .Response.Data<CheckoutOrderData>();
        }

        /// <summary>
        /// Fetches the resource.
        /// </summary>
        /// <returns>the checkout order data</returns>
        public CheckoutOrderData Fetch()
        {
            return Get(this.Location.ToString())
                .Status(HttpStatusCode.OK)
                .ContentType("application/json")
                .Response.Data<CheckoutOrderData>();
        }

        #endregion
    }
}
