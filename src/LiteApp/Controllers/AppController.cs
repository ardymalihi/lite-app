using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;


namespace LiteApp.Controllers
{
    public class AppController : BaseController
    {

        public AppController(IAppService appService) : base(appService) { }
        

        public IActionResult Index()
        {
            if (this.CurrentPage != null)
            {
                return View(this.AppViewModel);
            }
            else
            {
                return View("NotFound");
            }
            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
