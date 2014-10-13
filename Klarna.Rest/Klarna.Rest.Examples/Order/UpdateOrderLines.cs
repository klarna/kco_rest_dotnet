#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateOrderLines.cs" company="Klarna AB">
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
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Update the total order amount of an order. 
    /// This is subject to a new customer credit check.
    /// </summary>
    public class UpdateOrderLines
    {
        /// <summary>
        /// Example of how to update authorization.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            order.UpdateAuthorization(GetUpdateAuthorization());
        }

        /// <summary>
        /// Get update authorization.
        /// </summary>
        /// <returns>a update authorization</returns>
        private static UpdateAuthorization GetUpdateAuthorization()
        {
            UpdateAuthorization updateAuthorization = new UpdateAuthorization()
            {
                OrderAmount = 6000,
                Description = "Removed bad bananas",
                OrderLines = GetOrderLines()
            };

            return updateAuthorization;
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
                Quantity = 10,
                QuantityUnit = "kg",
                UnitPrice = 600,
                TaxRate = 2500,
                TotalAmount = 6000,
                TotalTaxAmount = 1200
            };

            return new List<OrderLine> { orderLine };
        }
    }
}
