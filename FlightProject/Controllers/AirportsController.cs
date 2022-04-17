using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using FlightProject.Models;

namespace FlightProject.Controllers
{
    public class AirportsController : Controller
    {
        private readonly SchoolContext _context;

        public AirportsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airport.ToListAsync());
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.AirportCode == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AirportCode,Name,City,State")] Airport airport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airport);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GotoDetails([Bind("AirportCode,Name,City,State")] Airport airport)
        {
            var savedAirport = await _context.Airport.FirstOrDefaultAsync(x => x.AirportCode == airport.AirportCode);
            if (savedAirport == null)
            {
                ModelState.AddModelError("AirportCode", "Not found");
                return View("Create", airport);
            }
            else
            {
                return RedirectToAction("Details", "MaxAirports", new { id = airport.AirportCode });

            }
           
        }


        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            return View(airport);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AirportCode,Name,City,State")] Airport airport)
        {
            if (id != airport.AirportCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirportExists(airport.AirportCode))
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
            return View(airport);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airport = await _context.Airport
                .FirstOrDefaultAsync(m => m.AirportCode == id);
            if (airport == null)
            {
                return NotFound();
            }

            return View(airport);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var airport = await _context.Airport.FindAsync(id);
            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirportExists(string id)
        {
            return _context.Airport.Any(e => e.AirportCode == id);
        }
    }
}
