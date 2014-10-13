#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateCustomerDetails.cs" company="Klarna AB">
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
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Update billing and/or shipping address for an order. 
    /// This is subject to customer credit check.
    /// </summary>
    public class UpdateCustomerDetails
    {
        /// <summary>
        /// Example of how to update customer details.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            order.UpdateCustomerDetails(GetUpdateCustomerDetails());
        }

        /// <summary>
        /// Get update customer details.
        /// </summary>
        /// <returns>a update customer details</returns>
        private static Klarna.Rest.Models.Requests.UpdateCustomerDetails GetUpdateCustomerDetails()
        {
            Klarna.Rest.Models.Requests.UpdateCustomerDetails updateCustomerDetails = new Klarna.Rest.Models.Requests.UpdateCustomerDetails()
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

            return updateCustomerDetails;
        }
    }
}
