using System;
using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class RequestRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public bool? IsConfirmed { get; set; }

        [Required(ErrorMessage = "IsClosed is required")]
        public bool IsClosed { get; set; }

        [Required(ErrorMessage = "DateOfRegistration is required")]
        public DateTime DateOfRegistration { get; set; }

        public double? Rating { get; set; }

        public string Comment { get; set; }

        [Required(ErrorMessage = "StudentId is required")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "CourseId is required")]
        public int CourseId { get; set; }
    }
}