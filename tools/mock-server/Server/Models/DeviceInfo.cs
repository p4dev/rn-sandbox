using System;
namespace Server.Models
{
    public class DeviceInfo
    {
        public string Device { get; set; }
        public string SalesArea { get; set; }
        public int SalesAreaId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastAccess { get; set; }
        public long? User { get; set; }
    }
}

