using System;
namespace Server.Models
{
    public class UnattendedModeConfig
    {
        public int CorrectionMethodRegular { get; set; }
        public int CorrectionMethodClearAll { get; set; }
        public bool Enabled { get; set; }
        public int PrintJobRetryPeriod { get; set; }
    }
}

