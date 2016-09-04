using LiteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Data
{
    public interface IAppData
    {
        App Load();

        void Save(App app);
    }
}
