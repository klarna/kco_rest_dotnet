ASP.NET [Web Forms](https://dotnet.microsoft.com/apps/aspnet/web-forms) Sample Project
=============================================

The ASP.NET Web Forms sample project demonstrates the simple use case "How to generate the Klarna Checkout"

## Run Project

Use IIS server or Visual Studio to run the Solution.  

**Note**: Follow the [Microsoft guideline](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/introduction-and-overview)
about Building and Runing the project

The project servers http://localhost:8080 port by default.

## Special case

Due to the Web Forms limitations be careful with using Task.Result in the Main thread:
https://blogs.msdn.microsoft.com/jpsanders/2017/08/28/asp-net-do-not-use-task-result-in-main-context/

The .NET.Core SDK uses async Tasks by default, so you need to create a new Task in order to avoid dead locking:
Check the example: [Checkout.aspx.cs](WebForms/Checkout.aspx/Checkout.aspx.cs)

## Demo and Results

All the steps in the [Checkout.aspx.cs](WebForms/Checkout.aspx.cs) are covered by comments and
logs. Check the source code and use your browser to render the HTML Snippet.

![](sample1.png) 
![](sample2.png)

