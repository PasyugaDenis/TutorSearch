using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.UserRepository
{
    public interface IUserReadRepository
    {
        Task<User> GetAsync(int id);

        Task<List<User>> GetAllAsync();
    }
}
