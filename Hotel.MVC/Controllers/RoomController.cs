using Microsoft.AspNetCore.Mvc;
using Otel.BL.Abstract;

namespace Hotel.MVC.Controllers
{
	public class RoomController : Controller
	{
		private readonly IRoomManager roomManager;

		public RoomController(IRoomManager roomManager)
        {
			this.roomManager = roomManager;
		}
        public async Task<IActionResult> Index()
		{
			var rooms = await roomManager.GetAllAsync(p=>p.IsEmpty == true);
			return View(rooms);
		}
		
	}
}
