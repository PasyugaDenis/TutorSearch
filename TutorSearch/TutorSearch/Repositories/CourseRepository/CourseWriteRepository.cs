using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.CourseRepository
{
    public class CourseWriteRepository : ICourseWriteRepository
    {
        private TutorSearchContext dbContext;

        public CourseWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Course course)
        {
            dbContext.Courses.Add(course);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Course course)
        {
            dbContext.Courses.Update(course);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Course course)
        {
            dbContext.Courses.Remove(course);
            return dbContext.SaveChangesAsync();
        }
    }
}
