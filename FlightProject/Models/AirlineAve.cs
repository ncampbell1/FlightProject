using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public float? ArrivalDelay { get; set; }
        
    }
    public class AirlineAve2000
    {
        [Column("CarrierCode")]
        public string CarrierCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }
        /*[Column("ArrivalDelay")]
        public float? ArrivalDelay { get; set; }*/
        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
    public class AirlineAve2001
    {
        [Column("CarrierCode")]
        public string CarrierCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }
        /*[Column("ArrivalDelay")]
        public float? ArrivalDelay { get; set; }*/
        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
    public class AirlineAve2002
    {
        [Column("CarrierCode")]
        public string CarrierCode { get; set; }

        [Column("Month")]
        public int Month { get; set; }
        /*[Column("ArrivalDelay")]
        public float? ArrivalDelay { get; set; }*/
        [Column("arrdelay2000")]
        public float? ArrivalDelay2000 { get; set; }
        [Column("arrdelay2001")]
        public float? ArrivalDelay2001 { get; set; }

        [Column("arrdelay2002")]
        public float? ArrivalDelay2002 { get; set; }
    }
}
