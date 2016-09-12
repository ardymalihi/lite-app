
using System;
using System.Collections.Generic;

namespace LiteApp.Models
{
    public class HtmlModule : Module
    {
        public override ModuleSettings GetSettings()
        {
            return new ModuleSettings
            {
                HasSettings = false,
                Actions = new List<ModuleSettingsAction> {
                    new ModuleSettingsAction {
                        Title = "Edit",
                        Route = "Html/Edit/{id}"
                    }
                }
            };
        }

        public string Content { get; set; }
 
    }
}
