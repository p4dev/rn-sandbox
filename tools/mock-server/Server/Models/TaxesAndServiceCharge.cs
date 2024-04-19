using System;
namespace Server.Models
{
    public class TaxesAndServiceCharge
    {
        public double Amount { get; set; }
        public bool Enabled { get; set; }
        public int TaxId { get; set; }
    }
}

