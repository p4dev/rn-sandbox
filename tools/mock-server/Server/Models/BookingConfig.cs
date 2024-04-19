using System;
namespace Server.Models
{
    public class BookingConfig
    {
        public bool DateRequired { get; set; }
        public bool TimeRequired { get; set; }
        public bool CoverCountRequired { get; set; }
        public double MinimumDeposit { get; set; }
    }
}

