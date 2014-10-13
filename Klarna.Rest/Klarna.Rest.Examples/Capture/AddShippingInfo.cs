#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="AddShippingInfo.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests.Capture
{
    using System;
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Appends shipping info to a capture.
    /// </summary>
    public class AddShippingInfo
    {
        /// <summary>
        /// Example of how to add shipping information.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";
            string captureId = "34567";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            Klarna.Rest.OrderManagement.Capture capture = order.FetchCapture(captureId);

            capture.AddShippingInfo(GetShippingInfo());
        }

        /// <summary>
        /// Get shipping info.
        /// </summary>
        /// <returns> a shipping info</returns>
        private static Klarna.Rest.Models.Requests.AddShippingInfo GetShippingInfo()
        {
            ShippingInfo shippingInfo = new ShippingInfo
            {
                ShippingCompany = "DHL åäö",
                ShippingMethod = "Home",
                TrackingUri = new Uri("http://www.dhl.com/content/g0/en/express/tracking.shtml?brand=DHL&AWB=1234567890"),
                TrackingNumber = "1234567890",
                ReturnTrackingNumber = "E-55-KL",
                ReturnShippingCompany = "DHL",
                ReturnTrackingUri = new Uri("http://www.dhl.com/content/g0/en/express/tracking.shtml?brand=DHL&AWB=98389222")
            };

            Klarna.Rest.Models.Requests.AddShippingInfo addShippingInfo = new Klarna.Rest.Models.Requests.AddShippingInfo();
            addShippingInfo.ShippingInfo = new List<ShippingInfo>() { shippingInfo };

            return addShippingInfo;
        }
    }
}
