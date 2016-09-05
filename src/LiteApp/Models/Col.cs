using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
