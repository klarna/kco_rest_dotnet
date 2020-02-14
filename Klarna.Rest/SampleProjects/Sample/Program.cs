// Copyright 2019 Klarna AB
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

/// <summary>
/// This example creates a Klarna Checkout order in Sweden, using Swedish kronor (SEK), modifies and then updates it while reporting back information.
/// See https://github.com/klarna/kco_rest_dotnet/issues/24 for how to avoid common pitfalls while calculating order amounts.
/// </summary>

using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set your credentials and point to an API environment
            // Remember to set $MERCHANT_ID$ and $PASSWORD$ to your account's values
            // More about authentication here https://developers.klarna.com/api/#authentication
            Console.WriteLine("Setting up authentication against environment: {0:G}", KlarnaEnvironment.TestingEurope);
            var klarna = new Klarna.Rest.Core.Klarna("$MERCHANT_ID", "$PASSWORD$", KlarnaEnvironment.TestingEurope);

            Console.WriteLine("Constructing order body");
            // Prepare an order by constructing its body
            var order = new Klarna.Rest.Core.Model.CheckoutOrder
            {
                PurchaseCountry = "se",
                PurchaseCurrency = "sek",
                Locale = "sv-se",
                OrderAmount = 10000,
                OrderTaxAmount = 2000,
                MerchantUrls = new CheckoutMerchantUrls
                {
                    Terms = "https://www.example.com/terms.html",
                    Checkout = "https://www.example.com/checkout.html",
                    Confirmation = "https://www.example.com/confirmation.html",
                    Push = "https://www.example.com/push.html"
                },
                OrderLines = new List<OrderLine>()
                {
                    new OrderLine
                    {
                        Type = OrderLineType.physical,
                        Name = "Foo",
                        Quantity = 1,
                        UnitPrice = 10000,
                        TaxRate = 2500,
                        TotalAmount = 10000,
                        TotalTaxAmount = 2000,
                        TotalDiscountAmount = 0
                    }
                },
                CheckoutOptions = new CheckoutOptions
                {
                    AllowSeparateShippingAddress = false,
                    ColorButton = "#FF9900",
                    ColorButtonText = "#FF9900",
                    ColorCheckbox = "#FF9900",
                    ColorCheckboxCheckmark = "#FF9900",
                    ColorHeader = "#FF9900",
                    ColorLink = "#FF9900",
                    DateOfBirthMandatory = false,
                    ShippingDetails = "bar",
                    AllowedCustomerTypes =  new List<string>(){"person", "organization"}
                }
            };

            // Proceed with operating against the Klarna Checkout API
            try
            {
                // Create the order
                Console.WriteLine("Calling Klarna API to create order");
                var createdOrder = klarna.Checkout.CreateOrder(order).Result;
                Console.WriteLine("Klarna API returned created order with ID {0:G}", createdOrder.OrderId);

                // Superfluous, just to show you that you can retrieve a created order after the fact
                var fetchedOrder = klarna.Checkout.GetOrder(createdOrder.OrderId).Result;
                Console.WriteLine("Fetching order with ID {0:G} from Klarna API", createdOrder.OrderId);

                // Modify the created order by adding an item
                Console.WriteLine("Modifying order by adding a new OrderLine item");
                fetchedOrder.OrderLines.Add(new OrderLine
                {
                    Type = OrderLineType.physical,
                    Name = "Foo2",
                    Quantity = 1,
                    UnitPrice = 10000,
                    TaxRate = 2500,
                    TotalAmount = 10000,
                    TotalTaxAmount = 2000,
                    TotalDiscountAmount = 0,
                });
                // Update the amounts appropriately taking into account all Orderlines 
                fetchedOrder.OrderAmount = 20000;
                fetchedOrder.OrderTaxAmount = 4000;

                // Update the order via calling the Klarna Checkout API
                Console.WriteLine("Update order by calling the Klarna API with modified order details");
                var updatedOrder = klarna.Checkout.UpdateOrder(fetchedOrder).Result;
                Console.WriteLine("Klarna API responded with updated order details for order with ID {0:G}", updatedOrder.OrderId);
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions) {
                    if (e is ApiException)
                    {
                        var apiException = (ApiException) e;
                        Console.WriteLine("Status code: " + apiException.StatusCode);
                        Console.WriteLine("Error: " + string.Join("; ", apiException.ErrorMessage.ErrorMessages));
                    }
                    else {
                        // Rethrow any other exception or process it
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }
        }
    }
}
