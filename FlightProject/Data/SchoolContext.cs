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

        }

        public DbSet<FlightProject.Models.Airline> Airline { get; set; }
        public DbSet<FlightProject.Models.Airport> Airport { get; set; }
        public DbSet<FlightProject.Models.Flight2000> Flight2000 { get; set; }
        public DbSet<FlightProject.Models.Flight2001> Flight2001 { get; set; }
        public DbSet<FlightProject.Models.Flight2002> Flight2002 { get; set; }
    }
}