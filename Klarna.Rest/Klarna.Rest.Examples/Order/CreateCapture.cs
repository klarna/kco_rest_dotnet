#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CreateCapture.cs" company="Klarna AB">
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
namespace Klarna.Rest.Examples.Order
{
    using System;
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Example: Capture the supplied amount.
    /// Use this call when fulfillment is completed, e.g. physical goods are being shipped to the customer.
    /// </summary>
    public class CreateCapture
    {
        /// <summary>
        /// Example of how to create a capture.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            order.CreateCapture(GetCapture());
        }

        /// <summary>
        /// Get capture
        /// </summary>
        /// <returns>a capture</returns>
        private static CaptureData GetCapture()
        {
            CaptureData capture = new CaptureData()
            {
                CapturedAmount = 6000,
                Description = "Shipped part of the order",
                OrderLines = GetOrderLines(),
                ShippingInfo = new List<ShippingInfo>() { GetShippingInfo() }
            };

            return capture;
        }

        /// <summary>
        /// Get order lines
        /// </summary>
        /// <returns>order lines</returns>
        private static IList<OrderLine> GetOrderLines()
        {
            OrderLine orderLine = new OrderLine
            {
                Type = "physical",
                Reference = "123050",
                Name = "Tomatoes",
                Quantity = 10,
                QuantityUnit = "kg",
                UnitPrice = 600,
                TaxRate = 2500,
                TotalAmount = 6000,
                TotalTaxAmount = 1200
            };

            return new List<OrderLine> { orderLine };
        }

        /// <summary>
        /// Get shipping info
        /// </summary>
        /// <returns> a shipping info</returns>
        private static ShippingInfo GetShippingInfo()
        {
            ShippingInfo shippingInfo = new ShippingInfo
            {
                ShippingCompany = "DHL",
                ShippingMethod = "Home",
                TrackingUri = new Uri("http://www.dhl.com/content/g0/en/express/tracking.shtml?brand=DHL&AWB=1234567890"),
                TrackingNumber = "1234567890",
                ReturnTrackingNumber = "E-55-KL",
                ReturnShippingCompany = "DHL",
                ReturnTrackingUri = new Uri("http://www.dhl.com/content/g0/en/express/tracking.shtml?brand=DHL&AWB=98389222")
            }; 
            
            return shippingInfo;
        }
    }
}
