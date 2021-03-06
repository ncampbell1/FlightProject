using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using FlightProject.Models;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Airline>().ToTable("AIRLINES");
            modelBuilder.Entity<Airport>().ToTable("AIRPORTS");
            modelBuilder.Entity<Flight2000>().ToTable("FLIGHTS2000").HasKey(x => new { x.Month, x.DayofMonth, x.DepartureTime, x.UniqueCarrier, x.FlightNumber });
            modelBuilder.Entity<Flight2001>().ToTable("FLIGHTS2001").HasKey(x => new { x.Month, x.DayofMonth, x.DepartureTime, x.UniqueCarrier, x.FlightNumber });
            modelBuilder.Entity<Flight2002>().ToTable("FLIGHTS2002").HasKey(x => new { x.Month, x.DayofMonth, x.DepartureTime, x.UniqueCarrier, x.FlightNumber });
            
            var airlineAveQuery = "SELECT a.carrier_code CarrierCode, AVG(f0.arrdelay) ArrivalDelay, month, 2000 as year " + 
                    "FROM airlines a " +
                    "JOIN flights2000 f0 ON f0.uniquecarrier = a.carrier_code " +
                    "GROUP BY a.carrier_code, month " +
                    "UNION " +
                    "SELECT a1.carrier_code CarrierCode, AVG(f1.arrdelay) ArrivalDelay, month, 2001 as year " +
                    "FROM airlines a1 " +
                    "JOIN flights2001 f1 ON f1.uniquecarrier = a1.carrier_code " +
                    "GROUP BY a1.carrier_code, month " +
                    "UNION " +
                    "SELECT a2.carrier_code CarrierCode, AVG(f2.arrdelay) ArrivalDelay, month, 2002 as year " +
                    "FROM airlines a2 " +
                    "JOIN flights2002 f2 ON f2.uniquecarrier = a2.carrier_code " +
                    "GROUP BY a2.carrier_code, month " +
                    "ORDER BY year, month";
            modelBuilder.Entity<AirlineAve>().ToSqlQuery(airlineAveQuery).HasKey(x => new { x.Month, x.Year, x.CarrierCode });

            var airlineAves2000Query = "SELECT a.carrier_code CarrierCode, AVG(f0.arrdelay) arrdelay2000, month, 0 as arrdelay2001, 0 as arrdelay2002 " +
                "FROM airlines a " +
                "JOIN flights2000 f0 ON f0.uniquecarrier = a.carrier_code " +
                "GROUP BY carrier_code, month " +
                "ORDER BY month";
            modelBuilder.Entity<AirlineAve2000>().ToSqlQuery(airlineAves2000Query).HasKey(x => new { x.Month, x.CarrierCode });

            var airlineAves2001Query = "SELECT a.carrier_code CarrierCode, AVG(f1.arrdelay) arrdelay2001, month, 0 as arrdelay2000, 0 as arrdelay2002 " +
                "FROM airlines a " +
                "JOIN flights2001 f1 ON f1.uniquecarrier = a.carrier_code " +
                "GROUP BY carrier_code, month " +
                "ORDER BY month";
            modelBuilder.Entity<AirlineAve2001>().ToSqlQuery(airlineAves2001Query).HasKey(x => new { x.Month, x.CarrierCode });

            var airlineAves2002Query = "SELECT a.carrier_code CarrierCode, AVG(f2.arrdelay) arrdelay2002, month, 0 as arrdelay2000, 0 as arrdelay2001  " +
                "FROM airlines a " +
                "JOIN flights2002 f2 ON f2.uniquecarrier = a.carrier_code " +
                "GROUP BY carrier_code, month " +
                "ORDER BY month";
            modelBuilder.Entity<AirlineAve2002>().ToSqlQuery(airlineAves2002Query).HasKey(x => new { x.Month, x.CarrierCode });

            var airportAvgQuery = "SELECT a.name Name, AVG(f0.arrdelay) ArrivalDelay, month, 2000 as year " +
                    "FROM airports a " +
                    "JOIN flights2000 f0 ON f0.dest = a.airport_code " +
                    "GROUP BY a.name, month " +
                    "UNION " +
                    "SELECT a1.name Name, AVG(f1.arrdelay) ArrivalDelay, month, 2001 as year " +
                    "FROM airports a1 " +
                    "JOIN flights2001 f1 ON f1.dest = a1.airport_code " +
                    "GROUP BY a1.name, month " +
                    "UNION " +
                    "SELECT a2.name Name, AVG(f2.arrdelay) ArrivalDelay, month, 2002 as year " +
                    "FROM airports a2 " +
                    "JOIN flights2002 f2 ON f2.dest = a2.airport_code " +
                    "GROUP BY a2.name, month " +
                    "ORDER BY year, month";
            modelBuilder.Entity<AirportAvg>().ToSqlQuery(airportAvgQuery).HasKey(x => new { x.Month, x.Year, x.Name });

            var airportAvgQuery2000 = "SELECT a.airport_code AirportCode, AVG(f0.arrdelay) arrdelay2000, month, 0 as arrdelay2001, 0 as arrdelay2002 " +
                    "FROM airports a " +
                    "JOIN flights2000 f0 ON f0.dest = a.airport_code " +
                    "GROUP BY a.airport_code, month " +
                    "ORDER BY month";
            modelBuilder.Entity<AirportAvg2000>().ToSqlQuery(airportAvgQuery2000).HasKey(x => new { x.Month, x.AirportCode });

            var airportAvgQuery2001 = "SELECT a.airport_code AirportCode, AVG(f1.arrdelay) arrdelay2001, month, 0 as arrdelay2000, 0 as arrdelay2002 " +
                    "FROM airports a " +
                    "JOIN flights2001 f1 ON f1.dest = a.airport_code " +
                    "GROUP BY a.airport_code, month " +
                    "ORDER BY month";
            modelBuilder.Entity<AirportAvg2001>().ToSqlQuery(airportAvgQuery2001).HasKey(x => new { x.Month, x.AirportCode });

            var airportAvgQuery2002 = "SELECT a.airport_code AirportCode, AVG(f2.arrdelay) arrdelay2002, month, 0 as arrdelay2000, 0 as arrdelay2001 " +
                    "FROM airports a " +
                    "JOIN flights2002 f2 ON f2.dest = a.airport_code " +
                    "GROUP BY a.airport_code, month " +
                    "ORDER BY month";
            modelBuilder.Entity<AirportAvg2002>().ToSqlQuery(airportAvgQuery2002).HasKey(x => new { x.Month, x.AirportCode });

            var delayTrendQuery = "SELECT AVG(f0.arrdelay) ArrivalDelay, AVG(f0.drpdelay) DepartDelay, month, 2000 AS year " +
                "FROM flights2000 f0 " +
                "GROUP BY month, year " +
                "UNION " +
                "SELECT AVG(f1.arrdelay) ArrivalDelay, AVG(f1.drpdelay) DepartDelay, month, 2001 AS year " +
                "FROM flights2001 f1 " +
                "GROUP BY month, year " +
                "UNION " +
                "SELECT AVG(f2.arrdelay) arrival_delay, AVG(f2.drpdelay) DepartDelay, month, 2002 AS year " +
                "FROM flights2002 f2 " +
                "GROUP BY month, year " +
                "ORDER BY year, month";
            modelBuilder.Entity<DelayTrend>().ToSqlQuery(delayTrendQuery).HasKey(x => new { x.Month, x.Year, x.ArrivalDelay, x.DepartDelay });

            var delayTrendQuery2000 = "SELECT AVG(f0.arrdelay) ArrivalDelay2000, AVG(f0.drpdelay) DepartureDelay2000, month, 0 as ArrivalDelay2001, 0 as ArrivalDelay2002, 0 as DepartureDelay2001, 0 as DepartureDelay2002 " +
                "FROM flights2000 f0 " +
                "GROUP BY month " +
                "ORDER BY month";
            modelBuilder.Entity<DelayTrend2000>().ToSqlQuery(delayTrendQuery2000).HasKey(x => new {x.Month});

            var delayTrendQuery2001 = "SELECT AVG(f1.arrdelay) ArrivalDelay2001, AVG(f1.drpdelay) DepartureDelay2001, month, 0 as ArrivalDelay2000, 0 as ArrivalDelay2002, 0 as DepartureDelay2000, 0 as DepartureDelay2002 " +
                "FROM flights2001 f1 " +
                "GROUP BY month " +
                "ORDER BY month";
            modelBuilder.Entity<DelayTrend2001>().ToSqlQuery(delayTrendQuery2001).HasKey(x => new { x.Month });

            var delayTrendQuery2002 = "SELECT AVG(f2.arrdelay) ArrivalDelay2002, AVG(f2.drpdelay) DepartureDelay2002, month, 0 as ArrivalDelay2000, 0 as ArrivalDelay2001, 0 as DepartureDelay2000, 0 as DepartureDelay2001 " +
                "FROM flights2002 f2 " +
                "GROUP BY month " +
                "ORDER BY month";
            modelBuilder.Entity<DelayTrend2002>().ToSqlQuery(delayTrendQuery2002).HasKey(x => new { x.Month });


            var maxAirlineQuery = "SELECT a.name Name, MAX(f0.arrdelay) ArrivalDelay, max_carrier.month month, 2000 AS year " +
                "FROM airlines a " +
                "JOIN flights2000 f0 ON f0.uniquecarrier = a.carrier_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2000 f " +
                "GROUP BY f.month) max_carrier " +
                "WHERE max_carrier.max_delay = f0.arrdelay " +
                "GROUP BY a.name, max_carrier.month, year " +
                "UNION " +
                "SELECT a.name Name, MAX(f1.arrdelay) ArrivalDelay, max_carrier1.month month, 2001 AS year " +
                "FROM airlines a " +
                "JOIN flights2001 f1 ON f1.uniquecarrier = a.carrier_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2001 f " +
                "GROUP BY f.month) max_carrier1 " +
                "WHERE max_carrier1.max_delay = f1.arrdelay " +
                "GROUP BY a.name, max_carrier1.month, year " +
                "UNION " +
                "SELECT a.name Name, MAX(f2.arrdelay) ArrivalDelay, max_carrier2.month month, 2002 AS year " +
                "FROM airlines a " +
                "JOIN flights2002 f2 ON f2.uniquecarrier = a.carrier_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2001 f " +
                "GROUP BY f.month) max_carrier2 " +
                "WHERE max_carrier2.max_delay = f2.arrdelay " +
                "GROUP BY a.name, max_carrier2.month, year " +
                "ORDER BY year, month";
            modelBuilder.Entity<MaxAirline>().ToSqlQuery(maxAirlineQuery).HasKey(x => new { x.ArrivalDelay, x.Month, x.Year });

            var maxAirportQuery = "SELECT a.name Name, MAX(f0.arrdelay) ArrivalDelay, max_port.month month, 2000 AS year " +
                "FROM airports a " +
                "JOIN flights2000 f0 ON f0.dest = a.airport_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2000 f " +
                "GROUP BY f.month) max_port " +
                "WHERE max_port.max_delay = f0.arrdelay " +
                "GROUP BY a.name, max_port.month, year " +
                "UNION " +
                "SELECT a.name Name, MAX(f1.arrdelay) ArrivalDelay, max_port1.month month, 2001 AS year " +
                "FROM airports a " +
                "JOIN flights2001 f1 ON f1.dest = a.airport_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2001 f " +
                "GROUP BY f.month) max_port1 " +
                "WHERE max_port1.max_delay = f1.arrdelay " +
                "GROUP BY a.name, max_port1.month, year " +
                "UNION " +
                "SELECT a.name Name, MAX(f2.arrdelay) ArrivalDelay, max_port2.month month, 2002 AS year " +
                "FROM airports a " +
                "JOIN flights2002 f2 ON f2.dest = a.airport_code, " +
                "(SELECT MAX(f.arrdelay) max_delay, f.month " +
                "FROM flights2002 f " +
                "GROUP BY f.month) max_port2 " +
                "WHERE max_port2.max_delay = f2.arrdelay " +
                "GROUP BY a.name, max_port2.month, year " +
                "ORDER BY year, month";
            modelBuilder.Entity<MaxAirport>().ToSqlQuery(maxAirportQuery).HasKey(x => new { x.ArrivalDelay, x.Month, x.Year, x.Name });

            var count2000Query = "SELECT year, (SELECT COUNT(*) FROM flights2000 WHERE uniquecarrier = 'AA') AmericanCount, " +
                "(SELECT COUNT(*) FROM flights2000 WHERE uniquecarrier = 'DL') DeltaCount, " +
                "(SELECT COUNT(*) FROM flights2000 WHERE uniquecarrier = 'UA') UnitedCount " +
                "FROM flights2000 " +
                "UNION " +
                "SELECT year, (SELECT COUNT(*) FROM flights2001 WHERE uniquecarrier = 'AA') AmericanCount, " +
                "(SELECT COUNT(*) FROM flights2001 WHERE uniquecarrier = 'DL') DeltaCount, " +
                "(SELECT COUNT(*) FROM flights2001 WHERE uniquecarrier = 'UA') UnitedCount " +
                "FROM flights2001 " +
                "UNION " +
                "SELECT year, (SELECT COUNT(*) FROM flights2002 WHERE uniquecarrier = 'AA') AmericanCount, " +
                "(SELECT COUNT(*) FROM flights2002 WHERE uniquecarrier = 'DL') DeltaCount, " +
                "(SELECT COUNT(*) FROM flights2002 WHERE uniquecarrier = 'UA') UnitedCount " +
                "FROM flights2002";
            modelBuilder.Entity<Count>().ToSqlQuery(count2000Query).HasKey(x => new { x.AmericanCount, x.DeltaCount, x.UnitedCount });
        }

        public DbSet<FlightProject.Models.Airline> Airline { get; set; }
        public DbSet<FlightProject.Models.Airport> Airport { get; set; }
        public DbSet<FlightProject.Models.Flight2000> Flight2000 { get; set; }
        public DbSet<FlightProject.Models.Flight2001> Flight2001 { get; set; }
        public DbSet<FlightProject.Models.Flight2002> Flight2002 { get; set; }
        public DbSet<FlightProject.Models.AirlineAve> AirlineAve { get; set; }
        public DbSet<FlightProject.Models.AirlineAve2000> AirlineAve2000 { get; set; }
        public DbSet<FlightProject.Models.AirlineAve2001> AirlineAve2001 { get; set; }
        public DbSet<FlightProject.Models.AirlineAve2002> AirlineAve2002 { get; set; }
        public DbSet<FlightProject.Models.AirportAvg> AirportAvg { get; set; }
        public DbSet<FlightProject.Models.AirportAvg2000> AirportAvg2000 { get; set; }
        public DbSet<FlightProject.Models.AirportAvg2001> AirportAvg2001 { get; set; }
        public DbSet<FlightProject.Models.AirportAvg2002> AirportAvg2002 { get; set; }
        public DbSet<FlightProject.Models.DelayTrend> DelayTrend { get; set; }
        public DbSet<FlightProject.Models.DelayTrend2000> DelayTrend2000 { get; set; }
        public DbSet<FlightProject.Models.DelayTrend2001> DelayTrend2001 { get; set; }
        public DbSet<FlightProject.Models.DelayTrend2002> DelayTrend2002 { get; set; }
        public DbSet<FlightProject.Models.MaxAirline> MaxAirline { get; set; }
        public DbSet<FlightProject.Models.MaxAirport> MaxAirport { get; set; }
        public DbSet<FlightProject.Models.Count> Count { get; set; }
        
    }
}