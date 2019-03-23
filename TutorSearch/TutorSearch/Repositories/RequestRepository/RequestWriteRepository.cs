using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.RequestRepository
{
    public class RequestWriteRepository : IRequestWriteRepository
    {
        private TutorSearchContext dbContext;

        public RequestWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Request request)
        {
            dbContext.Requests.Add(request);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Request request)
        {
            dbContext.Requests.Update(request);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Request request)
        {
            dbContext.Requests.Remove(request);
            return dbContext.SaveChangesAsync();
        }
    }
}
