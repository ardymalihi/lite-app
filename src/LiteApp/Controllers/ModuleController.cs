using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using Newtonsoft.Json;
using LiteApp.Common;
using Newtonsoft.Json.Linq;
using LiteApp.Models;
using Newtonsoft.Json.Schema;

namespace LiteApp.Controllers
{
    public class ModuleController : BaseController
    {

        public ModuleController(IAppService appService) : base(appService) { }
        
        public IActionResult Settings(string id)
        {
            this.Layout.PageTitle = "Module Settings";

            var module = this.AppService.GetModule(id);

            var settingsViewModel = new SettingsViewModel
            {
                JsonData = JsonConvert.SerializeObject(module, Formatting.Indented, new JsonModuleConverter()),
                JsonSchema = GetModuleSchema(module),
                SaveEndpoint = "/module/save/" + id
            };

            return View("Settings", settingsViewModel);
        }

        [HttpPost]
        public IActionResult Save(string id, [FromBody]JObject request)
        {
            var module = this.AppService.GetModule(id);

            module = JsonConvert.DeserializeObject(request.ToString(), module.GetType(), new JsonModuleConverter()) as dynamic;

            var app = this.AppService.ApplySettings(this.AppService.App, module);

            this.AppService.Save(app);

            return Ok();
        }

        private string GetModuleSchema(Module module)
        {
            var schema = JObject.Parse(this.AppService.GetSchema());

            var moduleSchema = schema
                ["properties"]
                ["Pages"]
                ["items"]
                ["properties"]
                ["Rows"]
                ["items"]
                ["properties"]
                ["Cols"]
                ["items"]
                ["properties"]
                ["Modules"];

            var baseModuleProperties = moduleSchema
                ["items"]
                ["properties"] as JObject;

            JArray modulesOptionsSchema = moduleSchema["items"]["oneOf"] as JArray;

            JObject selectedModuleProperties = null;

            foreach (var item in modulesOptionsSchema)
            {
                var moduleName = item
                    ["properties"]
                    ["Type"]
                    ["default"].Value<string>();
                if (moduleName == module.Type)
                {
                    selectedModuleProperties = item["properties"] as JObject;
                    break;
                }
            }

            baseModuleProperties.Merge(selectedModuleProperties);

            var result = "{ 'title': 'Module Settings', 'type': 'object', 'properties': " + baseModuleProperties.ToString() + " }";

            return result;
        }
    }
}
