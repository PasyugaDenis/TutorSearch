using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Skill { get; set; }

        public int WorkExperience { get; set; }

        public bool IsPrivate { get; set; }

        public string Description { get; set; }

        public int ContactsId { get; set; }
    }
}
