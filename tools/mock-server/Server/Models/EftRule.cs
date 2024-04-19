using System;
namespace Server.Models
{
    public class EftRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceRequestType { get; set; }
        public string DataEntryMethod { get; set; }
        public int Timeout { get; set; }
        public string ZcfClmOperationType { get; set; }
        public bool? CashbackAllowedOnBarAccounts { get; set; }
        public bool? CashbackAllowedOnPerSeatTableAccounts { get; set; }
        public bool? CashbackAllowedOnNonPerSeatTableAccounts { get; set; }
        public bool? CashbackAllowedOnDriveThruAccounts { get; set; }
    }
}

