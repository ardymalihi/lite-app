using System.Collections.Generic;

namespace LiteApp.Models
{
    public class Col
    {
        public string ClassName { get; set; }

        public List<Module> Modules { get; set; }

        public Col()
        {
            Modules = new List<Module>();
        }
    }
}
