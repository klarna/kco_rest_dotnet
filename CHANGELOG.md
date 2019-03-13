<!-- markdownlint-disable MD024 MD036 -->

# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [3.1.1] - 2019-03-13 (Maintenance / BugFix Release)

### Changed

- Sample program made more verbose, code is better annotated and sample credentials are removed
- Better illustrate use of `CheckoutOrderOptions.AllowedCustomerTypes` in example / sample app
- Started augmenting documentation for methods

### Added

- .nuspec file to improve available metadata on nuget.org

### Fixed

- Fix up `CHANGELOG` to better reflect issues resolved by previous release
- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/27](https://github.com/klarna/kco_rest_dotnet/issues/27)
- Resolves [https://github.com/klarna/kco_rest_dotnet/issues/33](https://github.com/klarna/kco_rest_dotnet/issues/33)

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

[Unreleased]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.0...HEAD
[3.1.1]: https://github.com/klarna/kco_rest_dotnet/compare/v3.1.0...v3.1.1
[3.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v3.0.0...v3.1.0
[3.0.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.2.0...v3.0.0
[2.2.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.1.0...v2.2.0
[2.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v2.0.1...v2.1.0
[2.0.1]: https://github.com/klarna/kco_rest_dotnet/compare/v2.0.0...v2.0.1
[2.0.0]: https://github.com/klarna/kco_rest_dotnet/compare/v1.1.0...v2.0.0
[1.1.0]: https://github.com/klarna/kco_rest_dotnet/compare/v1.0.0...v1.1.0