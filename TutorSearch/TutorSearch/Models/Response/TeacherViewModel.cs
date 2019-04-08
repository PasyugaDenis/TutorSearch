using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorSearch.Models.Response
{
    public class TeacherViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool isTeacher { get; set; }

        public string Type { get; set; }

        public string Skill { get; set; }

        public int WorkExperience { get; set; }

        public bool IsPrivate { get; set; }

        public string Description { get; set; }
    }
}
