#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="Klarna AB">
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
namespace Klarna.Rest.OrderManagement
{
    using System;
    using System.Net;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Checkout order resource.
    /// </summary>
    internal class Order : Resource, IOrder
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderId">the order id</param>
        internal Order(IConnector connector, string orderId)
            : base(connector)
        {
            if (string.IsNullOrEmpty(orderId))
            {
                this.Location = null;
            }
            else
            {
                this.Location = new Uri(this.Path + "/" + orderId, UriKind.RelativeOrAbsolute);
            }
        }

        #endregion

        #region Implementation of IOrder

        /// <summary>
        /// The orders path.
        /// </summary>
        internal override string Path
        {
            get
            {
                return "/ordermanagement/v1/orders";
            }
        }

        /// <summary>
        /// Fetches the order.
        /// </summary>
        /// <returns>the order data object</returns>
        public OrderData Fetch()
        {
            return this.Get(this.Location.ToString())
                .Status(HttpStatusCode.OK)
                .ContentType("application/json")
                .Response.Data<OrderData>();
        }

        /// <summary>
        /// Acknowledges the order.
        /// </summary>
        public void Acknowledge()
        {
            this.Post(this.Location + "/acknowledge", null)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Cancels the order.
        /// </summary>
        public void Cancel()
        {
            this.Post(this.Location + "/cancel", null)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Updates the authorization data.
        /// </summary>
        /// <param name="updateAuthorization">the updateAuthorization</param>
        public void UpdateAuthorization(UpdateAuthorization updateAuthorization)
        {
            this.Patch(this.Location + "/authorization", updateAuthorization)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Extends the authorization time.
        /// </summary>
        public void ExtendAuthorizationTime()
        {
            this.Post(this.Location + "/extend-authorization-time", null)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Update the merchant references.
        /// </summary>
        /// <param name="updateMerchantReferences">the update merchant references</param>
        public void UpdateMerchantReferences(UpdateMerchantReferences updateMerchantReferences)
        {
            this.Patch(this.Location + "/merchant-references", updateMerchantReferences)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Updates the customer details.
        /// </summary>
        /// <param name="updateCustomerDetails">the order</param>
        public void UpdateCustomerDetails(UpdateCustomerDetails updateCustomerDetails)
        {
            this.Patch(this.Location + "/customer-details", updateCustomerDetails)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Refunds an amount of a captured order.
        /// </summary>
        /// <param name="data">the refund data</param>
        public void Refund(Refund data)
        {
            this.Post(this.Location + "/refunds", data)
                .Status(HttpStatusCode.Created, HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Release the remaining authorization for an order.
        /// </summary>
        public void ReleaseRemainingAuthorization()
        {
            this.Post(this.Location + "/release-remaining-authorization", null)
                .Status(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
