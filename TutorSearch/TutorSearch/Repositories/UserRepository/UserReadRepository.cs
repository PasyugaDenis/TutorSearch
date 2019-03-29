using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.UserRepository
{
    public class UserReadRepository : IUserReadRepository
    {
        private TutorSearchContext dbContext;

        public UserReadRepository(TutorSearchContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<User> GetAsync(int id)
        {
            var result = dbContext.Users.Where(m => m.Id == id)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<List<User>> GetAllAsync()
        {
            var result = dbContext.Users.ToListAsync();
            return result;
        }

        public Task<User> GetByEmailAsync(string email)
        {
            var result = dbContext.Users.Where(m => m.Email == email)
                .SingleOrDefaultAsync();

            return result;
        }
    }
}
