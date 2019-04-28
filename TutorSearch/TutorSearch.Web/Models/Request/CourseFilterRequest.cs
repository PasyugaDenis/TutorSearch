namespace TutorSearch.Web.Models.Request
{
    public class CourseFilterRequest
    {
        public int? TeacherId { get; set; }

        public string SortField { get; set; }

        public bool SortAscending { get; set; }

        public string[] SearchValues { get; set; }

        public bool? IsClosed { get; set; }
    }
}