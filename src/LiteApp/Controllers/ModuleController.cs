using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;

namespace LiteApp.Controllers
{
    public class ModuleController : BaseController
    {

        public ModuleController(IAppService appService) : base(appService) { }
        
        public IActionResult Settings(string id)
        {
            var module = this.AppService.GetModule(id);

            return View(new ModuleViewModel {
                App = this.AppService.App,
                CurrentPage = this.CurrentPage,
                CurrentModule = module
            });
            
        }
    }
}
