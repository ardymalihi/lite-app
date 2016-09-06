using LiteApp.Data;
using LiteApp.Models;
using System.Linq;


namespace LiteApp.Services
{
    public class AppService: IAppService
    {
        private IAppData _appData;
        private App _app;

        public App App
        {
            get
            {
                return _app;
            }
        }

        public AppService(IAppData appData)
        {
            _appData = appData;

            _app = _appData.Load();
        }

        public void Save(App app)
        {
            _app = app;

            _appData.Save(_app);
        }

        public Page GetCurrentPage(string route)
        {
            var compareValue = route.ToLower().TrimEnd(new char[] { ' ', '?' }).TrimStart('/');
            return _app.Pages.FirstOrDefault(o => o.Name.ToLower() == compareValue);
        }
    }
}
