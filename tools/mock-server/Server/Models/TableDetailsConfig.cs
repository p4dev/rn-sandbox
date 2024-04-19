using System;
namespace Server.Models
{
    public class TableDetailsConfig
    {
        public bool UseCoverCount { get; set; }
        public bool UseCustomerName { get; set; }
        public bool PerSeatUseCoverCount { get; set; }
        public bool PerSeatUseCustomerName { get; set; }
        public int ServiceChargeCoverThreshold { get; set; }
    }
}

