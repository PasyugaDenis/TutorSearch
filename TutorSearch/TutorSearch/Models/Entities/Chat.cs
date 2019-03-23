namespace TutorSearch.Models.Entities
{
    public class Chat
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsBlocked { get; set; }
    }
}
