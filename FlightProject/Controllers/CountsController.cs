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
    public class CountsController : Controller
    {

        private readonly SchoolContext _context;

        public CountsController(SchoolContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var list = await _context.Count.ToListAsync();
            return View(list);
        }
    }
}
