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
            if (appViewModel.CurrentPage == null)
            {
                return new LayoutViewModel
                {
                    AppViewModel = appViewModel,
                    PageTitle = "Page Not Found",
                    Styles = appViewModel.App.Styles.OrderBy(o => o.Order).ToArray(),
                    ScriptsTop = appViewModel.App.ScriptsTop.OrderBy(o => o.Order).ToArray(),
                    ScriptsBottom = appViewModel.App.ScriptsBottom.OrderBy(o => o.Order).ToArray()
                };
            }
            else
            {
                return new LayoutViewModel
                {
                    AppViewModel = appViewModel,
                    PageTitle = appViewModel.CurrentPage.Title,
                    Styles = appViewModel.App.Styles.Union(appViewModel.CurrentPage.Styles).OrderBy(o => o.Order).ToArray(),
                    ScriptsTop = appViewModel.App.ScriptsTop.Union(appViewModel.CurrentPage.ScriptsTop).OrderBy(o => o.Order).ToArray(),
                    ScriptsBottom = appViewModel.App.ScriptsBottom.Union(appViewModel.CurrentPage.ScriptsBottom).OrderBy(o => o.Order).ToArray()
                };
            }
        }
    }
}
