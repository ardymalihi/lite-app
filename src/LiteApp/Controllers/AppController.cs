﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using LiteApp.Models;

namespace LiteApp.Controllers
{
    public class AppController : Controller
    {
        private IAppService _appService;

        public AppController(IAppService appService)
        {
            _appService = appService;
        }
        public IActionResult Index(string page)
        {
            var pageModel = _appService.GetCurrentPage("/" + page);
            var appViewModel = new AppViewModel
            {
                App = _appService.App,
                CurrentPage = pageModel ?? GetNotFoundPage()
            };

            return View(appViewModel);
        }

        public IActionResult Error()
        {
            return View();
        }

        private Page GetNotFoundPage()
        {
            return new Models.Page
            {
                Route = this.Request.Path.Value,
                Rows = new List<Models.Row> {
                    new Models.Row {
                        ClassName = "row",
                        Cols = new List<Models.Col> {
                            new Models.Col {
                                ClassName = "col-md-12",
                                Modules = new List<Models.IModule> {
                                    new HtmlModule {
                                        Content = _appService.App.NotFoundHtml
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
