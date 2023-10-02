using Microsoft.AspNetCore.Mvc;
using Otel.BL.Abstract;
using Otel.DAL.Contents;
using System.Data.Entity;

namespace Hotel.MVC.Controllers
{
    public class HotelController : Controller
    {


        private readonly IHotelManager hotelManager;
        private readonly SqlDbContext context;
		private readonly IRoomManager roomManager;

		public HotelController(IHotelManager hotelManager, SqlDbContext context,IRoomManager roomManager)
        {
            this.hotelManager = hotelManager;
            this.context = context;
			this.roomManager = roomManager;
		}
        public async Task<IActionResult> Index()
        {
            //odalar gelmiyor
            var hotels = context.Hotels.Include(x => x.Rooms).ToList();


            return View(hotels);
        }

		public async Task<IActionResult> Details(int id)
		{

            var hotel = await hotelManager.GetByIdAsync(id);

            var rooms = await roomManager.GetAllAsync(x => x.HotelId == id && x.IsEmpty == true);


            ViewBag.Rooms = rooms;
            if(hotel == null)
            {
               return NotFound();
            }

			return View(hotel);
		}

	}
}
