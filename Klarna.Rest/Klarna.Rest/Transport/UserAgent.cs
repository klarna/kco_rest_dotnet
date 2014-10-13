#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UserAgent.cs" company="Klarna AB">
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
namespace Klarna.Rest.Transport
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.Win32;

    /// <summary>
    /// The user agent string creation class.
    /// </summary>
    public class UserAgent
    {
        #region Private Fields

        /// <summary>
        /// Name of the SDK
        /// </summary>
        private const string NAME = "kco_rest_dotnet";

        /// <summary>
        /// Components of the user agent.
        /// </summary>
        private readonly List<UserAgentField> fields = new List<UserAgentField>();

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgent"/> class.
        /// Following fields are predefined:
        /// Library, OS, Language and Webserver.
        /// </summary>
        public UserAgent()
        {
            this.fields = new List<UserAgentField>();
            this.fields.Add(new UserAgentField("Library", NAME, Assembly.GetExecutingAssembly().GetName().Version.ToString(3), new string[0]));
            var os = Environment.OSVersion;
            this.fields.Add(new UserAgentField("OS", os.Platform.ToString(), os.Version.ToString(), new string[0]));
            this.fields.Add(new UserAgentField("Language", ".Net", Environment.Version.ToString(), new string[0]));
            this.fields.Add(new UserAgentField("Webserver", "IIS", this.IisVersion(), new string[0]));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a field to the field collection.
        /// </summary>
        /// <param name="field">
        /// The field name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if field already exists.
        /// </exception>
        public void AddField(string field, string name, string version)
        {
            this.AddField(field, name, version, new string[0]);
        }

        /// <summary>
        /// Adds a field to the field collection.
        /// </summary>
        /// <param name="field">
        /// The field name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if field already exists.
        /// </exception>
        public void AddField(string field, string name, string version, string[] options)
        {
            if (this.fields.Exists(f => f.Key.Equals(field)))
            {
                throw new ArgumentException("Field already exists.", field);
            }

            this.fields.Add(new UserAgentField(field, name, version, options));
        }

        /// <summary>
        /// Returns the user agent string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var field in this.fields)
            {
                builder.Append(field.ToString());
            }

            return builder.ToString().TrimEnd(' ');
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets IIS version.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string IisVersion()
        {
            var iisVersion = "Unknown_0.0";
            using (var iisKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp\"))
            {
                if (iisKey != null)
                {
                    var versionString = iisKey.GetValue("VersionString") as string;
                    if (versionString != null)
                    {
                        var splitVersionString = versionString.Split(' ');
                        if (splitVersionString.Length > 1)
                        {
                            iisVersion = splitVersionString[1];
                        }
                    }
                }
            }

            return iisVersion;
        }

        #endregion
    }
}
