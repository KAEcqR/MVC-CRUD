using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class TicketsController : Controller
    {
        // GET: TicketsController
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketsController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult BuyTicket(int id)
        {
            var evt = _context.Events.FirstOrDefault(e => e.Id == id);
            if (evt == null)
            {
                return NotFound();
            }
            ViewBag.Event = evt;
            return View();
        }

        [HttpPost]
        public ActionResult BuyTicket()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuyTicketConfirmed()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyTicketConfirmed(int id)
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var ticket = new Ticket
            {
                UserId = user.Id,
                EventId = evt.Id
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyTickets");
        }

        public async Task<IActionResult> MyTickets()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var tickets = await _context.Tickets
                .Include(t => t.Event)
                .Where(t => t.UserId == user.Id)
                .ToListAsync();

            return View(tickets);
        }
        
    }
}
