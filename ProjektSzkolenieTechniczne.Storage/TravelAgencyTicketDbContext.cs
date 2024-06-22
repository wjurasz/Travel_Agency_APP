using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczneStorage.Entities;

namespace SzkolenieTechniczneStorage
{
    public class TravelAgencyTicketDbContext : DbContext
    {
        public TravelAgencyTicketDbContext(DbContextOptions<TravelAgencyTicketDbContext> options)
             : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Tour)
                .WithMany(t => t.Flights)
                .HasForeignKey(f => f.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Tour)
                .WithMany()
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
