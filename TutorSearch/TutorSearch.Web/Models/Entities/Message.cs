using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int ChatId { get; set; }


        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
