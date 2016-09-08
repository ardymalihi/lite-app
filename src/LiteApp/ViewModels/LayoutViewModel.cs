using LiteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.ViewModels
{
    public class LayoutViewModel
    {
        public string PageName { get; set; }

        public string PageTitle  { get; set; }

        public AppViewModel AppViewModel { get; set; }

        public bool ShowHeader { get; set; }

    }
}
