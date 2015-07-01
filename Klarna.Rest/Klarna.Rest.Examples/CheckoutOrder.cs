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
namespace Klarna.Rest.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Klarna.Rest.Checkout;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.EMD;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Checkout order resource examples.
    /// </summary>
    public class CheckoutOrder
    {
        #region Create

        /// <summary>
        /// Create a checkout order.
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

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.EuTestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder();

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

                OrderLine orderLine2 = new OrderLine
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                };

                MerchantUrls merchantUrls = new MerchantUrls
                {
                    Terms = new Uri("http://www.merchant.com/toc"),
                    Checkout = new Uri("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}"),
                    Confirmation = new Uri("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}"),
                    Push = new Uri("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}")
                };

                CheckoutOrderData orderData = new CheckoutOrderData()
                {
                    PurchaseCountry = "gb",
                    PurchaseCurrency = "gbp",
                    Locale = "en-gb",
                    OrderAmount = 10000,
                    OrderTaxAmount = 2000,
                    OrderLines = new List<OrderLine> { orderLine, orderLine2 },
                    MerchantUrls = merchantUrls
                };

                try
                {
                    checkout.Create(orderData);
                    orderData = checkout.Fetch();

                    string orderID = orderData.OrderId;
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Attachment

        /// <summary>
        /// Create a checkout order with an optional extra merchant data attachment.
        /// </summary>
        public class AttachmentExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.EuTestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder();

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

                OrderLine orderLine2 = new OrderLine
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                };

                MerchantUrls merchantUrls = new MerchantUrls
                {
                    Terms = new Uri("http://www.merchant.com/toc"),
                    Checkout = new Uri("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}"),
                    Confirmation = new Uri("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}"),
                    Push = new Uri("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}")
                };

                List<PaymentHistoryFull> purchaseHistoryFull = new List<PaymentHistoryFull>
                {
                    new PaymentHistoryFull
                    {
                        UniqueAccountIdentifier = "Test Testperson",
                        PaymentOption = "card",
                        NumberPaidPurchases = 1,
                        TotalAmountPaidPurchases = 10000,
                        DateOfLastPaidPurchase = DateTime.Now,
                        DateOfFirstPaidPurchase = DateTime.Now
                    }
                };

                ExtraMerchantData extraMerchantData = new ExtraMerchantData
                {
                    Body = new ExtraMerchantDataBody
                    {
                        PaymentHistoryFull = purchaseHistoryFull
                    }
                };

                CheckoutOrderData orderData = new CheckoutOrderData()
                {
                    PurchaseCountry = "gb",
                    PurchaseCurrency = "gbp",
                    Locale = "en-gb",
                    OrderAmount = 10000,
                    OrderTaxAmount = 2000,
                    OrderLines = new List<OrderLine> { orderLine, orderLine2 },
                    MerchantUrls = merchantUrls,
                    Attachment = extraMerchantData
                };

                try
                {
                    checkout.Create(orderData);
                    orderData = checkout.Fetch();

                    string orderID = orderData.OrderId;
                    ExtraMerchantData emd = orderData.Attachment;
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Retrieve a checkout order.
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
                string orderID = "12345";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.EuTestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder order = client.NewCheckoutOrder(orderID);

                try
                {
                    CheckoutOrderData orderData = order.Fetch();
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Update a checkout order.
        /// </summary>
        public class UpdateExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderID = "12345";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.EuTestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder(orderID);

                CheckoutOrderData orderData = new CheckoutOrderData();
                orderData.OrderAmount = 11000;
                orderData.OrderTaxAmount = 2200;

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

                lines.Add(new OrderLine()
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                });

                lines.Add(new OrderLine()
                {
                    Type = "shipping_fee",
                    Name = "Express delivery",
                    Quantity = 1,
                    UnitPrice = 1000,
                    TaxRate = 2500,
                    TotalAmount = 1000,
                    TotalTaxAmount = 200
                });

                orderData.OrderLines = lines;

                try
                {
                    orderData = checkout.Update(orderData);
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion
    }
}
