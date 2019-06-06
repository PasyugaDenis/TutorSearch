namespace TutorSearch.Web.Models.Response
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int ChatId { get; set; }


        public string AuthorName { get; set; }
    }
}