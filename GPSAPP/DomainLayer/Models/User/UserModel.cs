using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.User
{
    public class UserModel : IUserModel
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(255, ErrorMessage = "Email must be at most 255 characters.")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Role must be at most 50 characters.")]
        public string Role { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Invalid ZIP Code.")]
        public string ZipCode { get; set; }

        [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
        public int? Age { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Url(ErrorMessage = "Invalid URL.")]
        public string Website { get; set; }

        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCardNumber { get; set; }
    }
}
