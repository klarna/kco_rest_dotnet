using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using LegacyModels = Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class ProductIdentifiers: LegacyModels.ProductIdentifiers {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ProductIdentifiers {\n");
      sb.Append("  CategoryPath: ").Append(CategoryPath).Append("\n");
      sb.Append("  GlobalTradeItemNumber: ").Append(GlobalTradeItemNumber).Append("\n");
      sb.Append("  ManufacturerPartNumber: ").Append(ManufacturerPartNumber).Append("\n");
      sb.Append("  Brand: ").Append(Brand).Append("\n");
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
