using System.Threading.Tasks;
using TutorSearch.Models.Entities;

namespace TutorSearch.Services.UserService
{
    public interface IUserReadService
    {
        Task<bool> CheckUserByEmailAsync(string email);
        Task<User> CheckUserByPassword(string email, string password);
    }
}
