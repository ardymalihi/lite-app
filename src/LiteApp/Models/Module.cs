using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteApp.Models
{
    public class Module
    {
        public string Type
        {
            get
            {
                return this.GetType().Name;
            }
        }
        
    }
}
