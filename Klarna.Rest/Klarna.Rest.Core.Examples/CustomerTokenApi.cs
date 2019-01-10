using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Model.Enum;
using Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Examples
{
    public class CustomerTokenApi
    {
        /// <summary>
        /// Gets the customer token details.
        /// </summary>
        public void GetCustomerTokenDetails()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var customerToken = "234534...345345....345";
            try
            {
                var session = klarna.CustomerToken.GetCustomerTokenDetails(customerToken).Result;
                Console.WriteLine("payment method: " + session.PaymentMethodType);
                Console.WriteLine("Status: " + session.Status);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.ErrorMessage.ErrorCode);
                Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                Console.WriteLine(ex.ErrorMessage.CorrelationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CreateOrderOnCustomerToken()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var customerToken = "234534...345345....345";
            var orderData = new CustomerTokenOrder
            {
                PurchaseCurrency = "SEK",
                OrderAmount = 1000,
                OrderTaxAmount = 2000,
                MerchantReference1 = "StoreOrderId",
                AutoCapture = true, 
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
            };
            try
            {
                var order = klarna.CustomerToken.CreateOrder(customerToken, orderData).Result;
                Console.WriteLine("OrderId: " + order.OrderId);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.ErrorMessage.ErrorCode);
                Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                Console.WriteLine(ex.ErrorMessage.CorrelationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
