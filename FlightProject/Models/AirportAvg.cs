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
    public class AirportAvg2000
    {
        [Column("AirportCode")]
        public string AirportCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }

        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
    public class AirportAvg2001
    {
        [Column("AirportCode")]
        public string AirportCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }

        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
    public class AirportAvg2002
    {
        [Column("AirportCode")]
        public string AirportCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }

        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
}
