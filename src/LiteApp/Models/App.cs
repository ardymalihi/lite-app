using System.Collections.Generic;

namespace LiteApp.Models
{
    public class App
    {
        public string Title { get; set; }

        public string HeaderHtml { get; set; }

        public bool ShowHeaderInAllPages { get; set; }

        public List<MenuItem> Menus { get; set; }

        public List<Page> Pages { get; set; }

        public string FooterHtml { get; set; }

        public List<Style> Styles { get; set; }

        public List<Script> ScriptsTop { get; set; }

        public List<Script> ScriptsBottom { get; set; }

        public App()
        {
            Menus = new List<MenuItem>();
            Pages = new List<Page>();
            Styles = new List<Style>();
            ScriptsTop = new List<Script>();
            ScriptsBottom = new List<Script>();
        }
    }
}
