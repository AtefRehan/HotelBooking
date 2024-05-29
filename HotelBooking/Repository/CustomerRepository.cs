using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly BookingContext _context;

    public CustomerRepository(BookingContext context)
    {
        _context = context;
    }

    public async Task<Customer> GetCustomerByNationalId(string nationalId)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.NationalId == nationalId);
    }

    public async Task AddCustomer(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}
