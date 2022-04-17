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
    public class MaxAirlinesController : Controller
    {
        private readonly SchoolContext _context;

        public MaxAirlinesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            var list = await _context.MaxAirline.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(String id)
        {
            var airline = await _context.Airline.FirstOrDefaultAsync(x => x.CarrierCode == id);
            if (airline == null)
            {
                return View("AirlineNotFound", id);
            }

            var delays = (await _context.MaxAirline.ToListAsync()).Where(x => x.Name == airline.Name).ToList();
            return View("Index", delays);
        }
    }


}
