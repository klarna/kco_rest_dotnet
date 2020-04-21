# [DEPRECATED] Official Klarna .NET Core SDK

[![NuGet Version][nuget-shield]](https://www.nuget.org/packages/Klarna.Rest.Core/)
[![Build Status][travis-image]](https://travis-ci.org/klarna/kco_rest_dotnet)
[![Coverage Status][coveralls-image]](https://coveralls.io/r/klarna/kco_rest_dotnet?branch=v3.x)

## SDK Deprecation Warning and Sunsetting

Dear community, the SDK you are currently looking at is now deprecated. These are details related to sunsetting:
* We intend to archive this repo on June 1 2020 (01/06/20)
* Until November 1 2020 (01/11/20) high severity security issues found within the latest published version will be fixed. All support will cease after this date.
* No new builds will follow effective April 20 (20/04/2020) apart from the fixes mentioned above.

### Workarounds

We are making Klarna REST API definition files available in [Swagger / OAS v2](https://swagger.io/specification/v2/) format, under the [Klarna API Reference](https://developers.klarna.com/api/) section on the [Klarna Developer Portal](https://developers.klarna.com/). These will be regularly updated as the APIs evolve.
You can use tools like https://swagger.io/tools/swagger-codegen/ to generate your own SDKs, client libraries, etc.

## Shop now. Pay later.

Shop at your favorite stores today and experience the freedom to pay later with Klarna.

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

### Important Notices

⚠️ v3.1.10 is marked as **broken/deprecated**. Consider to use v3.1.12 instead.

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
