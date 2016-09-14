using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using LiteApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LiteApp.Common;

namespace LiteApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {

        public AdminController(IAppService appService) : base(appService) { }

        public IActionResult Panel()
        {
            this.Layout.FullRow = true;

            var settingsViewModel = new SettingsViewModel
            {
                JsonData = JsonConvert.SerializeObject(this.AppService.App, Formatting.Indented, new JsonModuleConverter()),
                JsonSchema = this.AppService.Schema(),
                SaveEndpoint = "/admin/save"
            };

            return View("Settings", settingsViewModel);
        }

        [HttpPost]
        public IActionResult Save([FromBody]JObject request)
        {
            string json = request.ToString();
            App app = JsonConvert.DeserializeObject<App>(json, new JsonModuleConverter());
            this.AppService.Save(app);
            return Ok();
        }
    }
}
