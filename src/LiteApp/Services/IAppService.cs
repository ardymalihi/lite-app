using LiteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Services
{
    public interface IAppService
    {
        App App { get; }

        void Save(App app);

        Page GetCurrentPage(string route);
    }
}
