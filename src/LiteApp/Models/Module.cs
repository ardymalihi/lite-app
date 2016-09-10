
using System.Collections.Generic;

namespace LiteApp.Models
{
    public class Module
    {
        public List<Style> Styles { get; set; }

        public List<Script> Scripts { get; set; }

        public string Type
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public Module()
        {
            Styles = new List<Style>();
            Scripts = new List<Script>();
        }
    }
}
