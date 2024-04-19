using System;
namespace Server.Models
{
    class Base
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }

    class Engine : Base
    {
    }

    class Plugin : Base
    {
        public string Text { get; set; }
    }
}

