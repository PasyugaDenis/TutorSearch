using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorSearch.Models.Request
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
