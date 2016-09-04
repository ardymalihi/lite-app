using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class MenuItem
    {
        public string Title { get; set; }

        public string Route { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public MenuItem()
        {
            MenuItems = new List<MenuItem>();
        }
    }

    public class MenuModule: IModule
    {
        public List<MenuItem> MenuItems { get; set; }

        public MenuModule()
        {
            MenuItems = new List<MenuItem>();
        }
    }
}
