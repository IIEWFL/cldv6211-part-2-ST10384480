using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventVenueBookingSystem.Data;
using EventVenueBookingSystem.Models;

namespace EventVenueBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly eventvenuebookingsystemDbContext _context;

        public BookingController(eventvenuebookingsystemDbContext context)
        {
            _context = context;
        }

        // GET: Booking1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking1s.ToListAsync());
        }

        // GET: Booking1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking1 = await _context.Booking1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking1 == null)
            {
                return NotFound();
            }

            return View(booking1);
        }

        // GET: Booking1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booking1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,BookingDate,EventId,VenueId")] Booking1 booking1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booking1);
        }

        // GET: Booking1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking1 = await _context.Booking1s.FindAsync(id);
            if (booking1 == null)
            {
                return NotFound();
            }
            return View(booking1);
        }

        // POST: Booking1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,BookingDate,EventId,VenueId")] Booking1 booking1)
        {
            if (id != booking1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Booking1Exists(booking1.Id))
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
            return View(booking1);
        }

        // GET: Booking1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking1 = await _context.Booking1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking1 == null)
            {
                return NotFound();
            }

            return View(booking1);
        }

        // POST: Booking1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking1 = await _context.Booking1s.FindAsync(id);
            if (booking1 != null)
            {
                _context.Booking1s.Remove(booking1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Booking1Exists(int id)
        {
            return _context.Booking1s.Any(e => e.Id == id);
        }
    }
}
