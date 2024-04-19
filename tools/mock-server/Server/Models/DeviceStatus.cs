using System;
namespace Server.Models
{
    public class DeviceStatus
    {
        public List<DeviceInfo> Devices { get; set; }
        public List<string> Errors { get; set; }
        public List<long> OutOfStock { get; set; }
        public List<LimitedStock> LimitedStock { get; set; }
        public List<Message> Messages { get; set; }
    }
}

