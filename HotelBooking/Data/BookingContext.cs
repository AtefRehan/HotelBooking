using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data;

public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions<BookingContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Branch>().HasData(
            new Branch { BranchId = 1, BranchName = "Cairo" },
            new Branch { BranchId = 2, BranchName = "Alex" },
            new Branch { BranchId = 3, BranchName = "Mansoura" },
            new Branch { BranchId = 4, BranchName = "PortSaid" }
        );

        base.OnModelCreating(modelBuilder);
    }
    
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }

}