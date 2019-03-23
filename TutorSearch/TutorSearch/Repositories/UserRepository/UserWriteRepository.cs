using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.UserRepository
{
    public class UserWriteRepository : IUserWriteRepository
    {
        private TutorSearchContext dbContext;

        public UserWriteRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(User user)
        {
            dbContext.Users.Add(user);
            return dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            return dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(User user)
        {
            dbContext.Users.Remove(user);
            return dbContext.SaveChangesAsync();
        }
    }
}
