using Microsoft.AspNetCore.Mvc;

namespace Otel.Mvc.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
