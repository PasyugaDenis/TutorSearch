using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Chat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsBlocked { get; set; }


        public virtual ICollection<Message> Messages { get; set; }
    }
}
