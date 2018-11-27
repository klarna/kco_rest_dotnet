using Klarna.Rest.Core.Model.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Klarna.Rest.Core.Model
{
    /// <summary>
    /// The payout object
    /// </summary>
    public class SettlementsPayout
    {
        /// <summary>
        /// Totals
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "totals")]
        public SettlementsPayoutTotals Totals { get; set; }
        /// <summary>
        /// The reference id of the payout.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "payment_reference")]
        public string PaymentReference { get; set; }
        /// <summary>
        /// ISO-8601 formatted date-time string
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "payout_date")]
        public string PayoutDate { get; set; }
        /// <summary>
        /// ISO-3166 Currency Code.
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Whether the amounts are net or gross
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "merchant_settlement_type")]
        public MerchantSettlementType MerchantSettlementType { get; set; }
        /// <summary>
        /// The merchant id
        /// </summary>
        /// <remarks>Required</remarks>
        [JsonProperty(PropertyName = "merchant_id")]
        public string MerchantId { get; set; }
        /// <summary>
        /// Link to the transactions that are part of this payout
        /// </summary>
        [JsonProperty(PropertyName = "transactions")]
        public string Transactions { get; set; }
    }
}
