namespace Klarna.Rest.Core.Model.Enum
{
    /// <summary>
    /// Order line product type.
    /// </summary>
    public enum OrderLineType
    {
        physical,
        discount,
        shipping_fee,
        sales_tax,
        digital,
        gift_card,
        store_credit,
        surcharge
    }
}