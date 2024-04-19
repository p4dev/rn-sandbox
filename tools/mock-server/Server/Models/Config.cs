using System;
namespace Server.Models
{
    public class Config
    {
        public int SiteId { get; set; }
        public string Site { get; set; }
        public int SalesAreaId { get; set; }
        public string SalesArea { get; set; }
        public string LastModified { get; set; }
        public string ThemeRevision { get; set; }
        public bool Conversational { get; set; }
        public bool AutoAdvance { get; set; }
        public bool SupportsLoyalty { get; set; }
        public string Locale { get; set; }
        public BookingConfig BookingConfig { get; set; }
        public MoveMergeConfig MoveMergeConfig { get; set; }
        public LocalCardValidationConfig LocalCardValidationConfig { get; set; }
        public TableDetailsConfig TableDetailsConfig { get; set; }
        public DelayedOrderingConfig DelayedOrderingConfig { get; set; }
        public UnattendedModeConfig UnattendedModeConfig { get; set; }
        public IList<PaymentMethod> PaymentMethods { get; set; }
        public IList<Currency> Currencies { get; set; }
        public IList<CorrectionMethod> CorrectionMethods { get; set; }
        public IList<object> CorrectionReasons { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Reason> Reasons { get; set; }
        public IList<PrinterType> PrinterTypes { get; set; }
        public IList<HeadersAndFooter> HeadersAndFooters { get; set; }
        public IList<Division> Divisions { get; set; }
        public IList<SubCategory> SubCategories { get; set; }
        public IList<EftRule> EftRules { get; set; }
        public IList<Role> Roles { get; set; }
    }
}

