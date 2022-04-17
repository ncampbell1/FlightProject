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
    public class AirportAvgsController : Controller
    {
            private readonly SchoolContext _context;

            public AirportAvgsController(SchoolContext context)
            {
                _context = context;
            }

            // GET: Airlines
            public async Task<IActionResult> Index()
            {
                var list = await _context.AirportAvg.ToListAsync();
                return View(list);
            }

        [HttpGet]
        public async Task<IActionResult> Details(String id)
        {
            var airport = await _context.Airport.FirstOrDefaultAsync(x => x.AirportCode == id);
            if (airport == null)
            {
                return View("AirportNotFound", id);
            }

            var delays = (await _context.AirportAvg.ToListAsync()).Where(x => x.Name == airport.Name).ToList();
            return View("Index", delays);
        }
    }
}
