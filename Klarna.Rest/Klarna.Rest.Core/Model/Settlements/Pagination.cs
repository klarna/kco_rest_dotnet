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
  public class Pagination {
    /// <summary>
    /// The amount of elements in the current result
    /// </summary>
    /// <value>The amount of elements in the current result</value>
    [DataMember(Name="count", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "count")]
    public long? Count { get; set; }

    /// <summary>
    /// The total amount of elements that are available
    /// </summary>
    /// <value>The total amount of elements that are available</value>
    [DataMember(Name="total", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "total")]
    public long? Total { get; set; }

    /// <summary>
    /// The URI to the next \"page\" of results.
    /// </summary>
    /// <value>The URI to the next \"page\" of results.</value>
    [DataMember(Name="next", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "next")]
    public string Next { get; set; }

    /// <summary>
    /// The URI to the previous \"page\" of results.
    /// </summary>
    /// <value>The URI to the previous \"page\" of results.</value>
    [DataMember(Name="prev", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "prev")]
    public string Prev { get; set; }

    /// <summary>
    /// The current offset. Describes \"where\" in a collection the current starts.
    /// </summary>
    /// <value>The current offset. Describes \"where\" in a collection the current starts.</value>
    [DataMember(Name="offset", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "offset")]
    public long? Offset { get; set; }


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
