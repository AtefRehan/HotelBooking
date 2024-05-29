using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly BookingContext _context;

    public BookingRepository(BookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetBookings()
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Branch)
            .Include(b => b.Rooms)
            .ToListAsync();
    }

    public async Task<Booking> GetBookingById(int id)
    {
        return await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Branch)
            .Include(b => b.Rooms)
            .FirstOrDefaultAsync(b => b.BookingId == id);
    }

    public async Task AddBooking(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
    }
}

