using Microsoft.EntityFrameworkCore;
using TutorSearch.Models.Entities;

namespace TutorSearch
{
    public class TutorSearchContext: DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        public TutorSearchContext(DbContextOptions<TutorSearchContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
