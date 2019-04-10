using System;

namespace TutorSearch.Web.Models.Request
{
    public class UserRequestModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsTeacher { get; set; }
    }
}
