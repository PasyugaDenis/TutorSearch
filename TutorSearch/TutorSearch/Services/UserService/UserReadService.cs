using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;
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

        public async Task<User> SearchAuthorizationUserAsync(string email)
        {
            var user = await userReadRepository.GetByEmailAsync(email);

            return user;
        }

        public bool CheckUserCorrectPassword(string enteredPassword, string hashUserPassword)
        {
            return HashPassword(enteredPassword) == hashUserPassword ? true : false;
        }

        //Utils
        private string HashPassword(string password)
        {
            var bytes = Encoding.Unicode.GetBytes(password);

            var CSP = new MD5CryptoServiceProvider();

            var byteHash = CSP.ComputeHash(bytes);

            var hash = new StringBuilder();

            foreach (byte b in byteHash)
            {
                hash.Append(string.Format("{0:x2}", b));
            }

            return hash.ToString();
        }
    }
}
