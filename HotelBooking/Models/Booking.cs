using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models;

public class Booking
{
    [Key] 
    public int BookingId { get; set; }

    [ForeignKey("Customer")] 
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Branch is required.")]
    public int BranchId { get; set; }

    [Required(ErrorMessage = "Check-in date is required.")]
    public DateTime CheckInDate { get; set; }

    [Required(ErrorMessage = "Check-out date is required.")]
    public DateTime CheckOutDate { get; set; }

    [Required(ErrorMessage = "Total rooms are required.")]
    public int TotalRooms { get; set; }

    public bool DiscountApplied { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual Branch? Branch { get; set; }

    public virtual ICollection<Room>? Rooms { get; set; }
}