using Microsoft.AspNetCore.Mvc;

namespace Hotel.MVC.Areas.MembersArea.Controllers
{
    
    
    [Area("MembersArea")]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}
