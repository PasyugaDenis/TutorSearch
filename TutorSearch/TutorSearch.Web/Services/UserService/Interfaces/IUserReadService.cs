using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.UserService
{
    public interface IUserReadService
    {
        Task<User> GetByIdAsync(int id);

        Task<bool> CheckUserByEmailAsync(string email);

        Task<User> SearchAuthorizationUserAsync(string email);

        bool CheckUserCorrectPassword(string enterPassword, string hashUserPassword);
    }
}
