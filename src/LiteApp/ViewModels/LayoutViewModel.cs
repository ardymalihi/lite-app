using LiteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.ViewModels
{
    public class LayoutViewModel
    {
        public string PageTitle  { get; set; }

        public AppViewModel AppViewModel { get; set; }

        public Style[] Styles { get; set; }

        public Script[] ScriptsTop { get; set; }

        public Script[] ScriptsBottom { get; set; }

    }
}
