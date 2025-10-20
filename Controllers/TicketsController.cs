using Microsoft.AspNetCore.Authorization;
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

        public TicketsController(AppDbContext context)
        {
            _context = context;
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
    }
}
