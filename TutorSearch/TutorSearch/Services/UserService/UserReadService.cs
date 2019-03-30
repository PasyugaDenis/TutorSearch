<<<<<<< a4d9f3e4249ad5b7508e5ad723fc57ca805e5275
﻿using System.Threading.Tasks;
=======
﻿using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;
>>>>>>> [task_6] Authorization
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

        public async Task<User> SearchAuthorizationUserAsync(string email)
        {
            var user = await userReadRepository.GetByEmailAsync(email);

            return user;
        }

        public bool CheckUserCorrectPassword(string enteredPassword, string userPassword)
        {
            return HashPassword(enteredPassword) == userPassword ? true : false;
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
