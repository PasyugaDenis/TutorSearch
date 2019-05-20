using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorSearch.Web.Models.Response
{
    public class TeacherPageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Education { get; set; }

        public string Skill { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public int WorkExperience { get; set; }

        public ContactsViewModel Contacts { get; set; }
    }
}