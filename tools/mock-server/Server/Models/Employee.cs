using System;
namespace Server.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public int DefaultRole { get; set; }
        public IList<int> Roles { get; set; }
        public string Password { get; set; }
        public string DallasId { get; set; }
    }
}

