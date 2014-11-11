#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="RequestFactoryTests.cs" company="Klarna AB">
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
namespace Klarna.Rest.Tests.Transport
{
    using System;
    using System.Net;
    using Klarna.Rest.Transport;
    using NUnit.Framework;
    using Rhino.Mocks;

    /// <summary>
    /// Tests the RequestFactory class.
    /// </summary>
    [TestFixture]
    public class RequestFactoryTests
    {
        #region Private Fields

        /// <summary>
        /// The request factory.
        /// </summary>
        private RequestFactory factory;

        #endregion

        #region Set Up

        /// <summary>
        /// The set up before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.factory = new RequestFactory();
        }

        #endregion

        #region Tests

        /// <summary>
        /// Basic test of CreateRequest.
        /// </summary>
        [Test]
        public void Transport_RequestFactory_CreateRequest()
        {
            const string Url = "https://localhost/path";
            HttpWebRequest request = this.factory.CreateRequest(Url);

            Assert.That(Url, Is.EqualTo(request.RequestUri));
        }

        #endregion
    }
}
