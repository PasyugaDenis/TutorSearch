using System.Threading.Tasks;
using TutorSearch.Repositories.UserRepository;

namespace TutorSearch.Services.UserService
{
    public class UserReadService : IUserReadService
    {
        private IUserReadRepository userReadRepository;

        public UserReadService(
            IUserReadRepository userReadRepository)
        {
            this.userReadRepository = userReadRepository;
        }

        public async Task<bool> CheckUserByEmailAsync(string email)
        {
            var user = await userReadRepository.GetByEmailAsync(email);

            return user != null;
        }
    }
}
