#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="ConnectorFactoryTests.cs" company="Klarna AB">
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
    using Klarna.Rest.Transport;
    using NUnit.Framework;

    /// <summary>
    /// Tests the ConnectorFactory class.
    /// </summary>
    [TestFixture]
    public class ConnectorFactoryTests
    {
        #region Tests

        /// <summary>
        /// Basic test of Create method.
        /// </summary>
        [Test]
        public void Transport_ConnectorFactory_CreateBasic()
        {
            IConnector connector = ConnectorFactory.Create("id", "secret", Client.TestBaseUrl);

            Assert.NotNull(connector);
        }

        /// <summary>
        /// Basic test of Create method.
        /// </summary>
        [Test]
        public void Transport_ConnectorFactory_CreateAdvanced()
        {
            RequestFactory requests = new RequestFactory();
            IConnector connector = ConnectorFactory.Create(requests, "id", "secret", UserAgent.WithDefaultFields(), Client.TestBaseUrl);

            Assert.NotNull(connector);
            Assert.AreEqual(connector.UserAgent.ToString(), UserAgent.WithDefaultFields().ToString());
        }

        #endregion
    }
}
