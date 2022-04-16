using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class AirportAvg
    {
        [Column("NAME")]
        public string Name { get; set; }
        [Column("YEAR")]
        public int Year { get; set; }
        [Column("MONTH")]
        public int Month { get; set; }
        [Column("ArrivalDelay")]
        public float ArrivalDelay { get; set; }
    }
}
