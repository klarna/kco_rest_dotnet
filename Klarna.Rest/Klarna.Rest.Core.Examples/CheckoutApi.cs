using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;
using Klarna.Rest.Core.Model.Checkout;

namespace Klarna.Rest.Core.Examples
{
    /// <summary>
    /// Create a checkout order
    /// </summary>
    public class CreateExample
    {
        /// <summary>
        /// Run the example code.
        /// Remember to replace username and password with valid Klarna credentials. 
        /// </summary>
        static void Main()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var client = new Klarna(username, password, KlarnaEnvironment.TestingEurope);

            var order = new Order
            {
                PurchaseCountry = "se",
                PurchaseCurrency = "sek",
                Locale = "sv-se",
                OrderAmount = 10000,
                OrderTaxAmount = 2000,
                MerchantUrls = new MerchantUrls
                {
                    Terms = "https://www.example.com/terms.html",
                    Checkout = "https://www.example.com/checkout.html",
                    Confirmation = "https://www.example.com/confirmation.html",
                    Push = "https://www.example.com/push.html"
                },
                OrderLines = new List<Model.Checkout.OrderLine>()
                {
                    new Model.Checkout.OrderLine
                    {
                        Type = OrderLineType.physical,
                        Name = "Foo",
                        Quantity = 1,
                        UnitPrice = 10000,
                        TaxRate = 2500,
                        TotalAmount = 10000,
                        TotalTaxAmount = 2000,
                        TotalDiscountAmount = 0,
                    }
                },
                CheckoutOptions = new Options
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
                    AllowedCustomerTypes = new List<string>(){"person", "organization"}
                }
            };

            try
            {
                var createdOrder = client.Checkout.CreateOrder(order).Result;
                var orderId = createdOrder.OrderId;
                Console.WriteLine($"Order ID: {orderId}");
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

    public class DiscountsExample
    {
        /// <summary>
        /// Run the example code.
        /// Remember to replace username and password with valid Klarna credentials. 
        /// </summary>
        static void Main()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var client = new Klarna(username, password, KlarnaEnvironment.TestingEurope);

            var order = new Order
            {
                PurchaseCountry = "gb",
                PurchaseCurrency = "gbp",
                Locale = "en-gb",
                OrderAmount = 9000,
                OrderTaxAmount = 818,
                MerchantUrls = new Model.Checkout.MerchantUrls
                {
                    Terms = "https://www.example.com/terms.html",
                    Checkout = "https://www.example.com/checkout.html",
                    Confirmation = "https://www.example.com/confirmation.html",
                    Push = "https://www.example.com/push.html"
                },
                OrderLines = new List<Model.Checkout.OrderLine>()
                {
                    new Model.Checkout.OrderLine
                    {
                        Type = OrderLineType.physical,
                        Reference = "19-402-USA",
                        Name = "Red T-Shirt",
                        Quantity = 1,
                        QuantityUnit = "pcs",
                        UnitPrice = 10000,
                        TaxRate = 1000,
                        TotalAmount = 10000,
                        TotalTaxAmount = 909
                    },

                    // Set a discount
                    new Model.Checkout.OrderLine
                    {
                        Type = OrderLineType.discount,
                        Reference = "10-gbp-order-discount",
                        Name = "Discount",
                        Quantity = 1,
                        UnitPrice = -1000,
                        TaxRate = 1000,
                        TotalAmount = -1000,
                        TotalTaxAmount = -91
                    }
                },
            };

            try
            {
                var createdOrder = client.Checkout.CreateOrder(order).Result;
                Console.WriteLine(createdOrder.HtmlSnippet);
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

    /// <summary>
    /// Retrieves a checkout order
    /// </summary>
    public class FetchExample
    {
        /// <summary>
        /// Run the example code.
        /// Remember to replace username and password with valid Klarna credentials. 
        /// </summary>
        public static void Main()
        {
            var username = "0_abc";
            var password = "sharedsecret";
            var orderId = "1234";

            var client = new Klarna(username, password, KlarnaEnvironment.TestingEurope);

            try
            {
                var order = client.Checkout.GetOrder(orderId).Result;
                Console.WriteLine(order.OrderId);
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

        /// <summary>
        /// Updates a checkout order
        /// </summary>
        public class FetchAndUpdateExample
        {
            /// <summary>
            /// Run the example code.
            /// Remember to replace username and password with valid Klarna credentials. 
            /// </summary>
            public static void Main()
            {
                var username = "0_abc";
                var password = "sharedsecret";
                var orderId = "1234";

                var client = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
                try
                {
                    var order = client.Checkout.GetOrder(orderId).Result;
                    order.OrderAmount = 20000;
                    order.OrderTaxAmount = 4000;
                    order.OrderLines = new List<Model.Checkout.OrderLine>
                    {
                        new Model.Checkout.OrderLine
                        {
                            Type = OrderLineType.physical,
                            Name = "Foo",
                            Quantity = 1,
                            UnitPrice = 10000,
                            TaxRate = 2500,
                            TotalAmount = 10000,
                            TotalTaxAmount = 2000,
                            TotalDiscountAmount = 0,
                        },
                        new Model.Checkout.OrderLine
                        {
                            Type = OrderLineType.physical,
                            Name = "Foo2",
                            Quantity = 1,
                            UnitPrice = 10000,
                            TaxRate = 2500,
                            TotalAmount = 10000,
                            TotalTaxAmount = 2000,
                            TotalDiscountAmount = 0,
                        }
                    };

                    var updatedOrder = client.Checkout.UpdateOrder(order).Result;
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
}
