using System;
namespace Server.Models
{
    public class Message
    {
        public string Id { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Expires { get; set; }
        public string RecipientType { get; set; }
        public string Originator { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Status { get; set; }
        public DateTime LastStatusChangeTime { get; set; }
        public string GuestId { get; set; }
        public string Name { get; set; }
        public string AccountId { get; set; }
        public List<string> Table { get; set; }
    }

}

