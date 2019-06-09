using System.ComponentModel.DataAnnotations;

namespace TutorSearch.Web.Models.Request
{
    public class MessageRequest
    {
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "IsRead is required")]
        public bool IsRead { get; set; }

        [Required(ErrorMessage = "FromUserId is required")]
        public int FromUserId { get; set; }

        [Required(ErrorMessage = "ToUserId is required")]
        public int ToUserId { get; set; }

        [Required(ErrorMessage = "ChatId is required")]
        public int ChatId { get; set; }
    }
}