using System;
using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class UserRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your Surname.")]
        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+)?(\d{10})(\d{1,4})?$", ErrorMessage = "Invalid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public bool IsTeacher { get; set; }

        [Required(ErrorMessage = "Enter your Password.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Password should be longer than 6 characters.")]
        public string Password { get; set; }
    }
}
