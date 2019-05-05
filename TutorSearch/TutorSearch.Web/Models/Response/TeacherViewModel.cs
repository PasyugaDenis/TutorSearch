namespace TutorSearch.Web.Models.Response
{
    public class TeacherViewModel : UserViewModel
    {
        public int Id { get; set; }

        public string Education { get; set; }

        public string Skill { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public int WorkExperience { get; set; }

        public ContactsViewModel Contacts { get; set; }
    }
}
