using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightProject.Models
{
    public class Flight2000
    {
        [Column("YEAR")]
        public int Year { get; set; }

        [Column("MONTH", Order = 1)]
        public int Month { get; set; }

        [Column("DAYOFMONTH", Order = 2)]
        public int DayofMonth { get; set; }

        [Column("DAYOFWEEK")]
        public int DayofWeek { get; set; }

        [Column("DEPTIME", Order = 3)]
        public int DepartureTime { get; set; }

        [Column("CRSDEPTIME")]
        public int CrsDepartTime { get; set; }

        [Column("ARRTIME")]
        public int ArrivalTime { get; set; }

        [Column("CRSARRTIME")]
        public int CrsArrivalTime { get; set; }

        [Column("UNIQUECARRIER", Order = 4)]
        public string UniqueCarrier { get; set; }

        [Column("FLIGHTNUM", Order = 5)]
        public int FlightNumber { get; set; }

        [Column("TAILNUM")]
        public string TailNumber { get; set; }

        [Column("ACTUALELAPSEDTIME")]
        public int ActualElapsedTime { get; set; }

        [Column("CRSELAPSEDTIME")]
        public int CrsElaspedTime { get; set; }

        [Column("AIRTIME")]
        public int Airtime { get; set; }

        [Column("ARRDELAY")]
        public int ArrivalDelay { get; set; }

        [Column("DRPDELAY")]
        public int DepartureDelay { get; set; }

        [Column("ORIGIN")]
        public string Origin { get; set; }

        [Column("DEST")]
        public string Destination { get; set; }

        [Column("DISTANCE")]
        public int Distance { get; set; }

        [Column("TAXIIN")]
        public int TaxiIn { get; set; }

        [Column("TAXIOUT")]
        public int TaxiOut { get; set; }

        [Column("CANCELLED")]
        public int Cancelled { get; set; }

        [Column("CANCELLATIONCODE")]
        public string CancellationCode { get; set; }

        [Column("DIVERTED")]
        public int Diverted { get; set; }

        [Column("CARRIERDELAY")]
        public string CarrierDelay { get; set; }

        [Column("WEATHERDELAY")]
        public string WeatherDelay { get; set; }

        [Column("NASDELAY")]
        public string NasDelay { get; set; }

        [Column("SECURITYDELAY")]
        public string SecurityDelay { get; set; }

        [Column("LATEAIRCRAFTDELAY")]
        public string LateAircraftDelay { get; set; }




















    }
}
