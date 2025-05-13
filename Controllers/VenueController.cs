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
    public class VenueController : Controller
    {
        private readonly eventvenuebookingsystemDbContext _context;

        public VenueController(eventvenuebookingsystemDbContext context)
        {
            _context = context;
        }

        // GET: Venue1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Venue1s.ToListAsync());
        }

        // GET: Venue1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue1 = await _context.Venue1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue1 == null)
            {
                return NotFound();
            }

            return View(venue1);
        }

        // GET: Venue1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venue1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Capacity")] Venue1 venue1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venue1);
        }

        // GET: Venue1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue1 = await _context.Venue1s.FindAsync(id);
            if (venue1 == null)
            {
                return NotFound();
            }
            return View(venue1);
        }

        // POST: Venue1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,Capacity")] Venue1 venue1)
        {
            if (id != venue1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Venue1Exists(venue1.Id))
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
            return View(venue1);
        }

        // GET: Venue1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue1 = await _context.Venue1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue1 == null)
            {
                return NotFound();
            }

            return View(venue1);
        }

        // POST: Venue1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venue1 = await _context.Venue1s.FindAsync(id);
            if (venue1 != null)
            {
                _context.Venue1s.Remove(venue1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Venue1Exists(int id)
        {
            return _context.Venue1s.Any(e => e.Id == id);
        }
    }
}
