using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Specialty { get; set; }

        public bool IsClosed { get; set; }

        public string Description { get; set; }

        public int TeacherId { get; set; }


        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
