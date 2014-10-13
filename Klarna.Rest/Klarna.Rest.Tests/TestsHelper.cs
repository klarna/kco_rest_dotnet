#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="TestsHelper.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using Klarna.Rest.Models;
    using Klarna.Rest.Models.Requests;
    using Klarna.Rest.Transport;
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Unit tests helper.
    /// </summary>
    public static class TestsHelper
    {
        /// <summary>
        /// Mock helper method.
        /// </summary>
        /// <param name="method">the HTTP method</param>
        /// <param name="url">the url</param>
        /// <param name="data">the data</param>
        /// <param name="statusCode">the status code</param>
        /// <param name="connectorMock"> the mocked connector</param>
        /// <returns>the mocked response</returns>
        public static IResponse Mock(HttpMethod method, string url, string data, HttpStatusCode statusCode, IConnector connectorMock)
        {
            HttpWebRequest requestMock = (HttpWebRequest)HttpWebRequest.Create("http://testtest.test");
            connectorMock.Stub(x => x.CreateRequest(url.ToString(), method, data)).Return(requestMock);
            IResponse responseMock = MockRepository.GenerateStub<IResponse>();
            connectorMock.Stub(x => x.Send(requestMock, data, statusCode)).Return(responseMock);

            return responseMock;
        }

        /// <summary>
        /// Assert request helper method.
        /// </summary>
        /// <param name="merchantId">the merchant id</param>
        /// <param name="secret">the secret</param>
        /// <param name="httpWebRequest">the HTTP web request</param>
        /// <param name="method">the HTTP method</param>
        public static void AssertRequest(string merchantId, string secret, HttpWebRequest httpWebRequest, HttpMethod method)
        {
            string credentials = string.Format("{0}:{1}", merchantId, secret);
            byte[] bytes = Encoding.ASCII.GetBytes(credentials);
            string base64 = Convert.ToBase64String(bytes);
            string authorization = string.Concat("basic ", base64);

            Assert.That(httpWebRequest.Method, Is.EqualTo(method.ToString().ToUpper()));
            Assert.That(httpWebRequest.UserAgent, Is.EqualTo(new UserAgent().ToString()));

            Assert.That(((NetworkCredential)httpWebRequest.Credentials).Password, Is.EqualTo(secret));
            Assert.That(((NetworkCredential)httpWebRequest.Credentials).UserName, Is.EqualTo(merchantId));
            Assert.That(httpWebRequest.ContentType, Is.EqualTo("application/json"));
            Assert.IsFalse(httpWebRequest.AllowAutoRedirect);
        }

        /// <summary>
        /// Get update customer details.
        /// </summary>
        /// <returns> a update customer details</returns>
        public static UpdateCustomerDetails GetUpdateCustomerDetails()
        {
            UpdateCustomerDetails updateCustomerDetails = new UpdateCustomerDetails()
            {
                ShippingAddress = GetAddress1(),

                BillingAddress = GetAddress2()
            };

            return updateCustomerDetails;
        }

        /// <summary>
        /// Get an address.
        /// </summary>
        /// <returns>an address</returns>
        public static Address GetAddress1()
        {
            return new Address()
            {
                GivenName = "GivenName",
                FamilyName = "FamilyName",
                StreetAddress = "PostalCode",
                PostalCode = "PostalCode",
                City = "City",
                Country = "Country",
                Email = "Email",
                Phone = "Phone"
            };
        }

        /// <summary>
        /// Get an address.
        /// </summary>
        /// <returns>an address</returns>
        public static Address GetAddress2()
        {
            return new Address()
            {
                GivenName = "GivenName2",
                FamilyName = "FamilyName2",
                StreetAddress = "PostalCode2",
                PostalCode = "PostalCode2",
                City = "City2",
                Country = "Country2",
                Email = "Email2",
                Phone = "Phone2"
            };
        }

        /// <summary>
        /// Get checkout order.
        /// </summary>
        /// <returns>a checkout order</returns>
        public static CheckoutOrderData GetCheckoutOrderData1()
        {
            CheckoutOrderData checkoutOrderData1 = new CheckoutOrderData()
            {
                PurchaseCountry = "SomeCountry",
                PurchaseCurrency = "SomeCurrency"
            };

            return checkoutOrderData1;
        }

        /// <summary>
        /// Get checkout order.
        /// </summary>
        /// <returns>a checkout order</returns>
        public static CheckoutOrderData GetCheckoutOrderData2()
        {
            CheckoutOrderData checkoutOrderData2 = new CheckoutOrderData()
            {
                PurchaseCountry = "SomeOtherCountry",
                PurchaseCurrency = "SomeOtherCurrency"
            };

            return checkoutOrderData2;
        }

        /// <summary>
        /// Get add shipping info.
        /// </summary>
        /// <returns> a shipping info</returns>
        public static AddShippingInfo GetAddShippingInfo()
        {
            ShippingInfo shippingInfo = new ShippingInfo()
            {
                ShippingCompany = "A ShippingCompany"
            };

            ShippingInfo shippingInfo2 = new ShippingInfo()
            {
                ShippingCompany = "Another ShippingCompany"
            };

            Klarna.Rest.Models.Requests.AddShippingInfo addShippingInfo = new Klarna.Rest.Models.Requests.AddShippingInfo();
            addShippingInfo.ShippingInfo = new List<ShippingInfo>() { shippingInfo };

            return addShippingInfo;
        }

        /// <summary>
        /// Get shipping info.
        /// </summary>
        /// <returns>a shipping info</returns>
        public static IList<ShippingInfo> GetShippingInfo()
        {
            ShippingInfo shippingInfo = new ShippingInfo()
            {
                ShippingCompany = "A ShippingCompany"
            };

            ShippingInfo shippingInfo2 = new ShippingInfo()
            {
                ShippingCompany = "Another ShippingCompany"
            };

            IList<ShippingInfo> list = new List<ShippingInfo>();
            list.Add(shippingInfo);
            list.Add(shippingInfo2);

            return list;
        }

        /// <summary>
        /// Get capture
        /// </summary>
        /// <returns>a capture</returns>
        public static CaptureData GetCapture()
        {
            CaptureData capture = new CaptureData()
            {
                CapturedAmount = 123,
                ShippingInfo = GetShippingInfo()
            };

            return capture;
        }

        /// <summary>
        /// Get order.
        /// </summary>
        /// <returns>a order</returns>
        public static OrderData GetOrderData()
        {
            OrderData order = new OrderData()
            {
                PurchaseCountry = "SomeOtherCountry",
                PurchaseCurrency = "SomeOtherCurrency"
            };

            return order;
        }

        /// <summary>
        /// Get refund.
        /// </summary>
        /// <returns>a refund</returns>
        public static Refund GetRefund()
        {
            Refund refund = new Refund()
            {
                RefundedAmount = 111,
                Description = "Some description"
            };

            return refund;
        }

        /// <summary>
        /// Get update merchant references.
        /// </summary>
        /// <returns>a update merchant references</returns>
        public static UpdateMerchantReferences GetUpdateMerchantReferences()
        {
            UpdateMerchantReferences updateMerchantReferences = new UpdateMerchantReferences()
            {
                MerchantReference1 = "MerchantReference1",
                MerchantReference2 = "MerchantReference2"
            };

            return updateMerchantReferences;
        }

        /// <summary>
        /// Get update authorization.
        /// </summary>
        /// <returns>a update authorization</returns>
        public static UpdateAuthorization GetUpdateAuthorization()
        {
            UpdateAuthorization updateAuthorization = new UpdateAuthorization()
            {
                OrderAmount = 111,
                Description = "A description"
            };

            return updateAuthorization;
        }
    }
}
