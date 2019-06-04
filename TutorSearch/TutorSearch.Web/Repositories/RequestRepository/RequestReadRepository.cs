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
    }
}
