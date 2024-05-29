using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models;

public class Room
{
    [Key] 
    public int RoomId { get; set; }

    [ForeignKey("Booking")] 
    public int BookingId { get; set; }

    [Required(ErrorMessage = "Room type is required.")]
    public string RoomType { get; set; }

    [Required(ErrorMessage = "Number of adults is required.")]
    [RoomTypeAdultsValidation]
    public int NumberOfAdults { get; set; }

    [Required(ErrorMessage = "Number of children is required.")]
    public int NumberOfChildren { get; set; }

    public virtual Booking? Booking { get; set; }
}