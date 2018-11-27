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
            var klarna = new Klarna.Rest.Core.Klarna("K501001_a0dccbb272e5", "eJxoWRXrpLQ0JcIp", KlarnaEnvironment.TestingEurope);

            var order = new Klarna.Rest.Core.Model.CheckoutOrder
            {
                PurchaseCountry = "se",
                PurchaseCurrency = "sek",
                Locale = "sv-se",
                OrderAmount = 10000,
                OrderTaxAmount = 3000,
                MerchantUrls = new CheckoutMerchantUrls
                {
                    Terms = "https://www.estore.com/terms.html",
                    Checkout = "https://www.estore.com/checkout.html",
                    Confirmation = "https://www.estore.com/confirmation.html",
                    Push = "https://www.estore.com/push.html"
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
                        TotalDiscountAmount = 0,
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
                }
            };
            try
            {
                var createdOrder = klarna.Checkout.CreateOrder(order).Result;
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex);
            }
            

            var fetchedOrder = klarna.Checkout.GetOrder("56fb8a38-1e83-4dd7-a89f-9f297e7e95eb").Result;

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
            fetchedOrder.OrderAmount = 20000;
            fetchedOrder.OrderTaxAmount = 2000;

            var updatedOrder = klarna.Checkout.UpdateOrder(fetchedOrder).Result;


        }
    }
}
