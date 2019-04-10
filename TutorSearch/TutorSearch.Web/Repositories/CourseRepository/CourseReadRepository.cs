using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.CourseRepository
{
    public class CourseReadRepository : ICourseReadRepository
    {
        private TutorSearchContext dbContext;

        public CourseReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Course> GetAsync(int id)
        {
            var result = dbContext.Courses.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Course>> GetAllAsync()
        {
            var result = dbContext.Courses.ToListAsync();
            return result;
        }
    }
}
