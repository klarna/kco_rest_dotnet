using System;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    ///
    /// </summary>
    [Obsolete("This model is being deprecated. Use the Customer model from Klarna.Rest.Core.Model.OrderManagement namespace instead")]
    public class OrderManagementCustomer
    {
        /// <summary>
        /// The customer date of birth. ISO 8601.
        /// </summary>
        [JsonProperty(PropertyName = "date_of_birth")]
        public string DateOfBirth { get; set; }
        /// <summary>
        /// The customer national identification number.
        /// </summary>
        [JsonProperty(PropertyName = "national_identification_number")]
        public string NationalIdentificationNumber { get; set; }
    }
}