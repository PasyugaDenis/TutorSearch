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

        public Task<List<Course>> SearchAsync(int? teacherId, bool? isClosed, string[] searchValues)
        {
            IQueryable<Course> result = dbContext.Courses.AsQueryable();

            if (teacherId.HasValue)
            {
                result = result.Where(m => m.TeacherId == teacherId.Value);
            }

            if (isClosed.HasValue)
            {
                result = result.Where(m => m.IsClosed == isClosed.Value);
            }

            if (searchValues.Length > 0)
            {
                result = result.Where(m =>
                    searchValues.Contains(m.Title) ||
                    searchValues.Contains(m.Specialty));
            }

            return result.ToListAsync();
        }
    }
}
