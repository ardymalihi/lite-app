using System.Collections.Generic;

namespace LiteApp.Models
{
    public class Page
    {
        public string Title { get; set; }

        public string Name { get; set; }

        public List<Row> Rows { get; set; }

        public Page()
        {
            Rows = new List<Row>();
        }
    }
}
