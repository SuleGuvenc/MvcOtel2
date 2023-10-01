using Microsoft.AspNetCore.Mvc;

namespace Otel.Mvc.Web.Controllers
{
    public class EmployeeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
