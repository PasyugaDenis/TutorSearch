using System;

namespace TutorSearch.Web.Models.Response
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