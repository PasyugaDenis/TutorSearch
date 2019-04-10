using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int ChatId { get; set; }
    }
}
