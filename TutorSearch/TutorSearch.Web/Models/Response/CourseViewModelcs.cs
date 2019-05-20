using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorSearch.Web.Models.Response
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string TutorName { get; set; }
        public string TutorSurname { get; set; }

        public string Title { get; set; }
        public string City { get; set; }

        public string Specialty { get; set; }

        public bool IsClosed { get; set; }

        public string Description { get; set; }
    }
}