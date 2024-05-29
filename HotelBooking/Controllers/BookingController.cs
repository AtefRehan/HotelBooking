using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace HotelBooking.Controllers;

public class BookingController : Controller
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly BookingContext _context;

    public BookingController(IBookingRepository bookingRepository, ICustomerRepository customerRepository,
        BookingContext context)
    {
        _bookingRepository = bookingRepository;
        _customerRepository = customerRepository;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var bookings = await _bookingRepository.GetBookings();
        return View(bookings);
    }

    public async Task<IActionResult> Details(int id)
    {
        var booking = await _bookingRepository.GetBookingById(id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.BranchList = _context.Branches.Select(b => new SelectListItem
        {
            Value = b.BranchId.ToString(),
            Text = b.BranchName
        }).ToList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return View(booking);
        }

        var existingCustomer = await _customerRepository.GetCustomerByNationalId(booking.Customer.NationalId);

        if (existingCustomer != null)
        {
            booking.CustomerId = existingCustomer.CustomerId;
            booking.DiscountApplied = existingCustomer.PreviousBookingsCount > 0;
            existingCustomer.PreviousBookingsCount++;
        }
        else
        {
            booking.Customer.PreviousBookingsCount = 1;
            await _customerRepository.AddCustomer(booking.Customer);
            booking.CustomerId = booking.Customer.CustomerId;
        }

        await _bookingRepository.AddBooking(booking);
        TempData["success"] = "Booking added successfully please choose room details";
        return RedirectToAction("Create", "Room",
            new
            {
                bookingId = booking.BookingId, totalRooms = booking.TotalRooms, roomsLeftToCreate = booking.TotalRooms
            });
    }
}