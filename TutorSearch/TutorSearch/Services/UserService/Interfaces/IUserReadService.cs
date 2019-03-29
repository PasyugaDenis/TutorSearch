using System.Threading.Tasks;

namespace TutorSearch.Services.UserService
{
    public interface IUserReadService
    {
        Task<bool> CheckUserByEmailAsync(string email);
    }
}
