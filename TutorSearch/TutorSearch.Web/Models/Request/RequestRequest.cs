using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class RequestRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        public double? Rating { get; set; }

        public string Comment { get; set; }
    }
}