#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="Capture.cs" company="Klarna AB">
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
    /// Capture resource.
    /// </summary>
    internal class Capture : Resource, ICapture
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Capture" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderUrl">the order url</param>
        /// <param name="captureId">the capture id</param>
        internal Capture(IConnector connector, Uri orderUrl, string captureId)
            : base(connector)
        {
            string location = orderUrl + this.Path;
            if (!string.IsNullOrEmpty(captureId))
            {
                location = location + "/" + captureId;
            }

            this.Location = new Uri(location, UriKind.RelativeOrAbsolute);
        }

        #endregion

        #region Implementation of ICapture

        /// <summary>
        /// The captures path.
        /// </summary>
        internal override string Path
        {
            get
            {
                return "/captures";
            }
        }

        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="captureData">the capture data</param>
        public void Create(CaptureData captureData)
        {
            this.Location = this.Post(Location.ToString(), captureData)
                .Status(HttpStatusCode.Created)
                .Location;
        }

        /// <summary>
        /// Fetches the capture.
        /// </summary>
        /// <returns>the capture data</returns>
        public CaptureData Fetch()
        {
            return Get(Location.ToString())
                .Status(HttpStatusCode.OK)
                .ContentType("application/json")
                .Response.Data<CaptureData>();
        }

        /// <summary>
        /// Appends shipping information to the capture.
        /// </summary>
        /// <param name="shippingInfo">the shipping info</param>
        public void AddShippingInfo(AddShippingInfo shippingInfo)
        {
            this.Post(this.Location + "/shipping-info", shippingInfo)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Updates the customers details.
        /// </summary>
        /// <param name="updateCustomerDetails">the customer details</param>
        public void UpdateCustomerDetails(UpdateCustomerDetails updateCustomerDetails)
        {
            this.Patch(this.Location + "/customer-details", updateCustomerDetails)
                .Status(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Trigger send outs for this capture.
        /// </summary>
        public void TriggerSendOut()
        {
            this.Post(this.Location + "/trigger-send-out", null)
                .Status(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
