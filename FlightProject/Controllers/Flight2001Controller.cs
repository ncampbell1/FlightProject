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
    public class Flight2001Controller : Controller
    {
        private readonly SchoolContext _context;

        public Flight2001Controller(SchoolContext context)
        {
            _context = context;
        }

        // GET: Flight2001
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flight2001.ToListAsync());
        }

        // GET: Flight2001/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight2001 = await _context.Flight2001
                .FirstOrDefaultAsync(m => m.Month == id);
            if (flight2001 == null)
            {
                return NotFound();
            }

            return View(flight2001);
        }

        // GET: Flight2001/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flight2001/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Year,Month,DayofMonth,DayofWeek,DepartureTime,CrsDepartTime,ArrivalTime,CrsArrivalTime,UniqueCarrier,FlightNumber,TailNumber,ActualElapsedTime,CrsElaspedTime,Airtime,ArrivalDelay,DepartureDelay,Origin,Destination,Distance,TaxiIn,TaxiOut,Cancelled,CancellationCode,Diverted,CarrierDelay,WeatherDelay,NasDelay,SecurityDelay,LateAircraftDelay")] Flight2001 flight2001)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight2001);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight2001);
        }

        // GET: Flight2001/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight2001 = await _context.Flight2001.FindAsync(id);
            if (flight2001 == null)
            {
                return NotFound();
            }
            return View(flight2001);
        }

        // POST: Flight2001/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Year,Month,DayofMonth,DayofWeek,DepartureTime,CrsDepartTime,ArrivalTime,CrsArrivalTime,UniqueCarrier,FlightNumber,TailNumber,ActualElapsedTime,CrsElaspedTime,Airtime,ArrivalDelay,DepartureDelay,Origin,Destination,Distance,TaxiIn,TaxiOut,Cancelled,CancellationCode,Diverted,CarrierDelay,WeatherDelay,NasDelay,SecurityDelay,LateAircraftDelay")] Flight2001 flight2001)
        {
            if (id != flight2001.Month)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight2001);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Flight2001Exists(flight2001.Month))
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
            return View(flight2001);
        }

        // GET: Flight2001/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight2001 = await _context.Flight2001
                .FirstOrDefaultAsync(m => m.Month == id);
            if (flight2001 == null)
            {
                return NotFound();
            }

            return View(flight2001);
        }

        // POST: Flight2001/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight2001 = await _context.Flight2001.FindAsync(id);
            _context.Flight2001.Remove(flight2001);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Flight2001Exists(int id)
        {
            return _context.Flight2001.Any(e => e.Month == id);
        }
    }
}
