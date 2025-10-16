using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class EventsController : Controller
    {

        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .ToListAsync();

            return View(events);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddEvent()
        {
            var venues = _context.Venues.ToList();
            ViewBag.Venues = venues;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event evt, IFormFile ImageFile)
        {
            Console.WriteLine(ImageFile);
            evt.TicketsLeft = evt.TotalTickets;
            evt.CreationDate = DateOnly.FromDateTime(DateTime.Now);
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/events");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    evt.ImagePath = uniqueFileName;
                }

                _context.Events.Add(evt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            // FIX: Set ViewBag.Venues before returning the view
            ViewBag.Venues = _context.Venues.ToList();
            return View(evt);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RemoveEvent(int Id)
        {
            var ev = _context.Events.Find(Id);
            if (ev == null || ev.ImagePath == null)
            {
                return NotFound();
            }
            _context.Events.Remove(ev);
            _context.SaveChanges();

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/events", ev.ImagePath);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RemoveEvent()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            var ev = _context.Events.Find(id);
            var venues = _context.Venues.ToList();
            ViewBag.Venues = venues;
            if (ev != null)
            {
                return View(ev);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditEvent(Event ev, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/events");
                    Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    ev.ImagePath = uniqueFileName;
                }
                else
                {
                    // No new image uploaded, keep previous image
                    var existingEvent = _context.Events.AsNoTracking().FirstOrDefault(e => e.Id == ev.Id);
                    if (existingEvent != null)
                    {
                        ev.ImagePath = existingEvent.ImagePath; // keep the existing image path
                        Console.WriteLine("No new image uploaded, previous image is used.");
                    }
                }

                _context.Events.Update(ev);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Venues = _context.Venues.ToList();
            return View(ev);
        }

        [HttpGet]
        public IActionResult DetailsEvent(int id)
        {
            var evt = _context.Events
                .Include(e => e.Venue)
                .FirstOrDefault(e => e.Id == id);

            if (evt == null)
            {
                return NotFound();
            }

            return View(evt);
        }

        [HttpPost]
        public IActionResult EventDetails()
        {
            return View();
        }

    }
}
