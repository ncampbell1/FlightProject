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
    public class DelayTrendsController : Controller
    {
        private readonly SchoolContext _context;

        public DelayTrendsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Airlines
        public async Task<IActionResult> Index()
        {
            var list = await _context.DelayTrend.ToListAsync();
            return View(list);
        }
        [Produces("application/json")]
        public async Task<IActionResult> FindAll()
        {

            var list2000 = (await _context.DelayTrend2000.ToListAsync()).ToList();
            var list2001 = (await _context.DelayTrend2001.ToListAsync()).ToList();
            var list2002 = (await _context.DelayTrend2002.ToListAsync()).ToList();
            for (int i = 0; i < list2000.Count; i++)
            {
                list2000[i].ArrDelay2001 = list2001[i].ArrDelay2001;
                list2000[i].ArrDelay2002 = list2002[i].ArrDelay2002;
                list2000[i].DeptDelay2001 = list2001[i].DeptDelay2001;
                list2000[i].DeptDelay2002 = list2002[i].DeptDelay2002;

            }

            return Ok(list2000);
        }
    }
}
