using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Contacts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Skype { get; set; }

        public string Telegram { get; set; }

        public string Facebook { get; set; }

        public string Viber { get; set; }

        public string WhatsUp { get; set; }


        public virtual Teacher Teacher { get; set; }
    }
}
