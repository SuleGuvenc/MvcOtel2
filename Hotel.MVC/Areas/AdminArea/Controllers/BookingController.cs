using AutoMapper;
using Hotel.MVC.DTO.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
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
        
        private HotelManager hotelManager;
        private RoomManager roomManager;
        private BookingManager bookingManager;
        private UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public BookingController(UserManager<AppUser> userManager, IMapper mapper)
        {
            bookingManager = new BookingManager();
            hotelManager = new HotelManager();
            roomManager = new RoomManager();
            this.userManager = userManager;
            this.mapper = mapper;
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
            var user = userManager.Users.ToList().Select(p => new SelectListItem { Text = p.UserName, Value = p.Id });

            ViewBag.Hotels = hotel;
            ViewBag.Rooms = room;
            ViewBag.Users = user;
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // GET: ProductController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            BookingCreateDTO createDTO = new();
            var room = roomManager.GetAllAsync().Result.Select(p => new SelectListItem { Text = p.RoomNo, Value = p.Id.ToString() });
            var hotel = hotelManager.GetAllAsync().Result.Select(p => new SelectListItem { Text = p.HotelName, Value = p.Id.ToString() });
            var user = userManager.Users.ToList().Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });

            ViewBag.Rooms = room;
            ViewBag.Hotels = hotel;
            ViewBag.Users = user;
            return View(createDTO);
        }

        // POST: ProductController/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookingCreateDTO createDTO)
        {
            if (ModelState.IsValid)
            {
                //var path = Path.Combine(hostEnvironment.WebRootPath, "images_product");
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(path);
                //}

                //var filename = Path.Combine(path, createDTO.ProductPhoto.FileName);

                //using (var filetrans = new FileStream(filename, FileMode.Create))
                //{
                //    await createDTO.ProductPhoto.CopyToAsync(filetrans);
                //}

                //createDTO.ProductPhotoName = createDTO.ProductPhoto.FileName;

                var result = mapper.Map<Booking>(createDTO);
                await bookingManager.InsertAsync(result);
                return RedirectToAction(nameof(Index));
            }
            return View(createDTO);
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
