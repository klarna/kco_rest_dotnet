# Official Klarna .NET Core SDK

[![NuGet Version][nuget-shield]](https://www.nuget.org/packages/Klarna.Rest.Core/)
[![Build Status][travis-image]](https://travis-ci.org/klarna/kco_rest_dotnet)
[![Coverage Status][coveralls-image]](https://coveralls.io/r/klarna/kco_rest_dotnet?branch=v3.x)

## Welcome to Klarna. Smoooth payments.

### Klarna Checkout

A full checkout experience embedded on your site. It lets your customers check out on your
site with only their email and ZIP, and pay with the major payment methods including the specific
Klarna payment methods. All available in one integration.

### Klarna Payments

Klarna offers three payment methods. Pay now, Pay later and Slice it. It offers your consumers
to try before they buy, finance purchases on your store, or make use of other payment
options made available by Klarna.

## Get started

The Klarna .NET Core SDK covers all of Klarna APIs under: [https://developers.klarna.com/api/](https://developers.klarna.com/api/)

### Prerequisites

* Microsoft .NET Framework 4 or above
* [API credentials](#api-credentials)

### API Credentials

Before getting a production account you can get a playground one.
Register here to be able to test your SDK integration before go live:

* [https://playground.eu.portal.klarna.com/developer-sign-up](https://playground.eu.portal.klarna.com/developer-sign-up) - for EU countries
* [https://playground.us.portal.klarna.com/developer-sign-up](https://playground.eu.portal.klarna.com/developer-sign-up) - for the US

## Installation and Usage

### Examples

Example files can be found in the [examples](Klarna.Rest/Klarna.Rest.Core.Examples) project.    

### Sample Apps

Also you can check for the [Sample projects](Klarna.Rest/SampleProjects):

- [Sample](Klarna.Rest/SampleProjects/Sample)
    Simple projects for demonstrating a backend API call
- [WebApp MVC](Klarna.Rest/SampleProjects/KlarnaCheckoutWebApp)
    MVC project for demonstrating Klarna Checkout and Klarna Payment
- [WebForms](Klarna.Rest/SampleProjects/WebForms)
    WebForms project with Klarna Checkout integrated

### Installation with Package Manager

To install the Klarna .NET Core SDK, run the following command in the *Package Manager Console*:

```bash
PM> Install-Package Klarna.Rest.Core -Version x.y.z
```

### .NET CLI

```bash
dotnet add package Klarna.Rest.Core --version x.y.z
```

### Paket CLI

```bash
paket add Klarna.Rest.Core --version x.y.z
```

### Usage

Check the [https://www.nuget.org/packages/Klarna.Rest.Core/](https://www.nuget.org/packages/Klarna.Rest.Core/) to get information about the latest version.

## Documentation

Klarna API documentation: [https://developers.klarna.com/api/](https://developers.klarna.com/api/)  
SDK References: [https://klarna.github.io/kco_rest_dotnet/](https://klarna.github.io/kco_rest_dotnet/)

Example files can be found in the [Klarna.Rest/Klarna.Rest.Core.Examples/](examples) project.  
Additional documentation can be found at [https://developers.klarna.com](https://developers.klarna.com).

## Questions and feedback

If you have any questions concerning this product or the implementation,
please create an issue: [https://github.com/klarna/kco_rest_dotnet/issues/new/choose](https://github.com/klarna/kco_rest_dotnet/issues/new/choose)  

or use the Contact Us form at [https://klarna.com](https://klarna.com) website.

## How to contribute

At Klarna, we strive toward achieving the highest possible quality for our
products. Therefore, we require you to follow these guidelines if you wish
to contribute.

To contribute, the following criteria need to be fulfilled:

* Provide a description of what has been changed and why
* Pull requests should implement a boxed change
* All code and documentation must follow the style specified by
  the [StyleCop](http://stylecop.codeplex.com/) standard.
* New features and bug fixes must have accompanying unit tests:
  * Positive tests
  * Negative tests
  * Boundary tests (if possible)
  * No less than 90% decision coverage
* All unit tests should pass

## License

The Klarna .NET Core SDK is licensed under
[Apache License, Version 2.0](http://www.apache.org/LICENSE-2.0)

[nuget-shield]: https://img.shields.io/nuget/v/Klarna.Rest.Core.svg?style=flat
[travis-image]: https://img.shields.io/travis/klarna/kco_rest_dotnet/v3.x.svg?style=flat
[coveralls-image]: https://img.shields.io/coveralls/klarna/kco_rest_dotnet/v3.x.svg?style=flat
