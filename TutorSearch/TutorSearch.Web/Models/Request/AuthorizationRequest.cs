﻿using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class AuthorizationRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Password should be longer than 6 characters")]
        public string Password { get; set; }
    }
}