using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otel.BL.Abstract;
using Otel.Entitiy.Concrete;

namespace Hotel.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IBookingManager bookingManager;

        public HomeController(IBookingManager bookingManager)
        {
            this.bookingManager = bookingManager;
        }


        public  async  Task<IActionResult> Index()
        {
            List<Booking> booking = (List<Booking>)await bookingManager.GetAllAsync();


            return View(booking);
        }

       
    }
}
