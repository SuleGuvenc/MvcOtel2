using AutoMapper;
using Hotel.MVC.Areas.AdminArea.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otel.BL.Abstract;
using Otel.DAL.Contents;
using Otel.Entitiy.Concrete;

namespace Hotel.MVC.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin,User")]
    public class HotelsController : Controller
    {
        
        private readonly IHotelManager hotelManager;
        private readonly IMapper mapper;

        public HotelsController(IHotelManager hotelManager,IMapper mapper)
        {
            
            this.hotelManager = hotelManager;
            this.mapper = mapper;
        }

        // GET: AdminArea/Hotels
        public async Task<IActionResult> Index()
        {
            var oteller = hotelManager.GetAllAsync();
            return View(oteller);
        }

        // GET: AdminArea/Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.Hotels == null)
            //{
            //    return NotFound();
            //}

            //var hotel = await _context.Hotels
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: AdminArea/Hotels/Create
        public IActionResult Create()
        {
            HotelCreateDTO createDTO = new HotelCreateDTO();
            return View(createDTO);
        }

        // POST: AdminArea/Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelCreateDTO createDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(createDTO);
            }
            var hotel = mapper.Map<Otel.Entitiy.Concrete.Hotel>(createDTO);
            await hotelManager.InsertAsync(hotel);
            
            return RedirectToAction(nameof(Index));
           
        }

        // GET: AdminArea/Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null || _context.Hotels == null)
            //{
            //    return NotFound();
            //}

            //var hotel = await _context.Hotels.FindAsync(id);
            //if (hotel == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        // POST: AdminArea/Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adres,PostaCode,HotelName,HotelCity,HotelCountry,Gsm,Id,CreateDate")] Otel.Entitiy.Concrete.Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: AdminArea/Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hotels == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: AdminArea/Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'SqlDbContext.Hotels'  is null.");
            }
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
          return (_context.Hotels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
