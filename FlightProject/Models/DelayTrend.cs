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
    
    public class DelayTrend2000
    {
        [Column("Month")]
        public int Month { get; set; }
        [Column("ArrivalDelay2000")]
        public float ArrDelay2000 { get; set; }
        [Column("DepartureDelay2000")]
        public float DeptDelay2000 { get; set; }
        [Column("ArrivalDelay2001")]
        public float ArrDelay2001 { get; set; }
        [Column("DepartureDelay2001")]
        public float DeptDelay2001 { get; set; }
        [Column("ArrivalDelay2002")]
        public float ArrDelay2002 { get; set; }
        [Column("DepartureDelay2002")]
        public float DeptDelay2002 { get; set; }
    }

    public class DelayTrend2001
    {
        [Column("Month")]
        public int Month { get; set; }
        [Column("ArrivalDelay2000")]
        public float ArrDelay2000 { get; set; }
        [Column("DepartureDelay2000")]
        public float DeptDelay2000 { get; set; }
        [Column("ArrivalDelay2001")]
        public float ArrDelay2001 { get; set; }
        [Column("DepartureDelay2001")]
        public float DeptDelay2001 { get; set; }
        [Column("ArrivalDelay2002")]
        public float ArrDelay2002 { get; set; }
        [Column("DepartureDelay2002")]
        public float DeptDelay2002 { get; set; }
    }

    public class DelayTrend2002
    {
        [Column("Month")]
        public int Month { get; set; }
        [Column("ArrivalDelay2000")]
        public float ArrDelay2000 { get; set; }
        [Column("DepartureDelay2000")]
        public float DeptDelay2000 { get; set; }
        [Column("ArrivalDelay2001")]
        public float ArrDelay2001 { get; set; }
        [Column("DepartureDelay2001")]
        public float DeptDelay2001 { get; set; }
        [Column("ArrivalDelay2002")]
        public float ArrDelay2002 { get; set; }
        [Column("DepartureDelay2002")]
        public float DeptDelay2002 { get; set; }
    }
}
