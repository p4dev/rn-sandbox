using System;
namespace Server.Models
{
    public class PaymentLine
    {
        public PaymentLine()
        {
            InclusiveTaxBreakdown = new List<object>();
            Seats = new List<int>();
        }
        public double Amount { get; set; }
        public double Cashback { get; set; }
        public double Change { get; set; }
        public double Donation { get; set; }
        public double Forfeit { get; set; }
        public double InclusiveTax { get; set; }
        public List<object> InclusiveTaxBreakdown { get; set; }
        public int PaymentMethodId { get; set; }
        public int ReceiptNumber { get; set; }
        public double Tip { get; set; }
        public int Id { get; set; }
        public List<int> Seats { get; set; }
        public string Issuer { get; set; }
    }
}

