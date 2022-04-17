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
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {
            var list = await _context.AirlineAve.ToListAsync();
            return Ok(list);
        }
    }
}

