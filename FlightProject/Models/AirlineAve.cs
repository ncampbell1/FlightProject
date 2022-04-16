using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace FlightProject.Models
{
    public class AirlineAve
    {
        [Column("CarrierCode")]
        public string CarrierCode { get; set; }
        [Column("Year")]
        public int Year { get; set; }
        [Column("Month")]
        public int Month { get; set; }
        [Column("ArrivalDelay")]
        public float ArrivalDelay { get; set; }

    }
}
