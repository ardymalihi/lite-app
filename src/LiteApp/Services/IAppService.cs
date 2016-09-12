using LiteApp.Models;

namespace LiteApp.Services
{
    public interface IAppService
    {
        App App { get; }

        void Save(App app);

        Page GetCurrentPage(string route);

        Module GetModule(string moduleId);
        
    }
}
