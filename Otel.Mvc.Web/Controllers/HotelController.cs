using Microsoft.AspNetCore.Mvc;

namespace Otel.Mvc.Web.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
