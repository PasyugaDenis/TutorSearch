using System.Threading.Tasks;
using TutorSearch.Models.Entities;
using TutorSearch.Models.Request;

namespace TutorSearch.Services.UserService
{
    public interface IUserWriteService
    {
        Task<User> RegisterUserAsync(UserRequestModel model);

        string HashPassword(string password);
    }
}
