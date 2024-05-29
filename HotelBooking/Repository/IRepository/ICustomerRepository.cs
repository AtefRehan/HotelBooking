using HotelBooking.Models;

namespace HotelBooking.Repository.IRepository;

public interface ICustomerRepository
{
    Task<Customer> GetCustomerByNationalId(string nationalId);
    Task AddCustomer(Customer customer);
}