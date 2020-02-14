using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Klarna.Rest.Core.Model {

    /// <summary>
    /// Customer token status update
    /// </summary>
    [DataContract]
    public class CustomerTokenStatusUpdateRequest {
        /// <summary>
        /// The token status to update to. Can be 'CANCELLED'.
        /// </summary>
        /// <value>The token status to update to. Can be 'CANCELLED'.</value>
        [DataMember(Name="status", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  {
            var sb = new StringBuilder();
            sb.Append("class CustomerTokenStatusUpdateRequest {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
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
