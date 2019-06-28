using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Client = Klarna.Rest.Core.Klarna;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;

namespace KlarnaCheckoutWebApp.Controllers
{
    public class HomeController : Controller
    {
        // Set your credentials and point to an API environment
        // Remember to set $MERCHANT_ID$ and $PASSWORD$ to your account's values
        // More about authentication here https://developers.klarna.com/api/#authentication
        String _username = "%USERNAME%";
        String _password = "%PASSWORD";

        private List<string> logs = new List<string>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KcoCart()
        {
            return View();
        }

        public ActionResult Kco()
        {
            AddLogs("Creating Klarna API Client");
            var client = new Client(_username, _password, KlarnaEnvironment.TestingEurope);

            AddLogs("Prepare an order by constructing its body");
            var order = new CheckoutOrder
            {
                PurchaseCountry = "gb",
                PurchaseCurrency = "gbp",
                Locale = "en-gb",
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
                        TotalDiscountAmount = 0,
                    }
                }
            };

            AddLogs("Proceed with operating against the Klarna Checkout API");
            try
            {
                AddLogs("Sending a request to Klarna API server");
                var createdOrder = client.Checkout.CreateOrder(order).Result;
                
                AddLogs("Getting the HTML snippet code ");
                ViewBag.HTMLSnippet = createdOrder.HtmlSnippet;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions) {
                    if (e is ApiException)
                    {
                        var apiException = (ApiException) e;
                        ViewBag.Error = "Status code: " + apiException.StatusCode + "; Error: " 
                                        + string.Join("; ", apiException.ErrorMessage.ErrorMessages);
                        AddLogs($"Error happened {ViewBag.Error}");
                    }
                    else {
                        ViewBag.Error = e.Message;
                        AddLogs($"Error happened {ViewBag.Error}");
                    }
                }
            }
            
            ViewBag.Logs = GetLogs().ToArray();
            AddLogs("Render the page template");
            
            return View();
        }

        public ActionResult Kp()
        {
            var client = new Client(_username, _password, KlarnaEnvironment.TestingEurope);
            try
            {
                var paymentSession = new PaymentCreditSession
                {
                    PurchaseCountry = "GB",
                    PurchaseCurrency = "GBP",
                    Locale = "en-GB",
                    OrderAmount = 10000,
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
                        ColorButton ="#000000"
                    },
                    BillingAddress = new PaymentAddressInfo
                    {
                         GivenName ="John",
                         FamilyName ="Doe",
                         StreetAddress ="13 New Burlington St",
                         PostalCode = "W13 3BG",
                         Country ="GB",
                         Email ="john.doe@example.com",
                         City="London",
                         Phone ="01895808221"
                    }
                };
                var creditSession = client.Payment.CreateCreditSession(paymentSession).Result;
                ViewBag.ClientToken = creditSession.ClientToken;
                ViewBag.Payments = creditSession.PaymentMethodCategories;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions) {
                    if (e is ApiException)
                    {
                        var apiException = (ApiException) e;
                        ViewBag.Error = "Status code: " + apiException.StatusCode + "; Error: " 
                                        + string.Join("; ", apiException.ErrorMessage.ErrorMessages);
                    }
                    else {
                        ViewBag.Error = e.Message;
                    }
                }
            }

            return View();
        }
        
        public ActionResult KpApprove()
        {
            var token = Request.Form["authorization_token"];
            // Now we have an authorization token and can create an order
            
            // var client = new Client(_username, _password, KlarnaEnvironment.TestingEurope);
            // client.Payment.CreateOrder()
            // ...
            
            return View("KpThankYou");
        }

        private void AddLogs(string line)
        {
            var date = DateTime.Now.ToString("HH:mm:ss.fff");
            logs.Add($"[{date}] {line}");
        }

        private List<string> GetLogs()
        {
            return logs;
        }
    }
}