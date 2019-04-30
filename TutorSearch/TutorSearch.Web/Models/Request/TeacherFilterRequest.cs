namespace TutorSearch.Web.Models.Request
{
    public class TeacherFilterRequest
    {
        public string SortField { get; set; }

        public bool SortAscending { get; set; }

        public int? SearchFrom { get; set; }

        public int? SearchTo { get; set; }

        public bool? IsPrivate { get; set; }

        public string[] SearchValues { get; set; }
    }
}