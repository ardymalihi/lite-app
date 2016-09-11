
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LiteApp.Models
{
    public abstract class Module
    {
        private string _Id;

        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _Id = Guid.NewGuid().ToString();
                }
                else
                {
                    _Id = value;
                }
            }
        }

        public string Type
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public List<Style> Styles { get; set; }

        public List<Script> Scripts { get; set; }

        public Module()
        {
            _Id = Guid.NewGuid().ToString();
            Styles = new List<Style>();
            Scripts = new List<Script>();
        }

        public abstract ModuleSettings GetSettings();
    }
}
