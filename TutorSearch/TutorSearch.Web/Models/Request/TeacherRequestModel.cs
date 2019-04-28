namespace TutorSearch.Web.Models.Request
{
    public class TeacherRequestModel : UserRequestModel
    {
        public string Education { get; set; }

        public string Skill { get; set; }

        public int WorkExperience { get; set; }

        public bool IsPrivate { get; set; }

        public string Description { get; set; }

        public string City { get; set; }
    }
}