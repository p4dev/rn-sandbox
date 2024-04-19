using System;
namespace Server.Models
{
    class iZoneMessageData
    {
        public iZoneMessageData()
        {
            Table = new List<string>();
        }
        public string Status { get; set; }
        public string LastStatusChangeTime { get; set; }
        public string GuestId { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public List<string> Table { get; set; }
    }
}

