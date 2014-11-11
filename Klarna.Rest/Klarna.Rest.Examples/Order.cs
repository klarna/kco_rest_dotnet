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
namespace Klarna.Rest.Examples
{
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.OrderManagement;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Order resource examples.
    /// </summary>
    public class Order
    {
        #region Fetch

        /// <summary>
        /// Retrieve a order.
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

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);

                OrderData orderData = order.Fetch();
            }
        }

        #endregion

        #region Acknowledge

        /// <summary>
        /// Acknowledge an authorized order.
        /// Merchants will receive the order confirmation push until the order has been acknowledged.
        /// </summary>
        public class AcknowledgeExample
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

                order.Acknowledge();
            }
        }

        #endregion

        #region Cancel

        /// <summary>
        /// Cancel an authorized order.
        /// For a cancellation to be successful, there must be no captures on the order.
        /// </summary>
        public class CancelExample
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

                order.Cancel();
            }
        }

        #endregion

        #region ExtendAuthorizationTime

        /// <summary>
        /// Extend the order's authorization by default period according to merchant contract.
        /// </summary>
        public class ExtendAuthorizationTimeExample
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

                order.ExtendAuthorizationTime();
            }
        }

        #endregion

        #region Refund

        /// <summary>
        /// Refund an amount of a captured order.
        /// The refunded amount will be credited to the customer.
        /// </summary>
        public class RefundExample
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

                List<OrderLine> lines = new List<OrderLine>();

                lines.Add(new OrderLine()
                {
                    Type = "physical",
                    Reference = "123050",
                    Name = "Tomatoes",
                    Quantity = 5,
                    QuantityUnit = "kg",
                    UnitPrice = 600,
                    TaxRate = 2500,
                    TotalAmount = 3000,
                    TotalTaxAmount = 600
                });

                Refund refund = new Refund()
                {
                    RefundedAmount = 3000,
                    Description = "Refunding half the tomatoes",
                    OrderLines = lines
                };

                order.Refund(refund);
            }
        }

        #endregion

        #region ReleaseRemainingAuthorization

        /// <summary>
        /// Release the remaining authorization for an order.
        /// Signal that there is no intention to perform further captures.
        /// </summary>
        public class ReleaseRemainingAuthorizationExample
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

                order.ReleaseRemainingAuthorization();
            }
        }

        #endregion

        #region UpdateCustomerDetails

        /// <summary>
        /// Update billing and/or shipping address for an order.
        /// This is subject to customer credit check.
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

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                IOrder order = client.NewOrder(orderId);

                UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails()
                {
                    ShippingAddress = new Address()
                    {
                        Email = "user@example.com",
                        Phone = "57-3895734"
                    },

                    BillingAddress = new Address()
                    {
                        Email = "user@example.com",
                        Phone = "57-3895734"
                    }
                };

                order.UpdateCustomerDetails(updateCustomerDetails);
            }
        }

        #endregion

        #region UpdateMerchantReferences

        /// <summary>
        /// Update one or both merchant references.
        /// Only the reference(s) in the body will be updated. To clear a reference, set its value to "" (empty string).
        /// </summary>
        public class UpdateMerchantReferencesExample
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

                UpdateMerchantReferences updateMerchantReferences = new UpdateMerchantReferences()
                {
                    MerchantReference1 = "15632423",
                    MerchantReference2 = "special order"
                };

                order.UpdateMerchantReferences(updateMerchantReferences);
            }
        }

        #endregion

        #region UpdateOrderLines

        /// <summary>
        /// Update the total order amount of an order.
        /// This is subject to a new customer credit check.
        /// </summary>
        public class UpdateOrderLinesExample
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

                UpdateAuthorization updateAuthorization = new UpdateAuthorization()
                {
                    OrderAmount = 6000,
                    Description = "Removed bad bananas",
                    OrderLines = lines
                };

                order.UpdateAuthorization(updateAuthorization);
            }
        }

        #endregion
    }
}
