#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="CheckoutOrder.cs" company="Klarna AB">
//     Copyright 2014 Klarna AB
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------
#endregion
namespace Klarna.Rest.Examples
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Klarna.Rest.Checkout;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.EMD;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Checkout order resource examples.
    /// </summary>
    public class CheckoutOrder
    {
        #region Create

        /// <summary>
        /// Create a checkout order.
        /// </summary>
        public class CreateExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder();

                OrderLine orderLine = new OrderLine
                {
                    Type = "physical",
                    Reference = "123050",
                    Name = "Tomatoes",
                    Quantity = 10,
                    QuantityUnit = "kg",
                    UnitPrice = 600,
                    TaxRate = 2500,
                    TotalAmount = 6000,
                    TotalTaxAmount = 1200
                };

                OrderLine orderLine2 = new OrderLine
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                };

                MerchantUrls merchantUrls = new MerchantUrls
                {
                    Terms = new Uri("http://www.merchant.com/toc"),
                    Checkout = new Uri("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}"),
                    Confirmation = new Uri("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}"),
                    Push = new Uri("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}")
                };

                CheckoutOrderData orderData = new CheckoutOrderData()
                {
                    PurchaseCountry = "gb",
                    PurchaseCurrency = "gbp",
                    Locale = "en-gb",
                    OrderAmount = 10000,
                    OrderTaxAmount = 2000,
                    OrderLines = new List<OrderLine> { orderLine, orderLine2 },
                    MerchantUrls = merchantUrls
                };

                try
                {
                    checkout.Create(orderData);
                    orderData = checkout.Fetch();

                    string orderID = orderData.OrderId;
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Attachment

        /// <summary>
        /// Create a checkout order with ExtraMerchantData attachment.
        /// </summary>
        public class AttachmentExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder();

                OrderLine orderLine = new OrderLine
                {
                    Type = "physical",
                    Reference = "123050",
                    Name = "Tomatoes",
                    Quantity = 10,
                    QuantityUnit = "kg",
                    UnitPrice = 600,
                    TaxRate = 2500,
                    TotalAmount = 6000,
                    TotalTaxAmount = 1200
                };

                OrderLine orderLine2 = new OrderLine
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                };

                MerchantUrls merchantUrls = new MerchantUrls
                {
                    Terms = new Uri("http://www.merchant.com/toc"),
                    Checkout = new Uri("http://www.merchant.com/checkout?klarna_order_id={checkout.order.id}"),
                    Confirmation = new Uri("http://www.merchant.com/thank-you?klarna_order_id={checkout.order.id}"),
                    Push = new Uri("http://www.merchant.com/create_order?klarna_order_id={checkout.order.id}")
                };

                AirReservationDetails airReservationDetails = new AirReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<Itinerary>
                    {
                        new Itinerary
                        {
                            Departure = "ARN",
                            DepartureCity = "Stockholm",
                            Arrival = "LLA",
                            ArrivalCity = "Luleå",
                            Carrier = "SK",
                            SegmentPrice = 10000,
                            DepartureDate = DateTime.Now.AddDays(1),
                            TicketDeliveryMethod = "email",
                            TicketDeliveryRecipient = "test@klarna.com",
                            PassengerIDs = new List<int> { 123, 456 },
                            Class = "Business"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Passengers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                BusReservationDetails busReservationDetails = new BusReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<Itinerary>
                    {
                        new Itinerary
                        {
                            Departure = "Stockholm City",
                            DepartureCity = "Stockholm",
                            Arrival = "Umeå bstn",
                            ArrivalCity = "Umeå",
                            Carrier = "Y Buss",
                            SegmentPrice = 10000,
                            DepartureDate = DateTime.Now.AddDays(1),
                            TicketDeliveryMethod = "email",
                            TicketDeliveryRecipient = "test@klarna.com",
                            PassengerIDs = new List<int> { 123, 456 },
                            Class = "Business"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Passengers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                TrainReservationDetails trainReservationDetails = new TrainReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<Itinerary>
                    {
                        new Itinerary
                        {
                            Departure = "Stockholm Central",
                            DepartureCity = "Stockholm",
                            Arrival = "Luleå JVSTN",
                            ArrivalCity = "Luleå",
                            Carrier = "SL",
                            SegmentPrice = 10000,
                            DepartureDate = DateTime.Now.AddDays(1),
                            TicketDeliveryMethod = "email",
                            TicketDeliveryRecipient = "test@klarna.com",
                            PassengerIDs = new List<int> { 123, 456 },
                            Class = "Business"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Passengers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                FerryReservationDetails ferryReservationDetails = new FerryReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<Itinerary>
                    {
                        new Itinerary
                        {
                            Departure = "Slussen terminalen",
                            DepartureCity = "Stockholm",
                            Arrival = "Åbo",
                            ArrivalCity = "Mariehamn",
                            Carrier = "Ferry Line",
                            SegmentPrice = 10000,
                            DepartureDate = DateTime.Now.AddDays(1),
                            TicketDeliveryMethod = "email",
                            TicketDeliveryRecipient = "test@klarna.com",
                            PassengerIDs = new List<int> { 123, 456 },
                            Class = "Business"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Passengers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                HotelReservationDetails hotelReservationDetails = new HotelReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<HotelItinerary>
                    {
                        new HotelItinerary
                        {
                            Name = "Scandic",
                            Address = new Location
                            {
                                StreetAddress = "Kungsgatan 1",
                                PostalCode = "123 45",
                                City = "Stockholm",
                                Country = "Sweden"
                            },
                            StartTime = DateTime.Now.AddDays(1),
                            EndTime = DateTime.Now.AddDays(2),
                            NumberOfRooms = 10,
                            PassengerIDs = new List<int> { 123, 456 },
                            HotelPrice = 10000,
                            Class = "5 Stars"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Passengers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                CarRentalReservationDetails carRentalReservationDetails = new CarRentalReservationDetails
                {
                    PNR = "fgh383g45TEST",
                    Itineraries = new List<CarRentalItinerary>
                    {
                        new CarRentalItinerary
                        {
                            RentalCompany = "Name of rental company",
                            DriverIds = new List<int> { 123 },
                            PickUpLocation = new Location
                            {
                                StreetAddress = "Kungsgatan 1",
                                PostalCode = "123 45",
                                City = "Stockholm",
                                Country = "Sweden"
                            },
                            DropOffLocation = new Location
                            {
                                StreetAddress = "Kungsgatan 2",
                                PostalCode = "123 45",
                                City = "Stockholm",
                                Country = "Sweden"
                            },
                            StartTime = DateTime.Now,
                            EndTime = DateTime.Now.AddMinutes(1),
                            CarPrice = 10000,
                            Class = "Family"
                        }
                    },
                    Insurances = new List<Insurance>
                    {
                        new Insurance
                        {
                            InsuranceCompany = "Test Insurance AB",
                            InsuranceType = "cancellation_travel",
                            InsurancePrice = 10000
                        }
                    },
                    Drivers = new List<Person>
                    {
                        new Person
                        {
                            ID = 123123,
                            Title = "mrs",
                            FirstName = "Testperson-se",
                            LastName = "Approved"
                        }
                    },
                    AffiliateName = "Affiliate name"
                };

                Event evnt = new Event
                {
                    Name = "Event of the year",
                    Company = "Klarna",
                    Genre = "Concert",
                    ArenaName = "Friends Arena",
                    ArenaLocation = new Location
                    {
                        StreetAddress = "Arenavägen 1",
                        PostalCode = "123 45",
                        City = "Stockholm",
                        Country = "Sweden"
                    },
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(6),
                    AccessControllerVenue = true,
                    TicketDeliveryMethod = "email",
                    TicketDeliveryRecipient = "test@klarna.com",
                    AffiliateName = "Affiliate name"
                };

                Voucher voucher = new Voucher
                {
                    Name = "1 free meal",
                    Company = "McDonalds",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMonths(1),
                    AffiliateName = "Affiliate name"
                };

                Subscription subscription = new Subscription
                {
                    Name = "1 year subscription",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddYears(1),
                    AutoRenewalOfSubscriptions = true
                };

                CustomerAccountInformation customerAccountInformation = new CustomerAccountInformation
                {
                    UniqueAccountIdentifier = "0123456789",
                    AccountRegistrationDate = DateTime.Now.AddYears(-2),
                    AccountLastModified = DateTime.Now
                };

                MarketplaceSellerInformation marketplaceSellerInformation = new MarketplaceSellerInformation
                {
                    UniqueAccountIdentifier = new UniqueAccountIdentifier
                    {
                        Email = "test@klarna.com",
                        PNO = "4103219202",
                        Other = "Some other information."
                    },
                    SubMerchantID = "test",
                    ProductCategory = "clothing",
                    ProductName = "Klarna T-shirt",
                    AccountRegistrationDate = DateTime.Now.AddYears(-2),
                    AccountLastModified = new LastModifed
                    {
                        Address = DateTime.Now,
                        Email = DateTime.Now,
                        Listing = DateTime.Now,
                        Login = DateTime.Now,
                        Password = DateTime.Now
                    },
                    SellerRating = 46,
                    NumberOfTrades = 12,
                    VolumeOfTrades = 10
                };

                MarketplaceWinnerInformation marketplaceWinnerInformation = new MarketplaceWinnerInformation
                {
                    UniqueAccountIdentifier = new UniqueAccountIdentifier
                    {
                        Email = "test@klarna.com",
                        PNO = "4103219202",
                        Other = "Some other information."
                    },
                    AccountRegistrationDate = DateTime.Now.AddYears(-2),
                    AccountLastModified = new LastModifed
                    {
                        Address = DateTime.Now,
                        Email = DateTime.Now,
                        Listing = DateTime.Now,
                        Login = DateTime.Now,
                        Password = DateTime.Now
                    },
                    NumberOfTrades = 12,
                    VolumeOfTrades = 10
                };

                PurchaseHistoryFull purchaseHistoryFull = new PurchaseHistoryFull
                {
                    UniqueAccountIdentifier = "Test Testperson",
                    PaymentOption = "card",
                    NumberPaidPurchases = 7,
                    TotalAmountPaidPurchases = 50099,
                    DateOfFirstPaidPurchase = DateTime.Now.AddDays(-1),
                    DateOfLastPaidPurchase = DateTime.Now
                };

                PurchaseHistorySimple purchaseHistorySimple = new PurchaseHistorySimple
                {
                    UniqueAccountIdentifier = "Test Testperson",
                    PaidBefore = true
                };

                OtherDeliveryAddress otherDeliveryAddress = new OtherDeliveryAddress
                {
                    ShippingMethod = "pick-up point",
                    ShippingType = "normal",
                    FirstName = "Test",
                    LastName = "Testperson",
                    StreetAddress = "Kungsgatan 1",
                    PostalCode = "123 45",
                    City = "Stockholm",
                    Country = "Sweden"
                };

                ExtraMerchantData extraMerchantData = new ExtraMerchantData
                {
                    Body = new ExtraMerchantDataBody
                    {
                        AirReservationDetails = new List<AirReservationDetails>
                        {
                            airReservationDetails
                        },
                        BusReservationDetails = new List<BusReservationDetails>
                        {
                            busReservationDetails
                        },
                        TrainReservationDetails = new List<TrainReservationDetails>
                        {
                            trainReservationDetails
                        },
                        FerryReservationDetails = new List<FerryReservationDetails>
                        {
                            ferryReservationDetails
                        },
                        HotelReservationDetails = new List<HotelReservationDetails>
                        {
                            hotelReservationDetails
                        },
                        CarRentalReservationDetails = new List<CarRentalReservationDetails>
                        {
                            carRentalReservationDetails
                        },
                        Events = new List<Event>
                        {
                            evnt
                        },
                        Vouchers = new List<Voucher>
                        {
                            voucher
                        },
                        Subscriptions = new List<Subscription>
                        {
                            subscription
                        },
                        CustomerAccountInfo = new List<CustomerAccountInformation>
                        {
                            customerAccountInformation
                        },
                        MarketplaceSellerInformation = new List<MarketplaceSellerInformation>
                        {
                            marketplaceSellerInformation
                        },
                        MarketplaceWinnerInformation = new List<MarketplaceWinnerInformation>
                        {
                            marketplaceWinnerInformation
                        },
                        PurchaseHistoryFull = new List<PurchaseHistoryFull>
                        {
                            purchaseHistoryFull
                        },
                        PurchaseHistorySimple = new List<PurchaseHistorySimple>
                        {
                            purchaseHistorySimple
                        },
                        OtherDeliveryAddresses = new List<OtherDeliveryAddress>
                        {
                            otherDeliveryAddress
                        }
                    }
                };

                CheckoutOrderData orderData = new CheckoutOrderData()
                {
                    PurchaseCountry = "gb",
                    PurchaseCurrency = "gbp",
                    Locale = "en-gb",
                    OrderAmount = 10000,
                    OrderTaxAmount = 2000,
                    OrderLines = new List<OrderLine> { orderLine, orderLine2 },
                    MerchantUrls = merchantUrls,
                    Attachment = extraMerchantData
                };

                try
                {
                    checkout.Create(orderData);
                    orderData = checkout.Fetch();

                    string orderID = orderData.OrderId;
                    ExtraMerchantData emd = orderData.Attachment;
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Fetch

        /// <summary>
        /// Retrieve a checkout order.
        /// </summary>
        public class FetchExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderID = "12345";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder order = client.NewCheckoutOrder(orderID);

                try
                {
                    CheckoutOrderData orderData = order.Fetch();
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion

        #region Update

        /// <summary>
        /// Update a checkout order.
        /// </summary>
        public class UpdateExample
        {
            /// <summary>
            /// Run the example code.
            /// </summary>
            public static void Main()
            {
                const string MerchantId = "0";
                const string SharedSecret = "sharedSecret";
                string orderID = "12345";

                IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, Client.TestBaseUrl);

                Client client = new Client(connector);
                ICheckoutOrder checkout = client.NewCheckoutOrder(orderID);

                CheckoutOrderData orderData = new CheckoutOrderData();
                orderData.OrderAmount = 11000;
                orderData.OrderTaxAmount = 2200;

                List<OrderLine> lines = new List<OrderLine>();

                lines.Add(new OrderLine()
                {
                    Type = "physical",
                    Reference = "123050",
                    Name = "Tomatoes",
                    Quantity = 10,
                    QuantityUnit = "kg",
                    UnitPrice = 600,
                    TaxRate = 2500,
                    TotalAmount = 6000,
                    TotalTaxAmount = 1200
                });

                lines.Add(new OrderLine()
                {
                    Type = "physical",
                    Reference = "543670",
                    Name = "Bananas",
                    Quantity = 1,
                    QuantityUnit = "bag",
                    UnitPrice = 5000,
                    TaxRate = 2500,
                    TotalAmount = 4000,
                    TotalDiscountAmount = 1000,
                    TotalTaxAmount = 800
                });

                lines.Add(new OrderLine()
                {
                    Type = "shipping_fee",
                    Name = "Express delivery",
                    Quantity = 1,
                    UnitPrice = 1000,
                    TaxRate = 2500,
                    TotalAmount = 1000,
                    TotalTaxAmount = 200
                });

                orderData.OrderLines = lines;

                try
                {
                    orderData = checkout.Update(orderData);
                }
                catch (ApiException ex)
                {
                    Console.WriteLine(ex.ErrorMessage.ErrorCode);
                    Console.WriteLine(ex.ErrorMessage.ErrorMessages);
                    Console.WriteLine(ex.ErrorMessage.CorrelationId);
                }
                catch (WebException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        #endregion
    }
}
