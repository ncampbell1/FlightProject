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
    public class AirlineAvesController : Controller
    {

        private readonly SchoolContext _context;
        private static string _id = "";

        public AirlineAvesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            var list = await _context.AirlineAve.ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(String id)
        {
            _id = id;
            var airline = await _context.Airline.FirstOrDefaultAsync(x => x.CarrierCode== id);
            if (airline == null)
            {
                return View("AirlineNotFound", id);
            }

            var delays = (await _context.AirlineAve.ToListAsync()).Where(x => x.CarrierCode == airline.CarrierCode).ToList();
            return View("Index", delays);
        }
        
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
           
            var list2000 = (await _context.AirlineAve2000.ToListAsync()).Where(x => x.CarrierCode == _id).ToList();
            var list2001 = (await _context.AirlineAve2001.ToListAsync()).Where(x => x.CarrierCode == _id).ToList();
            var list2002 = (await _context.AirlineAve2002.ToListAsync()).Where(x => x.CarrierCode == _id).ToList();
            for (int i = 0; i < list2000.Count; i++)
            {
                list2000[i].ArrivalDelay2001 = list2001[i].ArrivalDelay2001;
                list2000[i].ArrivalDelay2002 = list2002[i].ArrivalDelay2002;
            }
            
            return Ok(list2000);
        }
    }
}


