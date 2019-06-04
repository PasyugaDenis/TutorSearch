using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class CourseRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Specialty is required")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "IsClosed is required")]
        public bool IsClosed { get; set; }

        public string Description { get; set; }

        public int TeacherId { get; set; }
    }
}