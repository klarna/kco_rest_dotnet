using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
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

                var result = klarna.OrderManagement.AcknowledgeOrder(orderId);
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
                var CaptureId = klarna.OrderManagement.CreateCapture(orderId, captureData);

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
        public void CancelOrder()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var orderId = "abc-abcdefg-abc";
            try
            {
                var result = klarna.OrderManagement.CancelOrder(orderId);
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