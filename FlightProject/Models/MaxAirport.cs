using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class MaxAirport
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("ArrivalDelay")]
        public float ArrivalDelay { get; set; }
        [Column("Month")]
        public int Month { get; set; }
        [Column("Year")]
        public int Year { get; set; }
    }
}
