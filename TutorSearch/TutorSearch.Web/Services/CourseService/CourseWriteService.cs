using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.CourseRepository;

namespace TutorSearch.Web.Services.CourseService
{
    public class CourseWriteService : ICourseWriteService
    {
        private TutorSearchContext dbContext;

        public CourseWriteService(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Course> AddAsync(Course course)
        {
            var result = dbContext.Courses.Add(course);
            await dbContext.SaveChangesAsync();

            return result;
        }
    }
}
