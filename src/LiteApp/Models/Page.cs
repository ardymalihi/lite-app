using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Page
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public List<Row> Rows { get; set; }

        public List<Style> Styles { get; set; }

        public List<Script> ScriptsTop { get; set; }

        public List<Script> ScriptsBottom { get; set; }

        public Page()
        {
            Rows = new List<Row>();
            Styles = new List<Style>();
            ScriptsTop = new List<Script>();
            ScriptsBottom = new List<Script>();
        }
    }
}
