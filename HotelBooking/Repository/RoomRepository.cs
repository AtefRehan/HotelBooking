using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.IRepository;

namespace HotelBooking.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly BookingContext _bookingContext;

    public RoomRepository(BookingContext bookingContext)
    {
        _bookingContext = bookingContext;
    }

    public async Task AddRoom(Room room)
    {
        await _bookingContext.Rooms.AddAsync(room);
        await _bookingContext.SaveChangesAsync();
    }
}