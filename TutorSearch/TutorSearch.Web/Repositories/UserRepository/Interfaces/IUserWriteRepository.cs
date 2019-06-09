using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.UserRepository
{
    public interface IUserWriteRepository
    {
        Task<User> AddAsync(User user);

        Task UpdateAsync(User user);

        Task RemoveAsync(User user);
    }
}
