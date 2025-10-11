using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class VenuesController : Controller
    {

        private readonly AppDbContext _context;
        public VenuesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VenuesController
        public ActionResult Index()
        {
            var venues = _context.Venues
                .Include(v => v.Events).ToList();
            return View(venues);
        }

        [HttpGet]
        public IActionResult RemoveVenue(int Id)
        {
            var venue = _context.Venues.Find(Id);
            if (venue != null)
            {
                _context.Venues.Remove(venue);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddVenue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVenue(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        [HttpGet]
        public IActionResult EditVenue(int Id)
        {
            var venue = _context.Venues.Find(Id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        public IActionResult EditVenue(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Update(venue);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }
    }
}
