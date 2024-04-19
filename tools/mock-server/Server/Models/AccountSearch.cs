using System;
namespace Server.Models
{
    public class AccountSearch
    {
        public string AccountNumber { get; set; }
        public object AccountOwner { get; set; }
        public string CustomerName { get; set; }
        public double FullAccountTotal { get; set; }
        public bool HasNonZeroBalance { get; set; }
        public bool HoldDelayedOrder { get; set; }
        public string TableNumber { get; set; }
    }
}

