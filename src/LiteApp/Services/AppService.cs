using LiteApp.Data;
using LiteApp.Models;
using System.Linq;
using System;
using Newtonsoft.Json;
using LiteApp.Common;

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

        public App ApplySettings(App app, Module moduleToSave)
        {
            var cnv = new JsonModuleConverter();

            foreach (var page in app.Pages)
            {
                foreach (var row in page.Rows)
                {
                    foreach (var col in row.Cols)
                    {
                        for (int i = 0; i < col.Modules.Count; i++)
                        {
                            if (col.Modules[i].Id == moduleToSave.Id)
                            {
                                col.Modules[i] = JsonConvert.DeserializeObject(
                                    JsonConvert.SerializeObject(moduleToSave, Formatting.Indented, cnv), 
                                    moduleToSave.GetType(),
                                    cnv
                                ) as dynamic;

                                return app;
                            }
                        }
                    }
                }
            }

            return app;
        }

        public string GetSchema()
        {
            return _appData.Schema();
        }

        public Page GetCurrentPage(string route)
        {
            var compareValue = route.ToLower().TrimEnd(new char[] { ' ', '?' }).TrimStart('/');

            if (string.IsNullOrWhiteSpace(compareValue))
            {
                compareValue = "home";
            }
            return _app.Pages.FirstOrDefault(o => o.Name.ToLower() == compareValue);
        }

        public Module GetModule(string moduleId)
        {
            return _app.Pages
                .SelectMany(p => p.Rows)
                .SelectMany(r => r.Cols)
                .SelectMany(c => c.Modules)
                .FirstOrDefault(m => m.Id == moduleId);
        }
    }
}
