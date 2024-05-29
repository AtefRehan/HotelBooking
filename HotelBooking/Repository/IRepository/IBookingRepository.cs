
using HotelBooking.Models;

namespace HotelBooking.Repository.IRepository;

public interface IBookingRepository
{
    
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> GetBookingById(int id);
        Task AddBooking(Booking booking);
}