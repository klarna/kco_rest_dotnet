# Klarna REST Java SDK
[![Maven Version][maven-image]](https://search.maven.org/search?q=a:kco-rest)
[![Build Status][travis-image]](https://travis-ci.org/klarna/kco_rest_java)
[![Coverage Status][coveralls-image]](https://coveralls.io/r/klarna/kco_rest_java)

## Welcome to Klarna. Smoooth payments.

### Klarna Checkout
A full checkout experience embedded on your site. It lets your customers check out on your
site with only their email and ZIP, and pay with the major payment methods including the specific
Klarna payment methods. All available in one integration.

### Klarna Payments
Klarna offers three payment methods. Pay now, Pay later and Slice it. It offers your consumers
to try before they buy, finance purchases on your store, or make use of other payment
options made available by Klarna.


## Installing the Java SDK

### Maven
To install the Java SDK from the Central Maven repository using Maven, add the following lines to `pom.xml`:

```xml
<dependency>
    <groupId>com.klarna</groupId>
    <artifactId>kco-rest</artifactId>
    <version>[3.0,)</version>
</dependency>
```

### Gradle

To install the Java SDK from the Central Maven repository using Gradle, add the following lines to `build.gradle`:

```
dependencies {
    compile group: 'com.klarna', name: 'kco-rest', version:'3.0+'
}
```

## Documentation
The various documentation is available:

* The [Developers Portal](https://developers.klarna.com);
* The [Klarna API documentation](https://developers.klarna.com/api);
* The [SDK references](https://klarna.github.io/kco_rest_java/);

## Usage

Example files can be found in the
[examples](src/main/java/examples/) package.

The basic workflow is the following:
1) Create a transport (SDK has a default one, but you can implement your own);
2) Use API you want to via created Transport.

```java
HttpUrlConnectionTransport transport = new HttpUrlConnectionTransport(
        "merchantId", "sharedSecret", Transport.EU_BASE_URL);
OrdersApi ordersApi = new OrdersApi(transport);

try {
    Order order = ordersApi.fetch("checkoutOrderID-123");
    System.out.println(order);

} catch (IOException | ProtocolException | ContentTypeException e) {
    System.out.println("Connection problem: " + e.getMessage());
} catch (ApiException e) {
    System.out.println("API issue: " + e.getMessage());
}
```

## Logging

The Java SDK uses slf4j library as an abstraction for various logging frameworks. We have not provided 
any back-end implementation.
Choose an implementation that applies to your project.

For more information, see the [slf4j](https://www.slf4j.org/) documentation.


## How to contribute

At Klarna, we strive toward achieving the highest possible quality for our
products. Therefore, we require you to follow these guidelines if you wish
to contribute.

To contribute, the following criteria needs to be fulfilled:
* Description regarding what has been changed and why
* Pull requests should implement a boxed change
* All code and documentation must follow the style specified by
  the included configuration (src/checkstyle.xml)
* New features and bug fixes must have accompanying unit tests:
    * Positive tests
    * Negative tests
    * Boundary tests (if possible)
    * No less than 90% decision coverage
* All unit tests should pass


## Questions and feedback

If you have any questions concerning this product,
please contact [developers@klarna.com](mailto:developers@klarna.com).


## License

The Klarna Checkout REST Java SDK is released under
[Apache License, Version 2.0](http://www.apache.org/LICENSE-2.0)

[maven-image]: https://img.shields.io/maven-central/v/com.klarna/kco-rest.svg?style=flat
[travis-image]: https://img.shields.io/travis/klarna/kco_rest_java/v2.2.svg?style=flat
[coveralls-image]: https://img.shields.io/coveralls/klarna/kco_rest_java/v2.2.svg?style=flat
