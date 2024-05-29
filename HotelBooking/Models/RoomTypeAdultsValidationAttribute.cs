using System;
using System.ComponentModel.DataAnnotations;
using HotelBooking.Models;

public class RoomTypeAdultsValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var room = (Room)validationContext.ObjectInstance;
        if (room.RoomType == "Single" && room.NumberOfAdults > 1)
        {
            return new ValidationResult("A Single room can have at most one adult.");
        }
        if (room.NumberOfAdults < 1)
        {
            return new ValidationResult("There must be at least one adult in any room.");
        }
        return ValidationResult.Success;
    }
}