ASP.NET [MVC Web App](https://dotnet.microsoft.com/apps/aspnet/mvc) Sample Project
==================================================================================

The ASP.NET MVC sample project demonstrates how to work with the Klarna Checkout and Klarna Payments.

## Run Project

Use IIS server or Visual Studio to run the Solution.  

**Note**: Follow the [Microsoft guideline](https://docs.microsoft.com/en-us/visualstudio/ide/quickstart-aspnet-core?view=vs-2019)
to build and run the project.

The project serves http://localhost:5000 port by default.

### Project Credentials

You need to change the credentials (username and password) in the `HomeController.cs` file to be able to
get the Checkout snippet and render the Payment form. 

## Demo and Results

After running the project you will find two example flows: **Klarna Checkout** and **Klarna Payment**.
Click the "See example" button to see the demo page.

![](asp.net_mvc.png)
--------------------
![](kp_demo.png)
