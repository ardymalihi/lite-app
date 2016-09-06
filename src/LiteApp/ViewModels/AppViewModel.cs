using LiteApp.Models;

namespace LiteApp.ViewModels
{
    public class AppViewModel
    {
        public App App { get; set; }

        public Page CurrentPage { get; set; }

        public UserProfileViewModel UserProfile { get; set; }
    }
}
