using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Models.Request;

namespace TutorSearch.Web.Services.UserService
{
    public interface IUserWriteService
    {
        Task EditUserAsync(User model);

        Task<User> RegisterUserAsync(UserRequest model);

        string HashPassword(string password);
    }
}
