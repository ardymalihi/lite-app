using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;

namespace LiteApp.Controllers
{
    public class AppController : Controller
    {
        private IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService;
        }
        public IActionResult Index()
        {
            var page = _appService.GetCurrentPage(this.Request.Path.Value);
            if (page != null)
            {
                return View();
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
