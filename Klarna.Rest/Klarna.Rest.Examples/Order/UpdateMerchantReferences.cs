#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UpdateMerchantReferences.cs" company="Klarna AB">
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
    using Klarna.Rest.Transport;

    /// <summary>
    /// Update one or both merchant references. 
    /// Only the reference(s) in the body will be updated. To clear a reference, set its value to "" (empty string).
    /// </summary>
    public class UpdateMerchantReferences
    {
        /// <summary>
        /// Example of how to update merchant references.
        /// </summary>
        public void Example()
        {
            const string MerchantId = "0";
            const string SharedSecret = "sharedSecret";
            string orderId = "12345";

            IConnector connector = ConnectorFactory.Create(MerchantId, SharedSecret, ConnectorFactory.TestBaseUrl);

            Klarna.Rest.OrderManagement.Order order = new Klarna.Rest.OrderManagement.Order(connector, orderId);

            order.UpdateMerchantReferences(GetUpdateMerchantReferences());
        }

        /// <summary>
        /// Get update merchant references.
        /// </summary>
        /// <returns>a update merchant references</returns>
        private static Klarna.Rest.Models.Requests.UpdateMerchantReferences GetUpdateMerchantReferences()
        {
            Klarna.Rest.Models.Requests.UpdateMerchantReferences updateMerchantReferences = new Klarna.Rest.Models.Requests.UpdateMerchantReferences()
            {
                MerchantReference1 = "15632423",
                MerchantReference2 = "special order"
            };

            return updateMerchantReferences;
        }
    }
}
