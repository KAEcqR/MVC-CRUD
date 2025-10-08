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


        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(Event evt, IFormFile ImageFile)
        {
            Console.WriteLine(ImageFile);
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

                    evt.ImagePath = uniqueFileName;
                }

                _context.Events.Add(evt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(evt);
        }

        [HttpGet]
        public IActionResult RemoveEvent(int Id)
        {
                var eventToRemove = _context.Events.Find(Id);
                if (eventToRemove == null)
                {
                    return NotFound();
                }
                _context.Events.Remove(eventToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveEvent()
        {
            return View();
        }
    }
}
