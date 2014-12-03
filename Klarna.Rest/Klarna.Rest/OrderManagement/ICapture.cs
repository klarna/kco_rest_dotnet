#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ICapture.cs" company="Klarna AB">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;

    /// <summary>
    /// Capture resource interface.
    /// </summary>
    public interface ICapture : IResource
    {
        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="captureData">the capture data</param>
        void Create(CaptureData captureData);

        /// <summary>
        /// Fetches the capture.
        /// </summary>
        /// <returns>the capture data</returns>
        CaptureData Fetch();

        /// <summary>
        /// Appends shipping information to the capture.
        /// </summary>
        /// <param name="shippingInfo">the shipping info</param>
        void AddShippingInfo(AddShippingInfo shippingInfo);

        /// <summary>
        /// Updates the customers details.
        /// </summary>
        /// <param name="updateCustomerDetails">the customer details</param>
        void UpdateCustomerDetails(UpdateCustomerDetails updateCustomerDetails);

        /// <summary>
        /// Trigger send outs for this capture.
        /// </summary>
        void TriggerSendOut();
    }
}
