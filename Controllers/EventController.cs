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
    public class EventController : Controller
    {
        private readonly eventvenuebookingsystemDbContext _context;

        public EventController(eventvenuebookingsystemDbContext context)
        {
            _context = context;
        }

        // GET: Event1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event1s.ToListAsync());
        }

        // GET: Event1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event1 = await _context.Event1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (event1 == null)
            {
                return NotFound();
            }

            return View(event1);
        }

        // GET: Event1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date")] Event1 event1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(event1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(event1);
        }

        // GET: Event1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event1 = await _context.Event1s.FindAsync(id);
            if (event1 == null)
            {
                return NotFound();
            }
            return View(event1);
        }

        // POST: Event1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date")] Event1 event1)
        {
            if (id != event1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(event1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Event1Exists(event1.Id))
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
            return View(event1);
        }

        // GET: Event1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event1 = await _context.Event1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (event1 == null)
            {
                return NotFound();
            }

            return View(event1);
        }

        // POST: Event1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var event1 = await _context.Event1s.FindAsync(id);
            if (event1 != null)
            {
                _context.Event1s.Remove(event1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Event1Exists(int id)
        {
            return _context.Event1s.Any(e => e.Id == id);
        }
    }
}
