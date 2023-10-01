using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Otel.BL.Abstract;
using Otel.BL.Concrete;
using Otel.Entitiy.Concrete;
using Otel.Entity.Authentication;
using System.Data;

namespace Hotel.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class BookingController : Controller
    {
        private readonly IBookingManager bookingManager;
        private readonly UserManager<AppUser> userManager;
        
        private readonly IRoomManager roomManager;
        private readonly IHotelManager hotelManager;

        public BookingController(IBookingManager bookingManager,UserManager<AppUser> userManager,HotelManager hotelManager,RoomManager roomManager)
        {
            this.bookingManager = bookingManager;
            this.userManager = userManager;
            this.hotelManager = hotelManager;
            this.roomManager = roomManager;
        }
        public async Task<IActionResult> Index()
        {


            List<Booking> booking = (List<Booking>)await bookingManager.GetAllAsync();          


            return View(booking);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var booking = await bookingManager.GetByIdAsync(id);
            var hotel = hotelManager.GetAllAsync().Result.Select(p => new SelectListItem { Text = p.HotelName, Value = p.Id.ToString() });
            var room = roomManager.GetAllAsync().Result.Select(p => new SelectListItem { Text = p.RoomNo, Value = p.Id.ToString() });

            ViewBag.Hotel = hotel;
            ViewBag.Room = room;
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await bookingManager.UpdateAsync(booking);
                }
                catch (Exception ex)
                {
                    if (await bookingManager.GetByIdAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }
    }
}
