#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="RefundOrder.cs" company="Klarna AB">
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
    using System.Collections.Generic;
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Refund an amount of a captured order. 
    /// The refunded amount will be credited to the customer.
    /// </summary>
    public class RefundOrder
    {
        /// <summary>
        /// Example of how to refund an amount of a captured order.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            order.Refund(GetRefund());
        }

        /// <summary>
        /// Get refund.
        /// </summary>
        /// <returns>a refund</returns>
        private static Refund GetRefund()
        {
            Refund refund = new Refund()
            {
                RefundedAmount = 3000,
                Description = "Refunding half the tomatoes",
                OrderLines = GetOrderLines()
            };

            return refund;
        }

        /// <summary>
        /// Get order lines.
        /// </summary>
        /// <returns>order lines</returns>
        private static IList<OrderLine> GetOrderLines()
        {
            OrderLine orderLine = new OrderLine
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
            };

            return new List<OrderLine> { orderLine };
        }
    }
}
