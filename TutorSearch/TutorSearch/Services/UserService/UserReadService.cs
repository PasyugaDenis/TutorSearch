using System.Threading.Tasks;
using TutorSearch.Models.Entities;
using TutorSearch.Repositories.UserRepository;

namespace TutorSearch.Services.UserService
{
    public class UserReadService : IUserReadService
    {
        private IUserReadRepository userReadRepository;
        private IUserWriteService userWriteService;

        public UserReadService(
            IUserReadRepository userReadRepository,
            IUserWriteService userWriteService)
        {
            this.userReadRepository = userReadRepository;
            this.userWriteService = userWriteService;
        }

        public async Task<bool> CheckUserByEmailAsync(string email)
        {
            var user = await userReadRepository.GetByEmailAsync(email);

            return user != null;
        }

        public async Task<User> CheckUserByPassword(string email, string password)
        {
            var user = await userReadRepository.GetByEmailAsync(email);

            return user.Password == await userWriteService.HashPassword(password) ? user : null;
        }
    }
}
