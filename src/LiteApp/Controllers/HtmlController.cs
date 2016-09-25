using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using LiteApp.Models;
using LiteApp.Requests;
using Newtonsoft.Json;
using LiteApp.Common;

namespace LiteApp.Controllers
{
    public class HtmlController : BaseController
    {

        public HtmlController(IAppService appService) : base(appService) { }
        
        public IActionResult Edit(string id)
        {
            this.Layout.PageTitle = "Edit Html";

            var module = this.AppService.GetModule(id);

            return View(new ModuleViewModel {
                App = this.AppService.App,
                CurrentPage = this.CurrentPage,
                CurrentModule = module
            });
            
        }

        [HttpPost]
        public IActionResult Edit(HtmlModuleSaveRequest request)
        {
            if (ModelState.IsValid)
            {
                var module = this.AppService.GetModule(request.Id) as HtmlModule;

                module.Content = request.Content;

                var app = this.AppService.ApplySettings(this.AppService.App, module);

                this.AppService.Save(app);

            }

            return RedirectToAction("Edit", new { id = request.Id });
        }
    }
}
