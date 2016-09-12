
using System.Collections.Generic;

namespace LiteApp.Models
{
    public class ContactModule : Module
    {
        public override ModuleSettings GetSettings()
        {
            return new ModuleSettings
            {
                HasSettings = true
            };
        }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
