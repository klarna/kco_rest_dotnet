using System;
using System.Collections.Generic;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Communication;
using Klarna.Rest.Core.Model.Enum;
using Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Examples
{
    class PaymentApi
    {
        public void CreateSession()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            try
            {
                var paymentSession = new PaymentCreditSession
                {
                    PurchaseCountry = "SE",
                    PurchaseCurrency = "SEK",
                    Locale = "sv-se",
                    OrderAmount = 1000,
                    OrderTaxAmount = 2000,
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
                    MerchantReference1 ="StoreOrderId",
                    Options = new PaymentOptions{
                        ColorButton ="000000"
                    },
                    BillingAddress = new PaymentAddressInfo
                    {
                        GivenName ="John",
                        FamilyName ="Doe",
                        StreetAddress ="Sveavägen 46",
                        PostalCode = "103 69",
                        Country ="SE",
                         Email ="Youremail@test.com",
                         City="Stockholm",
                         Phone ="+46752242244"
                    }
                };
                var creditSession = klarna.Payment.CreateCreditSession(paymentSession).Result;
                Console.WriteLine("Client Token: "+creditSession.ClientToken);
                Console.WriteLine("Session ID: "+creditSession.SessionId);
                Console.WriteLine("The following categories are avaliable");
                foreach(PaymentMethodCategory category in creditSession.PaymentMethodCategories)
                {
                    Console.WriteLine("Name: "+category.Name);
                    Console.WriteLine("Assets Url: "+category.AssetUrls);
                    Console.WriteLine("Unique Identifier: "+category.Identifier);
                }

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
        /// Reads the session.
        /// </summary>
        public void ReadSession()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var sessionId = "234534...345345....345";
            try
            {
                var session = klarna.Payment.GetCreditSession(sessionId).Result;
                Console.WriteLine("Client Token: " + session.ClientToken);
                var billingInfo = session.BillingAddress;
                var orderslines = session.OrderLines;

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
        /// Deletes the authorization.
        /// </summary>
        public void DeleteAuthorization()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var authorizationToken = "234534...345345....345";
            try
            {
                klarna.Payment.CancelAuthorization(authorizationToken).RunSynchronously();


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
        public void CreateConsumerToken()
        {
            var username = "0_abc";
            var password = "sharedsecret";

            var klarna = new Klarna(username, password, KlarnaEnvironment.TestingEurope);
            var authorization_token = "234534...345345....345";
            var consumertokenreqest = new PaymentGenerateConsumerTokenRequest {
                BillingAddress = new PaymentAddressInfo {
                    GivenName = "John",
                    FamilyName = "Doe",
                    StreetAddress = "Sveavägen 46",
                    PostalCode = "103 69",
                    Country = "SE",
                    Email = "Youremail@test.com",
                    City = "Stockholm",
                    Phone = "+46752242244"
                }
            };

            try
            {
                var consumertoken = klarna.Payment.GenerateConsumerToken(authorization_token, consumertokenreqest).Result;
                Console.WriteLine("Consumer Token ID: " + consumertoken.TokenId);

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
