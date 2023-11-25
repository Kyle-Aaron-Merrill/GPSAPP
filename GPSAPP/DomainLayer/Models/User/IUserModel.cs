using System;

namespace DomainLayer.Models.User
{
    public interface IUserModel
    {
        int? Age { get; set; }
        string CreditCardNumber { get; set; }
        DateTime? DateOfBirth { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        string Role { get; set; }
        int UserID { get; set; }
        string Username { get; set; }
        string Website { get; set; }
        string ZipCode { get; set; }
    }
}