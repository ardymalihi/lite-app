using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using LiteApp.Models;

namespace LiteApp.Controllers
{
    public class HtmlController : BaseController
    {

        public HtmlController(IAppService appService) : base(appService) { }
        
        public IActionResult Edit(string id)
        {
            var module = this.AppService.GetModule(id);

            return View(new ModuleViewModel {
                App = this.AppService.App,
                CurrentPage = this.CurrentPage,
                CurrentModule = module
            });
            
        }

        [HttpPost]
        public IActionResult Save(string id, [FromBody]HtmlModule request)
        {
            var module = (HtmlModule)this.AppService.GetModule(id);

            module.Content = request.Content;

            this.AppService.Save(this.AppService.App);

            return Ok();

        }
    }
}
