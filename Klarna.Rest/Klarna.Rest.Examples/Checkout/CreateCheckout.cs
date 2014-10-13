#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CreateCheckout.cs" company="Klarna AB">
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
namespace Klarna.Rest.Examples.Checkout
{
    using System;
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;
    using NUnit.Framework;

    /// <summary>
    /// Create a checkout order.
    /// </summary>
    public class CreateCheckout
    {
        /// <summary>
        /// Example of how to create a checkout order.
        /// </summary>
        [Test]
        [Ignore]
        public void Example()
        { 
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            Uri baseUrl = ConnectorFactory.TestBaseUrl;

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, baseUrl);

            Klarna.Rest.Checkout.CheckoutOrder checkout = new Klarna.Rest.Checkout.CheckoutOrder(connector, null);
            Klarna.Rest.Models.CheckoutOrderData orderData = CreateOrderDataObject();

            checkout.Create(orderData);

            var checkoutOrderData = checkout.Fetch();

            Uri checkoutUrl = checkout.Location;
        }

        /// <summary>
        /// Create CheckoutOrder data object.
        /// </summary>
        /// <returns>the CheckoutOrder data object</returns>
        private static Models.CheckoutOrderData CreateOrderDataObject()
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
                Terms = new System.Uri("http://www.merchant.com/toc"),
                Checkout = new System.Uri("http://www.merchant.com/checkout?klarna_order_url={checkout.order.url}"),
                Confirmation = new System.Uri("http://www.merchant.com/thank-you?klarna_order_url={checkout.order.url}"),
                Push = new System.Uri("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}")
            };

            Klarna.Rest.Models.CheckoutOrderData theOrder = new Models.CheckoutOrderData()
            {
                PurchaseCountry = "gb",
                PurchaseCurrency = "gbp",
                Locale = "en-gb",
                OrderAmount = 10000,
                OrderTaxAmount = 2000,
                OrderLines = new List<OrderLine> { orderLine, orderLine2 },
                MerchantUrls = merchantUrls
            };

            return theOrder;
        }
    }
}
