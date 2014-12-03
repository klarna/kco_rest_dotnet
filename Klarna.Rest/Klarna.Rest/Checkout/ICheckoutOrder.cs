#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ICheckoutOrder.cs" company="Klarna AB">
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
namespace Klarna.Rest.Checkout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Klarna.Rest.Models;

    /// <summary>
    /// Checkout order resource interface.
    /// </summary>
    public interface ICheckoutOrder : IResource
    {
        /// <summary>
        /// Creates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order data</param>
        void Create(CheckoutOrderData checkoutOrderData);

        /// <summary>
        /// Updates the resource.
        /// </summary>
        /// <param name="checkoutOrderData">the order data</param>
        /// <returns>the updated checkout order data</returns>
        CheckoutOrderData Update(CheckoutOrderData checkoutOrderData);

        /// <summary>
        /// Fetches the resource.
        /// </summary>
        /// <returns>the checkout order data</returns>
        CheckoutOrderData Fetch();
    }
}
