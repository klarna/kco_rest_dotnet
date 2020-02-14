<!-- markdownlint-disable MD024 MD036 -->

# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed

### Added

### Fixed



## [3.1.12] - 2020-02-14

### Changed

- Rolled back previous model changes. Remove obsolescence notices.

### Added

- HTTP Transport: Oceania Base URLs (playground and production)


## [3.1.10] (Enhancements Release/Auto-generated models) - 2019-12-10

⚠️ This version is marked as **broken/deprecated**. Consider to use v3.1.12 instead.

This release contains fully updated API models. All the models were split by appropriate API entitities
and all the models are auto-generated now. This change simplifies keeping up-to-date changes in the API 
request/response.

> Note: all the models from the Model namespace are marked as obsolete and will be removed in future releases

### Added

- New auto-generated models and Store support of these models **Full backward compatibility**:
  - Checkout API
  - Customer Token API
  - Merchant Card Services API
  - Order Management API
  - Payments API
  - Settlements API
- Add support of the latest [2019-12-10] API features

### Fixed

- Fixed Sample application namespaces. Use non-obsolete Communication namespace.



## [3.1.9] (Enhancements Release) - 2019-11-14

### Added

- Hosted Payment Pages: Add support of session disabling


## [3.1.8] (Enhancements/Bugfix Release)

### Changed

