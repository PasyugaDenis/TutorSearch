using System;

namespace TutorSearch.Web.Models.Response
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsTeacher { get; set; }
    }
}