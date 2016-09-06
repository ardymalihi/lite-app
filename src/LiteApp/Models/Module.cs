
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
