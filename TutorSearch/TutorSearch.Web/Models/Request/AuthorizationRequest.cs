using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class AuthorizationRequest
    {

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Password.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Password should be longer than 6 characters.")]
        public string Password { get; set; }
    }
}