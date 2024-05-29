using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly BookingContext _context;

        public RoomController(IRoomRepository roomRepository, BookingContext context)
        {
            _roomRepository = roomRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int bookingId, int roomsLeftToCreate)
        {
            ViewBag.BookingId = bookingId;
            ViewBag.RoomsLeftToCreate = roomsLeftToCreate;
            ViewBag.RoomTypeList = GetRoomTypeList(); // Pass the room types to the view
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Room room, int bookingId, int roomsLeftToCreate)
        {
            if (ModelState.IsValid)
            {
                if (bookingId > 0 && !string.IsNullOrEmpty(room.RoomType) && room.NumberOfAdults > 0)
                {
                    room.BookingId = bookingId;
                    await _roomRepository.AddRoom(room);
                    TempData["success"] = "Room added successfully";


                    roomsLeftToCreate--;
                    if (roomsLeftToCreate > 0)
                    {
                        return RedirectToAction("Create",
                            new { bookingId = bookingId, roomsLeftToCreate = roomsLeftToCreate });
                    }

                    else
                    {
                        return RedirectToAction("Index", "Booking");
                    }
                }
            }

            ViewBag.ErrorMessage = "Invalid input data. Please ensure all fields are filled correctly.";
            ViewBag.BookingId = bookingId;
            ViewBag.RoomsLeftToCreate = roomsLeftToCreate;
            ViewBag.RoomTypeList = GetRoomTypeList(); 
            return View(room);
        }
        private List<SelectListItem> GetRoomTypeList()
        {

            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Single", Text = "Single" },
                new SelectListItem { Value = "Double", Text = "Double" },

            };
        }
    }
}