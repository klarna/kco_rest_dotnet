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
namespace Klarna.Rest.Examples
{
    using System;
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.OrderManagement;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Capture resource examples.
    /// </summary>
    public class Capture
    {
        #region Create

        /// <summary>
        /// Capture the supplied amount.
        /// Use this call when fulfillment is completed, e.g. physical goods are being shipped to the customer.
        /// </summary>
        public class CreateExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderId = "12345";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);
                ICapture capture = client.NewCapture(order.Location);

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
                List<OrderLine> lines = new List<OrderLine>();

                lines.Add(new OrderLine()
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
                });

                CaptureData captureData = new CaptureData()
                {
                    CapturedAmount = 6000,
                    Description = "Shipped part of the order",
                    OrderLines = lines,
                    ShippingInfo = new List<ShippingInfo>() { shippingInfo }
                };

                capture.Create(captureData);
            }
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Retrieve a capture.
        /// </summary>
        public class FetchExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderId = "12345";
                string captureId = "34567";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);
                ICapture capture = client.NewCapture(order.Location, captureId);

                CaptureData captureData = capture.Fetch();
            }
        }

        #endregion

        #region AddShippingInfo

        /// <summary>
        /// Appends shipping info to a capture.
        /// </summary>
        public class AddShippingInfoExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderId = "12345";
                string captureId = "34567";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);
                ICapture capture = client.NewCapture(order.Location, captureId);

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

                AddShippingInfo addShippingInfo = new AddShippingInfo();
                addShippingInfo.ShippingInfo = new List<ShippingInfo>() { shippingInfo };

                capture.AddShippingInfo(addShippingInfo);
            }
        }

        #endregion

        #region TriggerSendOut

        /// <summary>
        /// Trigger a new send out of customer communication.
        /// </summary>
        public class TriggerSendOutExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderId = "12345";
                string captureId = "34567";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);
                ICapture capture = client.NewCapture(order.Location, captureId);

                capture.TriggerSendOut();
            }
        }

        #endregion

        #region UpdateCustomerDetails

        /// <summary>
        /// Update the billing address for a capture. Shipping address can not be updated.
        /// </summary>
        public class UpdateCustomerDetailsExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderId = "12345";
                string captureId = "34567";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);
                ICapture capture = client.NewCapture(order.Location, captureId);

                UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails()
                {
                    BillingAddress = new Address()
                    {
                        Email = "user@example.com",
                        Phone = "57-3895734"
                    }
                };

                capture.UpdateCustomerDetails(updateCustomerDetails);
            }
        }

        #endregion
    }
}
