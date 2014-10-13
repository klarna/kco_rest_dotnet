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
    using Klarna.Rest.Transport;

    /// <summary>
    /// Checkout order resource.
    /// </summary>
    public class CheckoutOrder : Resource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutOrder" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderUrl">the order id</param>
        public CheckoutOrder(IConnector connector, Uri orderUrl)
            : base(connector)
        {
            this.Location = orderUrl;
        }

        #endregion

        #region Implementation of Resource

        /// <summary>
        /// The orders path.
        /// </summary>
        public override string Path
        {
            get
            {
                return "/checkout/v3/orders";
            }
        }

        #endregion        

        #region Methods

        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order</param>
        /// <returns>the resource</returns>
        public CheckoutOrder Create(Klarna.Rest.Models.CheckoutOrderData checkoutOrderData)
        {
            this.Location = Post(this.Path, checkoutOrderData, HttpStatusCode.Created).Location;

            return this;
        }

        /// <summary>
        /// Updates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order</param>
        /// <returns>the resource</returns>
        public Models.CheckoutOrderData Update(Klarna.Rest.Models.CheckoutOrderData checkoutOrderData)
        {
            return Post(this.Location.ToString(), checkoutOrderData, HttpStatusCode.OK).Data<Models.CheckoutOrderData>();
        }

        /// <summary>
        /// Fetches the resource.
        /// </summary>
        /// <returns>the Checkout order</returns>
        public Models.CheckoutOrderData Fetch()
        {
            return Get(this.Location.ToString(), HttpStatusCode.OK).Data<Models.CheckoutOrderData>();
        }

        #endregion
    }
}
