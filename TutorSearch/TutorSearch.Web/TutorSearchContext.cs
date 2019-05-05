using System.Data.Entity;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web
{
    public class TutorSearchContext: DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        public TutorSearchContext() : base("DbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //course
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Teacher)
                .WithMany(t => t.Courses);

            //message
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.FromUser);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.ToUser);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Chat)
                .WithMany(c => c.Messages);

            //request
            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Course)
                .WithMany(c => c.Requests);

            modelBuilder.Entity<Request>()
                .HasRequired(r => r.Student)
                .WithMany(s => s.Requests);

            //student
            modelBuilder.Entity<Student>()
                .HasRequired(s => s.User)
                .WithOptional(u => u.Student);

            //teacher
            modelBuilder.Entity<Teacher>()
                .HasRequired(t => t.User)
                .WithOptional(u => u.Teacher);

            //contacts
            modelBuilder.Entity<Contacts>()
                .HasRequired(c => c.Teacher)
                .WithRequiredPrincipal(t => t.Contacts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
