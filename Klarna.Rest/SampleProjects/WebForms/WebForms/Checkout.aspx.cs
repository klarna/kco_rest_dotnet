using System;
using System.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

// The code uses relative links to the .NET SDK project
// Check the WebForms.csproj file
// <ProjectReference Include="..\..\..\Klarna.Rest.Core\Klarna.Rest.Core.csproj" />

// The relative reference will not allow Visual Studio to recognize the "Klarna" namespace in editor,
// but the code will be compiled and run with no problems.

// Replace the relative link with the NuGet package "Klarna.Rest.Core" in order to allow Visual Studio gets
// the Klarna namespace reference.
using Client = Klarna.Rest.Core.Klarna;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;

namespace WebForms
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs args)
        {
            PutHTMLLogs("Page is loading...");
            // Set your credentials and point to an API environment
            // Remember to set $MERCHANT_ID$ and $PASSWORD$ to your account's values
            // More about authentication here https://developers.klarna.com/api/#authentication
            var username = "$MERCHANT_ID$";
            var password = "$PASSWORD$";

            PutHTMLLogs("Creating Klarna API Client");
            var client = new Client(username, password, KlarnaEnvironment.TestingEurope);

            PutHTMLLogs("Prepare an order by constructing its body");
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
                        Name = "Tomatoes",
                        Quantity = 10,
                        QuantityUnit = "kg",
                        UnitPrice = 600,
                        TaxRate = 2500,
                        TotalAmount = 6000,
                        TotalTaxAmount = 1200,
                        TotalDiscountAmount = 0,
                    },
                    new OrderLine
                    {
                        Type = OrderLineType.physical,
                        Name = "Bananas",
                        Quantity = 1,
                        QuantityUnit = "bag",
                        UnitPrice = 5000,
                        TaxRate = 2500,
                        TotalAmount = 4000,
                        TotalTaxAmount = 800,
                        TotalDiscountAmount = 1000
                    }
                }
            };

            PutHTMLLogs("Proceed with operating against the Klarna Checkout API");
            try
            {
                PutHTMLLogs("Sending a request to Klarna API server");
                // Due to the Web Forms limitations we cannot use Task.Result in the Main thread
                // https://blogs.msdn.microsoft.com/jpsanders/2017/08/28/asp-net-do-not-use-task-result-in-main-context/
                Task<CheckoutOrder> callTask = Task.Run(() => client.Checkout.CreateOrder(order));

                PutHTMLLogs("Waiting for the result");
                callTask.Wait();

                PutHTMLLogs("Show the HTML snippet code to the customer");
                HTMLSnippet.InnerHtml = callTask.Result.HtmlSnippet;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    if (e is ApiException)
                    {
                        var apiException = (ApiException) e;
                        var error = "Status code: " + apiException.StatusCode;
                        var exceptionMessage = string.Join("; ", apiException.ErrorMessage.ErrorMessages);
                        Console.WriteLine(error, exceptionMessage);
                        PutHTMLLogs($"An Error occured: {error}");
                        HTMLSnippet.InnerHtml = exceptionMessage;
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                        PutHTMLLogs($"An Error occured: {e.Message}");
                    }
                }
            }
        }

        protected void PutHTMLLogs(string line)
        {
            var date = DateTime.Now.ToString("HH:mm:ss.fff");
            logs.InnerHtml = logs.InnerHtml + $"<pre>[{date}] {HttpUtility.HtmlEncode(line)}</pre>";
        }
    }
}
