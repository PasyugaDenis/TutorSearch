using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class ChatRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "IsBlocked is required")]
        public bool IsBlocked { get; set; }
    }
}