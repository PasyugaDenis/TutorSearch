using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Repositories.UserRepository
{
    public interface IUserWriteRepository
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task RemoveAsync(User user);
    }
}
