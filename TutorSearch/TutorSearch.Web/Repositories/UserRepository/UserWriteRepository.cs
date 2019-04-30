using System.Data.Entity;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.UserRepository
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private TutorSearchContext dbContext;

        public UserWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AddAsync(User user)
        {
            var result = dbContext.Users.Add(user);

            await dbContext.SaveChangesAsync();

            return result;
        }

        public Task UpdateAsync(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(User user)
        {
            dbContext.Users.Remove(user);
            return dbContext.SaveChangesAsync();
        }
    }
}
