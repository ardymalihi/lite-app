using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Col
    {
        public List<IModule> Modules { get; set; }

        public Col()
        {
            Modules = new List<IModule>();
        }
    }
}
