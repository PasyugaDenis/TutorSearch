using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.RequestRepository
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
    }
}
