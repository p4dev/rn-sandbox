using System;
namespace Server.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<string> Permissions { get; set; }
        public IList<int> TaskIds { get; set; }
    }
}

