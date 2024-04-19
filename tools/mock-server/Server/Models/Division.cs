using System;
namespace Server.Models
{
    public class Division
    {
        public int Id { get; set; }
        public bool CanPayOnBarAccount { get; set; }
        public bool CanSaveOnBarAccount { get; set; }
    }
}

