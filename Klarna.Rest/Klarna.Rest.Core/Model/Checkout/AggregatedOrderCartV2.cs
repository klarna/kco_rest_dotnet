using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class AggregatedOrderCartV2 {
    /// <summary>
    /// Gets or Sets Items
    /// </summary>
    [DataMember(Name="items", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "items")]
    public List<AggregatedOrderCartItemV2> Items { get; set; }

    /// <summary>
    /// Gets or Sets TotalPriceExcludingTax
    /// </summary>
    [DataMember(Name="total_price_excluding_tax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_price_excluding_tax")]
    public long? TotalPriceExcludingTax { get; set; }

    /// <summary>
    /// Gets or Sets TotalPriceIncludingTax
    /// </summary>
    [DataMember(Name="total_price_including_tax", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_price_including_tax")]
    public long? TotalPriceIncludingTax { get; set; }

    /// <summary>
    /// Gets or Sets TotalTaxAmount
    /// </summary>
    [DataMember(Name="total_tax_amount", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total_tax_amount")]
    public long? TotalTaxAmount { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AggregatedOrderCartV2 {\n");
      sb.Append("  Items: ").Append(Items).Append("\n");
      sb.Append("  TotalPriceExcludingTax: ").Append(TotalPriceExcludingTax).Append("\n");
      sb.Append("  TotalPriceIncludingTax: ").Append(TotalPriceIncludingTax).Append("\n");
      sb.Append("  TotalTaxAmount: ").Append(TotalTaxAmount).Append("\n");
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
