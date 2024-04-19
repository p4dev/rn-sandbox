using System;
namespace Server.Models
{
    public class DelayedOrderingConfig
    {
        public bool UsePickUpTimeForSalesAndPromotions { get; set; }
        public IList<ExtraCustomerDetail> ExtraCustomerDetails { get; set; }
    }
}

