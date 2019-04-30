using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.RequestRepository
{
    public class RequestWriteRepository : IRequestWriteRepository
    {
        private TutorSearchContext dbContext;

        public RequestWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Request> AddAsync(Request request)
        {
            var result = dbContext.Requests.Add(request);
            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(Request request)
        {
            dbContext.Entry(request).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(Request request)
        {
            dbContext.Requests.Remove(request);
            return dbContext.SaveChangesAsync();
        }
    }
}
