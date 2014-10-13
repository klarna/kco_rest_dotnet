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
    public class Capture : Resource
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Capture" /> class.
        /// </summary>
        /// <param name="connector">the connector</param>
        /// <param name="orderUrl">the order url</param>
        /// <param name="captureId">the capture id</param>
        public Capture(IConnector connector, Uri orderUrl, string captureId)
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

        #region Implementation of Resource

        /// <summary>
        /// The orders path.
        /// </summary>
        public override string Path
        {
            get
            {
                return "/captures";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="captureData">the capture</param>
        /// <returns>this resource</returns>
        public Capture Create(CaptureData captureData)
        {
            this.Location = Post(Location.ToString(), captureData, HttpStatusCode.Created).Location;

            return this;
        }

        /// <summary>
        /// Fetches the capture.
        /// </summary>
        /// <returns>this resource</returns>
        public CaptureData Fetch()
        {
            return Get(Location.ToString(), HttpStatusCode.OK).Data<CaptureData>();
        }

        /// <summary>
        /// Appends shipping information to the capture.
        /// </summary>
        /// <param name="shippingInfo">the shippingInfo</param>
        /// <returns>this resource</returns>
        public Capture AddShippingInfo(AddShippingInfo shippingInfo)
        {
            this.Post(this.Location + "/shipping-info", shippingInfo, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Updates the customers details.
        /// </summary>
        /// <param name="updateCustomerDetails">the updateCustomerDetails</param>
        /// <returns>this resource</returns>
        public Capture UpdateCustomerDetails(UpdateCustomerDetails updateCustomerDetails)
        {
            this.Patch(this.Location + "/customer-details", updateCustomerDetails, HttpStatusCode.NoContent);

            return this;
        }

        /// <summary>
        /// Trigger send outs for this capture.
        /// </summary>
        /// <returns>this resource</returns>
        public Capture TriggerSendOut()
        {
            this.Post(this.Location + "/trigger-send-out", null, HttpStatusCode.NoContent);

            return this;
        }

        #endregion
    }
}
