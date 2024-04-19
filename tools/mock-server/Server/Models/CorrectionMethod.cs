using System;
namespace Server.Models
{
    public class CorrectionMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeUsed { get; set; }
        public IList<int> CorrectionReasons { get; set; }
        public string CorrectionType { get; set; }
    }
}

