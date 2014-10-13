#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="FetchCheckout.cs" company="Klarna AB">
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
    using Klarna.Rest.Transport;

    /// <summary>
    /// Retrieve a checkout order.
    /// </summary>
    public class FetchCheckout
    {
        /// <summary>
        /// Example of how to fetch a checkout order.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";

            Uri orderUrl = new Uri("https://playground.api.klarna.com/checkout/v3/orders/12345");
            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.Checkout.CheckoutOrder checkoutOrder = new Klarna.Rest.Checkout.CheckoutOrder(connector, orderUrl);

            var checkoutOrderData = checkoutOrder.Fetch();

            Uri checkoutUrl = checkoutOrder.Location;
        }
    }
}
