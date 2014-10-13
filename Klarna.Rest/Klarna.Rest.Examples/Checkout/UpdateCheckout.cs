#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateCheckout.cs" company="Klarna AB">
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

    /// <summary>
    /// Example: Update a checkout order. 
    /// </summary>
    public class UpdateCheckout
    {
        /// <summary>
        /// Update a checkout order.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            Uri orderUrl = new Uri("https://playground.api.klarna.com/checkout/v3/orders/12345");

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.Checkout.CheckoutOrder checkout = new Klarna.Rest.Checkout.CheckoutOrder(connector, orderUrl);

            Klarna.Rest.Models.CheckoutOrderData orderData = GetCheckoutOrderData();

            checkout.Update(orderData);
        }

        /// <summary>
        /// Get checkout order.
        /// </summary>
        /// <returns>a checkout order</returns>
        private static CheckoutOrderData GetCheckoutOrderData()
        {
            Klarna.Rest.Models.CheckoutOrderData order = new CheckoutOrderData();
            order.OrderAmount = 11000;
            order.OrderTaxAmount = 2200;
            order.OrderLines = OrderLines();

            return order;
        }

        /// <summary>
        /// Get order lines.
        /// </summary>
        /// <returns>the order lines</returns>
        private static List<OrderLine> OrderLines()
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

            OrderLine newOrderLine = new OrderLine()
            {
                Type = "shipping_fee",
                Name = "Express delivery",
                Quantity = 1,
                UnitPrice = 1000,
                TaxRate = 2500,
                TotalAmount = 1000,
                TotalTaxAmount = 200
            };

            return new List<OrderLine> { orderLine, orderLine2, newOrderLine };
        }
    }
}
