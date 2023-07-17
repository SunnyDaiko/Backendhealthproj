namespace Catalyte.Apparel.DTOs.Purchases
{
    /// <summary>
    /// Describes a data transfer objecct for a single line item of a purchase transaction.
    /// </summary>
    public class LineItemDTO
    {
        public int PatientId { get; set; }
        public int PurchaseId { get; set; }
        public int EncounterId { get; set; }
        public int Quantity { get; set; }
    }
}
