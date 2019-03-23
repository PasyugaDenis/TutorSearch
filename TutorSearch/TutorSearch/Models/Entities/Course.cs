namespace TutorSearch.Models.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Specialty { get; set; }

        public bool IsClosed { get; set; }

        public string Description { get; set; }

        public int TeacherId { get; set; }
    }
}
