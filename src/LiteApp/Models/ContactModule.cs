
using System.Collections.Generic;

namespace LiteApp.Models
{
    public class ContactModule : Module
    {
        public override ModuleSettings GetSettings()
        {
            return new ModuleSettings
            {
                Actions = new List<ModuleSettingsAction> {
                    new ModuleSettingsAction {
                        Title = "Edit",
                        Route = "/Edit"
                    }
                }
            };
        }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
