using System;
namespace Server.Models
{
    public class ProductLine
    {
        public ProductLine()
        {
            //InclusiveTaxBreakdown = new List<object>();
            Seats = new List<int>();
            TariffPrice = 1;
        }
        public long Id { get; set; }
        public long? IngredientId { get; set; }
        public int? PortionTypeId { get; set; }
        public int? OrderDestinationId { get; set; }
        public int? Quantity { get; set; }
        public bool? SentToKitchen { get; set; }
        public double? TariffPrice { get; set; }
        public bool? AndWithPreviousLine { get; set; }
        public DateTime? OriginalRingUpTime { get; set; }

        // Payment
        public double? Amount { get; set; }
        public double? Cashback { get; set; }
        public double? Change { get; set; }
        public double? Donation { get; set; }
        public double? Forfeit { get; set; }
        public double? InclusiveTax { get; set; }
        public List<object>? InclusiveTaxBreakdown { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? ReceiptNumber { get; set; }
        public double? Tip { get; set; }
        public List<int>? Seats { get; set; }
        public string? Issuer { get; set; }
    }
}

