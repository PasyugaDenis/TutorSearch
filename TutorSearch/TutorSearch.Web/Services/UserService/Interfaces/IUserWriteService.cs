using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.UserService
{
    public interface IUserWriteService
    {
        Task UpdateUserAsync(User model);

        Task<User> RegisterUserAsync(User model);

        string HashPassword(string password);
    }
}
