using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.UserRepository
{
    public interface IUserReadRepository
    {
        Task<int?> GetMaxIdAsync();

        Task<User> GetAsync(int id);

        Task<List<User>> GetAllAsync();

        Task<User> GetByEmailAsync(string email);
    }
}
