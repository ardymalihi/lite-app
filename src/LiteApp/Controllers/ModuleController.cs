using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using Newtonsoft.Json;
using LiteApp.Common;

namespace LiteApp.Controllers
{
    public class ModuleController : BaseController
    {

        public ModuleController(IAppService appService) : base(appService) { }
        
        public IActionResult Settings(string id)
        {
            var module = this.AppService.GetModule(id);

            return View(new SettingsViewModel {
                JsonData = JsonConvert.SerializeObject(module, Formatting.Indented, new JsonModuleConverter()),
                JsonSchema = ""
            });
        }
    }
}
