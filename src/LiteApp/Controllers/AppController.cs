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
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
