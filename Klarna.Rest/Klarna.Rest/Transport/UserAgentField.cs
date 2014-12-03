#region Copyright Header
//-----------------------------------------------------------------------
// <copyright file="UserAgentField.cs" company="Klarna AB">
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
    using System.Text;

    /// <summary>
    /// A user agent field, for example Language/Java_1.7.0
    /// </summary>
    public class UserAgentField
    {
        /// <summary>
        /// The key.
        /// </summary>
        private string key;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The version.
        /// </summary>
        private string version;

        /// <summary>
        /// The options.
        /// </summary>
        private string[] options;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentField"/> class.
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="name">the name</param>
        /// <param name="version">the version</param>
        /// <param name="options">the options</param>
        public UserAgentField(string key, string name, string version, string[] options)
        {
            this.key = key;
            this.name = name;
            this.version = version;
            this.options = options;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key
        {
            get
            {
                return this.key;
            }
        }

        /// <summary>
        /// ToString override. Appends the key, name, version and options of the field and returns it
        /// in correct format.
        /// </summary>
        /// <returns>the string</returns>
        public override string ToString()
        {
            var optionsString = new StringBuilder();
            if (this.options != null && this.options.Length > 0)
            {
                optionsString.Append("(");
                optionsString.Append(string.Join(" ; ", this.options));
                optionsString.Append(")");
            }

            return string.Format("{0}/{1}_{2} {3}", this.Key, this.name, this.version, optionsString);
        }
    }
}
