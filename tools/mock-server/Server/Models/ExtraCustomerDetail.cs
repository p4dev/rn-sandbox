using System;
namespace Server.Models
{
    public class ExtraCustomerDetail
    {
        public string Prompt { get; set; }
        public string Title { get; set; }
        public string EntryType { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
    }
}

