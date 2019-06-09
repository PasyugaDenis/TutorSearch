using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.RequestRepository
{
    public class RequestReadRepository : IRequestReadRepository
    {
        private TutorSearchContext dbContext;

        public RequestReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Request> GetAsync(int id)
        {
            var result = dbContext.Requests.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<Request>> GetAllByCourseIdAsync(int courseId)
        {
            var result = dbContext.Requests.Where(m => m.CourseId == courseId).ToListAsync();

            return result;
        }

        public Task<List<Request>> GetAllAsync()
        {
            var result = dbContext.Requests.ToListAsync();
            return result;
        }

        public Task<List<Request>> GetByCourseIdAsync(int courseId)
        {
            var result = dbContext.Requests.Where(m => m.CourseId == courseId).ToListAsync();
            return result;
        }

        public async Task<List<Request>> GetByTeacherIdAsync(int userId)
        {
            var coursesIds = await dbContext.Courses.Where(x => x.TeacherId == userId).Select(x => x.Id).ToListAsync();
            var result = await dbContext.Requests.Where(x => coursesIds.Contains(x.CourseId)).ToListAsync();

            return result;
        }
        public async Task<List<Request>> GetByStudentIdAsync(int userId)
        {
            var result = await dbContext.Requests.Where(x => x.StudentId == userId).ToListAsync();

            return result;
        }
    }
}
