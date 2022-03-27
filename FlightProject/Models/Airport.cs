using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class Airport
    {
        [Key]
        [Column("AIRPORT_CODE")]
        public string AirportCode { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("CITY")]
        public string City { get; set; }
        [Column("STATE")]
        public string State { get; set; }



    }
}
