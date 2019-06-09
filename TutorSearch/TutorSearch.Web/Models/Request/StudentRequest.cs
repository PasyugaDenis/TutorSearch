namespace TutorSearch.Web.Models.Request
{
    public class StudentRequest : UserRequest
    {
        public string Type { get; set; }

        public string Skill { get; set; }

        public string Education { get; set; }

        public string Description { get; set; }
    }
}