- Generated HPP models and put them in a new namespace Klarna.Rest.Core.Model.HostedPaymentPage. Generated models have all fields in the API
and fixes [#77](https://github.com/klarna/kco_rest_dotnet/issues/77)

### Added

- Overloaded HostedPaymentPageStore methods to use new HPP models.

### Fixed

- Fixes the GET endpoint for sessions to be `/hpp/v1/sessions/{sessionid}` instead of `/hpp/v1/sessions/{session}/status`. Fixes [#78](https://github.com/klarna/kco_rest_dotnet/issues/78)


## [3.1.7] (BugFix Release)

### Fixed

- HostedPaymentPage distribute session method did not send a body payout. Resolves [#72](https://github.com/klarna/kco_rest_dotnet/issues/72);
- Fix the authorization_token property for the HostedPaymentPageSessionStatus model. Actualize model. Resolves [#73](https://github.com/klarna/kco_rest_dotnet/issues/73)


## [3.1.6.1] - 2019-10-16 (Enhancements)

### Changed

- nuspec file now has all the SDK dependencies


## [3.1.5] - 2019-10-15 (Enhancements / BugFix Release)

### Changed

- Refactoring: Fix typo in Communication namespace. Commuication -> Communication.
  Throw the ApiException from the old namespace in order to keep the backward compatibility.
  [Typo in Klarna.Rest/Klarna.Rest.Core/Commuication namespace #70](https://github.com/klarna/kco_rest_dotnet/issues/70)

### Added

- Add ability to set an HTTP proxy. [Allow usage of WebProxy in HttpClient #66](https://github.com/klarna/kco_rest_dotnet/issues/66)

### Fixed

- Fix typos in Settlements models. [Typo in SettlementsGetAllPayoutsResponse.cs "Paginatinon" #64](https://github.com/klarna/kco_rest_dotnet/issues/64)


## [3.1.4] - 2019-08-09 (Enhancements / BugFix Release)

### Changed

- Resolves [#57](https://github.com/klarna/kco_rest_dotnet/issues/57):
    Combine similar OrderManager Refund models into a single one.
    Add missing field to OrderManagementRefund model;
- Resolves [#55](https://github.com/klarna/kco_rest_dotnet/issues/55):
    Refactoring: Rethink async/await and add ConfigureAwait in order to avoid dead-locking.

### Added

- Sample projects:
    * Add [WebForms](https://github.com/klarna/kco_rest_dotnet/tree/v3.x/Klarna.Rest/SampleProjects/WebForms) sample app;
    * Add [WebApp MVC](https://github.com/klarna/kco_rest_dotnet/tree/v3.x/Klarna.Rest/SampleProjects/KlarnaCheckoutWebApp) sample app.

### Fixed

- Resolves [#53](https://github.com/klarna/kco_rest_dotnet/issues/53):
    Actualize the CheckoutOrder and OrderManagementOrder models;
- Resolves [#56](https://github.com/klarna/kco_rest_dotnet/issues/56):
    Order management: Fix typo in the release remaining authorization endpoint.



## [3.1.3] - 2019-05-31 (Enhancements)

### Changed

- Change the process of handling non-json errors from the API servers.
    Fix the example to show the real error processing workflow.
- Update examples files to show the real error processing workflow.

### Added

- CustomerToken API: Add support of the Status update;
- Examples: Add "How to use discounts" exmaple.


## [3.1.2] - 2019-03-29 (Enhancements / BugFix Release)

### Changed

- Change the license element in .nuspec
- Update the example domain URLs

### Added

- Resolves [#36](https://github.com/klarna/kco_rest_dotnet/issues/36):
    OrderManagement: Add method to create and fetch a Refund
- Resolves [#17](https://github.com/klarna/kco_rest_dotnet/issues/17):
    OrderManagement: Add method to create and fetch a Capture
- Communication: Add a possiblity for Store entities to get the raw response

### Fixed

- OrderManagement: Fix the Capture create method. Warning: the method signature was changed
- Resolves [#37](https://github.com/klarna/kco_rest_dotnet/issues/37):
    OrderManagementOrder model: Fix the typo in json field name. marchant_data -> merchant_data

## [3.1.1] - 2019-03-14 (Maintenance / BugFix Release)

### Changed

- Sample program made more verbose, code is better annotated and sample credentials are removed
- Better illustrate use of `CheckoutOrderOptions.AllowedCustomerTypes` in example / sample app
- Started augmenting documentation for methods

### Added

- .nuspec file to improve available metadata on nuget.org

### Fixed

- Fix up `CHANGELOG` to better reflect issues resolved by previous release
- Resolves [#27](https://github.com/klarna/kco_rest_dotnet/issues/27):
    Fix cannot send a content-body with this verb-type issue
- Resolves [#33](https://github.com/klarna/kco_rest_dotnet/issues/33):
    Checkout API: Fix missing Shipping Attributes for OrderLines Model

## [3.1.0] - 2019-03-06 (**Partial backward compatibility**)

### Changed

- Change `CreateCapture` method signature. The method returns Capture data now when creating a new capture:

    ```csharp
    - public async Task CreateCapture(string orderId, OrderManagementCreateCapture capture)
    + public async Task<OrderManagementCapture> CreateCapture(string orderId, OrderManagementCreateCapture capture)
    ```

- Refactoring: Improved HTTP Transport
- DocFX updated index page

### Added

- More examples

### Fixed

- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/8](https://github.com/klarna/kco_rest_dotnet/issues/8)
- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/15](https://github.com/klarna/kco_rest_dotnet/issues/15)
- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/18](https://github.com/klarna/kco_rest_dotnet/issues/18)
- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/19](https://github.com/klarna/kco_rest_dotnet/issues/19)
- Fixes failing tests

## [3.0.0] - 2018-12-19

> **⚠️ No backward compatibility**

### Changed

- Rewritten from scratch as a .Net Standard 2.0 class library using latest available documentation - *Benny.O*

### Added

- Supports Checkout v3, Payment v1, Order Management v1, Settlements v1, Customer Token v1, Hosted Payment Page v1, Merchant Card Service v3 - *Benny.O*
- SDK API Reference documentation now hosted on GitHub Pages: [https://klarna.github.io/kco_rest_dotnet/](https://klarna.github.io/kco_rest_dotnet/)

## [2.2.0] - 2016-02-15

### Added

- **NEW META-112** Updating MerchantUrls model for shipping_option_update, address_update & notification - *Christer.G*

## [2.1.0] - 2015-12-07

### Added

- **NEW META-13** Support 201 for refunds. - *Joakim.L*

## [2.0.1] - 2015-07-01

### Fixed

- **FIX MINT-2252** Correct model names for extra merchant data. - *Christer.G*

## [2.0.0] - 2015-06-25

### Added

- **NEW MINT-2201** Use order id instead of URL for checkout orders - *Christer.G*
- **NEW MINT-2086** Updating API error handling - *Christer.G*
- **NEW MINT-2232** Add support for checkout attachment Extra Merchant Data - *Christer.G*
- **NEW MINT-2215** Add base URIs for North America - *Christer.G*
- **NEW MINT-2246** Add support for external payment methods and checkouts - *Christer.G*

## [1.1.0] - 2015-06-16

### Added

- **NEW MINT-2061** Add support for US - *Majid.G*
- **NEW MINT-2230** Add support for gui options - *Joakim.L*

## 1.0.0 - 2014-12-03

### Added

- **NEW MINT-1912** Support checkout v3 and ordermanagement v1 APIs - *Joakim.L*

[Unreleased]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.12...HEAD
[3.1.12]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.10...v3.1.12
[3.1.10]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.9...v3.1.10
[3.1.9]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.8...v3.1.9
[3.1.8]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.7...v3.1.8
[3.1.7]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.6.1...v3.1.7
[3.1.6.1]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.5...v3.1.6.1
[3.1.5]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.4...v3.1.5
[3.1.4]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.3...v3.1.4
[3.1.3]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.2...v3.1.3
[3.1.2]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.1...v3.1.2
[3.1.1]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.0...v3.1.1
[3.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v3.0.0...v3.1.0
[3.0.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.2.0...v3.0.0
[2.2.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.1.0...v2.2.0
[2.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.0.1...v2.1.0
[2.0.1]: https://github.com/klarna/kco_rest_dotnet/compare/v2.0.0...v2.0.1
[2.0.0]: https://github.com/klarna/kco_rest_dotnet/compare/v1.1.0...v2.0.0
[1.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v1.0.0...v1.1.0