using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class Airline
    {
        [Key]
        [Column("CARRIER_CODE")]
        public string CarrierCode { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
    }
}
