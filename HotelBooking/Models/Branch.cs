using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models;

public class Branch
{
    [Key]
    [Display(Name = "Branch")]
    public int BranchId { get; set; }
    
    [Required(ErrorMessage = "Branch name is required.")]
    public string BranchName { get; set; }

}