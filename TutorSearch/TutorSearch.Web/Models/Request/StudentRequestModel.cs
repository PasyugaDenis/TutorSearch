namespace TutorSearch.Web.Models.Request
{
    public class StudentRequestModel : UserRequestModel
    {
        public string Type { get; set; }

        public string Skill { get; set; }

        public string Education { get; set; }

        public string Description { get; set; }
    }
}