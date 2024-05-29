using HotelBooking.Models;

namespace HotelBooking.Repository.IRepository;

public interface IRoomRepository
{
    Task AddRoom(Room room);

}