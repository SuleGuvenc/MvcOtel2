using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Otel.Entity.Authentication;

namespace Hotel.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {

        public MenuViewComponent(UserManager<AppUser> userManager)
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
