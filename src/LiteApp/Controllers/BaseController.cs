using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LiteApp.Services;
using LiteApp.ViewModels;
using LiteApp.Models;

using Microsoft.AspNetCore.Mvc.Filters;

namespace LiteApp.Controllers
{
    public class BaseController : Controller
    {
        private IAppService _appService;

        private Page _currentPage { get; set; }

        public IAppService AppService
        {
            get
            {
                return _appService;
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
        }

        public LayoutViewModel Layout
        {
            get
            {
                return ViewBag.LayoutViewModel;
            }
        }

        public AppViewModel AppViewModel { get; set; }

        public BaseController(IAppService appService)
        {
            _appService = appService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            _currentPage = _appService.GetCurrentPage(this.Request.Path.Value);

            AppViewModel = new AppViewModel
            {
                App = _appService.App,
                CurrentPage = _currentPage
            };

            if (User.Identity.IsAuthenticated)
            {
                AppViewModel.UserProfile = new UserProfileViewModel
                {
                    Name = User.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                    EmailAddress = User.Claims.FirstOrDefault(c => c.Type == "emailaddress")?.Value,
                    ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
                    Country = User.Claims.FirstOrDefault(c => c.Type == "country")?.Value
                };
            }

            ViewBag.LayoutViewModel = CreateLayoutViewModel(AppViewModel);
        }

        private LayoutViewModel CreateLayoutViewModel(AppViewModel appViewModel)
        {
            string PageName = appViewModel.CurrentPage?.Name ?? "";
            var PageTitle = appViewModel.CurrentPage?.Title ?? "Page Not Found";

            return new LayoutViewModel
            {
                ShowHeader = !string.IsNullOrWhiteSpace(appViewModel.App.HeaderHtml) && (appViewModel.App.ShowHeaderInAllPages || PageName.ToLower() == "home"),
                AppViewModel = appViewModel,
                PageTitle = PageTitle,
                PageName = PageName
            };
        }
    }
}
