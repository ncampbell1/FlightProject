using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class DelayTrend
    {
        [Column("ArrivalDelay")]
        public float ArrivalDelay { get; set; }
        [Column("DepartDelay")]
        public float DepartDelay { get; set; }
        [Column("Month")]
        public int Month { get; set; }
        [Column("Year")]
        public int Year { get; set; }
    }
}
