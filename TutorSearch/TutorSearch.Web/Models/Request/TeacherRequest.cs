namespace TutorSearch.Web.Models.Request
{
    public class TeacherRequest : UserRequest
    {
        public string Education { get; set; }

        public string Skill { get; set; }

        public int WorkExperience { get; set; }

        public bool IsPrivate { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public ContactsRequest Contacts { get; set; }
    }
}