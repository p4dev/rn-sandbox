using System;
namespace Server.Models
{
    public class Account
    {
        public static Account CreateAccount(string accountNo, string tableNo)
        {
            return new Account(accountNo, tableNo);
        }
        public Account()
        {
            Lines = new List<ProductLine>();
            TaxesAndServiceCharges = new List<TaxesAndServiceCharge>();
            ThemeDataRevision = "1";
            ConversationalOrderingMode = true;
        }

        protected Account(string accountNo, string tableNo) : this()
        {
            AccountNumber = accountNo;
            AccountId = Convert.ToInt64(accountNo);
            TableNumber = tableNo;
            CLMAccountId = "";
            MoaOrderIdentifier = accountNo;
        }

        public bool? AccountClosed { get; set; }
        public long? AccountId { get; set; }
        public string AccountNumber { get; set; }
        public long? AccountOwner { get; set; }
        public int? AccountSequenceNumber { get; set; }
        public double? AccountTotal { get; set; }
        public bool? ActiveMoneyBeltSession { get; set; }
        public string CLMAccountId { get; set; }
        public bool? ConversationalOrderingMode { get; set; }
        public int? CoverCount { get; set; }
        public string CustomerName { get; set; }
        public bool? DonationPromptEnabled { get; set; }
        public bool? HasBillBeenPrintedForSecurity { get; set; }
        public bool? HasCardValidationBeenOverriden { get; set; }
        public bool? HasValidatedCard { get; set; }
        public bool? HoldDelayedOrder { get; set; }
        public List<ProductLine> Lines { get; set; }
        public string MoaOrderIdentifier { get; set; }
        public double? OutstandingBalance { get; set; }
        public bool? SaveAccount { get; set; }
        public string TableNumber { get; set; }
        public List<TaxesAndServiceCharge> TaxesAndServiceCharges { get; set; }
        public string ThemeDataRevision { get; set; }
        public bool? TrainingMode { get; set; }
        public int? UserRoleId { get; set; }
    }
}

