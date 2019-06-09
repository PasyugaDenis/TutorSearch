namespace TutorSearch.Web.Models.Response
{
    public class StudentViewModel : UserViewModel
    {
        public string Type { get; set; }

        public string Skill { get; set; }

        public string Education { get; set; }

        public string Description { get; set; }
    }
}