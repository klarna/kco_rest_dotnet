using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model.Settlements {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class Pagination: Model.Pagination {
    /// <summary>
    /// The URI to the previous \"page\" of results.
    /// </summary>
    /// <value>The URI to the previous \"page\" of results.</value>
    [DataMember(Name="prev", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prev")]
    public string Prev { get; set; }

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Pagination {\n");
      sb.Append("  Count: ").Append(Count).Append("\n");
      sb.Append("  Total: ").Append(Total).Append("\n");
      sb.Append("  Next: ").Append(Next).Append("\n");
      sb.Append("  Prev: ").Append(Prev).Append("\n");
      sb.Append("  Offset: ").Append(Offset).Append("\n");
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
