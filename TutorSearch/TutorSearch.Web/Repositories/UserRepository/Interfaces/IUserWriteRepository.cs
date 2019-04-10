using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Repositories.UserRepository
{
    public interface IUserWriteRepository
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task RemoveAsync(User user);
    }
}
