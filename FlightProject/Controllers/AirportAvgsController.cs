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
            private static string _id = "";
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
            _id = id;
            var airport = await _context.Airport.FirstOrDefaultAsync(x => x.AirportCode == id);
            if (airport == null)
            {
                return View("AirportNotFound", id);
            }

            var delays = (await _context.AirportAvg.ToListAsync()).Where(x => x.Name == airport.Name).ToList();
            return View("Index", delays);
        }
        
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {

            var list2000 = (await _context.AirportAvg2000.ToListAsync()).Where(x => x.AirportCode == _id).ToList();
            var list2001 = (await _context.AirportAvg2001.ToListAsync()).Where(x => x.AirportCode == _id).ToList();
            var list2002 = (await _context.AirportAvg2002.ToListAsync()).Where(x => x.AirportCode == _id).ToList();
            for (int i = 0; i < list2000.Count; i++)
            {
                list2000[i].ArrivalDelay2001 = list2001[i].ArrivalDelay2001;
                list2000[i].ArrivalDelay2002 = list2002[i].ArrivalDelay2002;
            }

            return Ok(list2000);
        }
    }
}
