using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorSearch.Web.Models.Request
{
    public class CourseRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter Specialty.")]
        public string Specialty { get; set; }

        public bool IsClosed { get; set; }

        [Required(ErrorMessage = "Enter Description.")]
        public string Description { get; set; }

        public int TeacherId { get; set; }
    }
}