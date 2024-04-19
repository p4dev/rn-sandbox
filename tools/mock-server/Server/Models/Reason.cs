using System;
namespace Server.Models
{
    public class Reason
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EposName { get; set; }
        public bool? IsOpenEntry { get; set; }
    }
}

