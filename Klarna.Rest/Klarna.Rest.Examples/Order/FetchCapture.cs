#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="FetchCapture.cs" company="Klarna AB">
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
namespace Klarna.Rest.Examples.Order
{
    using Klarna.Rest.Models;
    using Klarna.Rest.Transport;

    /// <summary>
    /// Retrieve a capture.
    /// </summary>
    public class FetchCapture
    {
        /// <summary>
        /// Example of how to retrieve a capture.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";
            string captureId = "34567";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            Klarna.Rest.OrderManagement.Capture capture = order.FetchCapture(captureId);

            CaptureData captureData = capture.Fetch();
        }
    }
}
