using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Education { get; set; }

        public string Skill { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public int WorkExperience { get; set; }

        public int ContactsId { get; set; }
                     

        public virtual User User { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }
    }
}
