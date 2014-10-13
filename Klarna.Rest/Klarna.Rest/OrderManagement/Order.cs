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
    public class Order : Resource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderId">the order id</param>
        public Order(IConnector connector, string orderId)
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

        #region Implementation of Resource

        /// <summary>
        /// The orders path.
        /// </summary>
        public override string Path
        {
            get
            {
                return "/ordermanagement/v1/orders";
            }
        }

        #endregion   

        #region Methods

        /// <summary>
        /// Fetches the order.
        /// </summary>
        /// <returns>the order data object</returns>
        public Models.OrderData Fetch()
        {
            return this.Get(this.Location.ToString(), HttpStatusCode.OK).Data<Models.OrderData>();
        }

        /// <summary>
        /// Acknowledges the order.
        /// </summary>
        /// <returns>this resource</returns>
        public Order Acknowledge()
        {
            this.Post(this.Location + "/acknowledge", null, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Cancels the order.
        /// </summary>
        /// <returns>this resource</returns>
        public Order Cancel()
        {
            this.Post(this.Location + "/cancel", null, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Updates the authorization data
        /// </summary>
        /// <param name="updateAuthorization">the updateAuthorization</param>
        /// <returns>this resource</returns>
        public Order UpdateAuthorization(UpdateAuthorization updateAuthorization)
        {
            this.Patch(this.Location + "/authorization", updateAuthorization, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Extends the authorization time.
        /// </summary>
        /// <returns>this resource</returns>
        public Order ExtendAuthorizationTime()
        {
            this.Post(this.Location + "/extend-authorization-time", null, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Update the merchant references.
        /// </summary>
        /// <param name="updateMerchantReferences">the update merchant references</param>
        /// <returns>this resource</returns>
        public Order UpdateMerchantReferences(UpdateMerchantReferences updateMerchantReferences)
        {
            this.Patch(this.Location + "/merchant-references", updateMerchantReferences, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Updates the customer details.
        /// </summary>
        /// <param name="updateCustomerDetails">the order</param>
        /// <returns>this resource</returns>
        public Order UpdateCustomerDetails(UpdateCustomerDetails updateCustomerDetails)
        {
            this.Patch(this.Location + "/customer-details", updateCustomerDetails, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Refunds an amount of a captured order.
        /// </summary>
        /// <param name="order">the order</param>
        /// <returns>this resource</returns>
        public Order Refund(Refund order)
        {
            this.Post(this.Location + "/refunds", order, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Release the remaining authorization for an order.
        /// </summary>
        /// <returns>this resource</returns>
        public Order ReleaseRemainingAuthorization()
        {
            this.Post(this.Location + "/release-remaining-authorization", null, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Capture all or part of an order.
        /// </summary>
        /// <param name="captureData">the capture</param>
        /// <returns>this resource</returns>
        public Capture CreateCapture(CaptureData captureData)
        {
            Capture capture = new Capture(this.Connector, Location, string.Empty);
            capture.Create(captureData);

            return capture;
        }

        /// <summary>
        /// Fetches the specified capture.
        /// </summary>
        /// <param name="captureId">the capture id</param>
        /// <returns>this resource</returns>
        public Capture FetchCapture(string captureId)
        {
            Capture capture = new Capture(this.Connector, Location, captureId);

            return capture;
        }

        #endregion   
    }
}
