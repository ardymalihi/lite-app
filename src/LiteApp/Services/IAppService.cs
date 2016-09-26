using LiteApp.Models;

namespace LiteApp.Services
{
    public interface IAppService
    {
        App App { get; }

        void Save(App app);

        string GetSchema();

        Page GetCurrentPage(string route);

        Module GetModule(string moduleId);

        App ApplySettings(App app, Module moduleToSave);

        App RemoveModule(App app, Module moduleToSave);
    }
}
