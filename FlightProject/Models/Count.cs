using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class Count
    {
        [Column("year")]
        public int Year { get; set; }
        [Column("AmericanCount")]
        public int AmericanCount { get; set; }
        [Column("DeltaCount")]
        public int DeltaCount { get; set; }
        [Column("UnitedCount")]
        public int UnitedCount { get; set; }

    }
}
