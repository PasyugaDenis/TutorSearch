using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Type { get; set; }

        public string Skill { get; set; }

        public string Education { get; set; }

        public string Description { get; set; }


        public virtual User User { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
