using System;
namespace Server.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OverPaymentType { get; set; }
        public int CurrencyId { get; set; }
        public bool CanBeUsed { get; set; }
        public bool CashDrawerMustBeOpened { get; set; }
        public int EftRuleId { get; set; }
        public double? Amount { get; set; }
        public IList<int> TaskIds { get; set; }
    }
}

