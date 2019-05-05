using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your Surname.")]
        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public bool IsTeacher { get; set; }


        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}
