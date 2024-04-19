using System;
namespace Server.Models
{
    class IZoneMessage
    {
        public static IZoneMessage CreateMessage(string subject, string body, int lastId)
        {
            return new IZoneMessage { Subject = subject, Body = body, Id = ++lastId };
        }

        private IZoneMessage()
        {
            Data = new iZoneMessageData();
        }

        public int Id { get; set; }
        public string Sent { get; set; }
        public string Expires { get; set; }
        public string RecipientType { get; set; }
        public string Originator { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public iZoneMessageData Data { get; set; }
    }
}

