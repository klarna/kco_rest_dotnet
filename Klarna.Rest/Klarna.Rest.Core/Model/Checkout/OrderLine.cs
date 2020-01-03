using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using LegacyModels = Klarna.Rest.Core.Model;

namespace Klarna.Rest.Core.Model.Checkout {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class OrderLine : LegacyModels.OrderLine {
    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class OrderLine {\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Reference: ").Append(Reference).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Quantity: ").Append(Quantity).Append("\n");
      sb.Append("  QuantityUnit: ").Append(QuantityUnit).Append("\n");
      sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
      sb.Append("  TaxRate: ").Append(TaxRate).Append("\n");
      sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
      sb.Append("  TotalDiscountAmount: ").Append(TotalDiscountAmount).Append("\n");
      sb.Append("  TotalTaxAmount: ").Append(TotalTaxAmount).Append("\n");
      sb.Append("  MerchantData: ").Append(MerchantData).Append("\n");
      sb.Append("  ProductUrl: ").Append(ProductUrl).Append("\n");
      sb.Append("  ImageUrl: ").Append(ImageUrl).Append("\n");
      sb.Append("  ProductIdentifiers: ").Append(ProductIdentifiers).Append("\n");
      sb.Append("  ShippingAttributes: ").Append(ShippingAttributes).Append("\n");
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
