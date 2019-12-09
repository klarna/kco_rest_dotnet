using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Customer {
    /// <summary>
    /// The customer date of birth. ISO 8601. 
    /// </summary>
    /// <value>The customer date of birth. ISO 8601. </value>
    [DataMember(Name="date_of_birth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "date_of_birth")]
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// The customer national identification number
    /// </summary>
    /// <value>The customer national identification number</value>
    [DataMember(Name="national_identification_number", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "national_identification_number")]
    public string NationalIdentificationNumber { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Customer {\n");
      sb.Append("  DateOfBirth: ").Append(DateOfBirth).Append("\n");
      sb.Append("  NationalIdentificationNumber: ").Append(NationalIdentificationNumber).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
