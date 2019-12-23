using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.OrderManagement {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class InitialPaymentMethodDto : OrderManagementInitialPaymentMethod{
    /// <summary>
    /// The number of installments (if applicable).
    /// </summary>
    /// <value>The number of installments (if applicable).</value>
    [DataMember(Name="number_of_installments", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "number_of_installments")]
    public int? NumberOfInstallments { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InitialPaymentMethodDto {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  NumberOfInstallments: ").Append(NumberOfInstallments).Append("\n");
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
