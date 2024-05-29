using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain letters only.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "National ID is required.")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "National ID must be a 14-digit numeric value.")]
    [Display(Name = "National ID")]
    public string NationalId { get; set; }
    

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Invalid phone number format.")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    public int PreviousBookingsCount { get; set; }
}