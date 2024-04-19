using System;
namespace Server.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }
        public bool IsBase { get; set; }
    }
}

