using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class App
    {
        public List<Page> Pages { get; set; }

        public App()
        {
            Pages = new List<Page>();
        }
    }
}
