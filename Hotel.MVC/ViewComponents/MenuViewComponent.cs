using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Otel.BL.Abstract;
using Otel.BL.Concrete;
using Otel.Entity.Authentication;
using System.Security.Claims;

namespace Hotel.MVC.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMenuManager menuManager;

        public MenuViewComponent(UserManager<AppUser> userManager,IMenuManager menuManager)
        {
            this.userManager = userManager;
            this.menuManager = menuManager;
        }

        public IMenuManager MenuManager { get; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userRole = HttpContext.User.FindFirstValue(ClaimTypes.Role);




            var result = menuManager.GetAllInclude(p => p.AppRole.Name== userRole, p => p.AppRole).Result.ToList();



            return View(result);
        }
    }
}
