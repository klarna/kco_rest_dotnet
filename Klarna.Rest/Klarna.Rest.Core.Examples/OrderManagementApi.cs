using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Model.Enum;
using Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Examples
{
    class OrderManagementApi
    {
        /// <summary>
        /// Gets the order.
        /// </summary>
        public void GetOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {

                var order = klarna.OrderManagement.GetOrder(orderId).Result;
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
        /// Acknowledges the order.
        /// </summary>
        public void AcknowledgeOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {

               klarna.OrderManagement.AcknowledgeOrder(orderId).RunSynchronously();
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
        /// Captures the order.
        /// </summary>
        public void CaptureOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {
                var captureData = new OrderManagementCreateCapture
                {
                    CapturedAmount = 10000,
                    Description = "Full capture of the order",
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
                    ShippingInfo = new List<OrderManagementShippingInfo>()
                    {
                        new OrderManagementShippingInfo
                        {
                            ShippingMethod = OrderManagementShippingMethod.PickUpPoint,
                            ShippingCompany = "PostNord",
                            TrackingUri ="https://trackingpageofcarrier.com",
                            TrackingNumber = "345...33",
                            ReturnTrackingUri ="https://trackingpageofreturntracking.com",
                            ReturnTrackingNumber ="675...575",
                            ReturnShippingCompany ="PostNord"
                        }
                    }
                };
                klarna.OrderManagement.CreateCapture(orderId, captureData).RunSynchronously();

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
        /// Cancels the order.
        /// </summary>
        public void CancelOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {
                klarna.OrderManagement.CancelOrder(orderId).RunSynchronously();
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
        /// Refunds the order.
        /// </summary>
        public void RefundOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {
                var refundData = new OrderManagementRefund
                {
                    RefundedAmount = 10000,
                    Description = "Full refund for order",
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
                    }
                };
               var refund = klarna.OrderManagement.CreateAndFetchRefund(orderId,refundData).Result;
               Console.WriteLine("Order has been refunded");
               Console.WriteLine(refund.RefundId);
               Console.WriteLine(refund.RefundedAt);
               Console.WriteLine(refund.RefundedAmount);
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
        /// Resends the consumer sendouts.
        /// </summary>
        public void ResendConsumerSendouts()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            var captureId = "23424....234234234.....234234";
            try
            {
                klarna.OrderManagement.TriggerResendOfCustomerCommunication(orderId, captureId).RunSynchronously();
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