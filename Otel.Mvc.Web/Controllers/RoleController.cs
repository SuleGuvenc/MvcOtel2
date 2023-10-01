using Microsoft.AspNetCore.Mvc;

namespace Otel.Mvc.Web.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
