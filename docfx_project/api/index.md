# Klarna Checkout REST.Core .NET SDK
[![NuGet Version][nuget-shield]](https://www.nuget.org/packages/Klarna.Rest.Core/)

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

### Prerequisites
* Microsoft .NET Framework 4 or above
* [API credentials](#api-credentials)


### API Credentials

Before getting a production account you can get a playground one.
Register here to be able to test your SDK integration before go live:

- https://playground.eu.portal.klarna.com/developer-sign-up - for EU countries
- https://playground.us.portal.klarna.com/developer-sign-up - for the US

Later you need to register as a Klarna merchant to get a production credentials

- https://developers.klarna.com/en/gb/kco-v3


## Installation and Usage

Example files can be found in the [examples](Klarna.Rest/Klarna.Rest.Core.Examples) project.

### Package Manager

To install .NET SDK for Klarna, run the following command in the Package Manager Console:

```
PM> Install-Package Klarna.Rest.Core -Version x.y.z
```

### .NET CLI

```
> dotnet add package Klarna.Rest.Core --version x.y.z
```

### Paket CLI

```
paket add Klarna.Rest.Core --version x.y.z

```
### Usage

Check the https://www.nuget.org/packages/Klarna.Rest.Core/ to get information about the latest version.



## Documentation
Klarna API documentation: https://developers.klarna.com/api/  
SDK References: https://klarna.github.io/kco_rest_dotnet/


Example files can be found in the [Klarna.Rest/Klarna.Rest.Core.Examples/](examples) project.
Additional documentation can be found at https://developers.klarna.com.


## Questions and feedback
If you have any questions concerning this product or the implementation,
please create an issue: https://github.com/klarna/kco_rest_dotnet/issues/new/choose

Use an official Klarna Contact us form (https://klarna.com) if you have a question about the integration.


## How to contribute
At Klarna, we strive toward achieving the highest possible quality for our
products. Therefore, we require you to follow these guidelines if you wish
to contribute.

To contribute, the following criteria needs to be fulfilled:
* Description regarding what has been changed and why
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
Klarna Checkout REST .NET SDK is licensed under
[Apache License, Version 2.0](http://www.apache.org/LICENSE-2.0)

[nuget-shield]: https://img.shields.io/nuget/v/Klarna.Rest.Core.svg?style=flat
