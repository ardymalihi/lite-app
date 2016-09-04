using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Page
    {
        public string Title { get; set; }

        public string Route { get; set; }

        public List<Row> Rows { get; set; }

        public Page()
        {
            Rows = new List<Row>();
        }
    }
}
