using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.StudentRepository;
using TutorSearch.Web.Repositories.TeacherRepository;
using TutorSearch.Web.Repositories.UserRepository;

namespace TutorSearch.Web.Services.UserService
{
    public class UserWriteService : IUserWriteService
    {
        private IUserWriteRepository userWriteRepository;
        private IUserReadRepository userReadRepository;
        private IStudentWriteRepository studentWriteRepository;
        private ITeacherWriteRepository teacherWriteRepository;

        public UserWriteService(
            IUserWriteRepository userWriteRepository,
            IUserReadRepository userReadRepository,
            IStudentWriteRepository studentWriteRepository,
            ITeacherWriteRepository teacherWriteRepository)
        {
            this.userWriteRepository = userWriteRepository;
            this.userReadRepository = userReadRepository;
            this.studentWriteRepository = studentWriteRepository;
            this.teacherWriteRepository = teacherWriteRepository;
        }

        public async Task UpdateUserAsync(User model)
        {
            await userWriteRepository.UpdateAsync(model);
        }

        public async Task<User> RegisterUserAsync(User model)
        {
            var result = await userWriteRepository.AddAsync(model);

            return result;
        }

        //Utils
        public string HashPassword(string password)
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
