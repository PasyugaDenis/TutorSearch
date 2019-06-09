using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.CourseRepository
{
    public class CourseWriteRepository : ICourseWriteRepository
    {
        private TutorSearchContext dbContext;

        public CourseWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Course> AddAsync(Course course)
        {
            var result = dbContext.Courses.Add(course);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(Course course)
        {
            dbContext.Entry(course).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Course course)
        {
            dbContext.Courses.Remove(course);
            return dbContext.SaveChangesAsync();
        }
    }
}
