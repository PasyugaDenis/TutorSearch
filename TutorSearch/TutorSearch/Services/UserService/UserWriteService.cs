using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TutorSearch.Models.Entities;
using TutorSearch.Models.Request;
using TutorSearch.Repositories.UserRepository;
using TutorSearch.Services.StudentService;
using TutorSearch.Services.TeacherService;

namespace TutorSearch.Services.UserService
{
    public class UserWriteService : IUserWriteService
    {
        //student services
        private IStudentWriteService studentWriteService;

        //teacher services
        private ITeacherWriteService teacherWriteService;

        //user repositories
        private IUserWriteRepository userWriteRepository;
        private IUserReadRepository userReadRepository;

        public UserWriteService(
            IStudentWriteService studentWriteService,
            ITeacherWriteService teacherWriteService,
            IUserWriteRepository userWriteRepository,
            IUserReadRepository userReadRepository)
        {
            this.studentWriteService = studentWriteService;

            this.teacherWriteService = teacherWriteService;

            this.userWriteRepository = userWriteRepository;
            this.userReadRepository = userReadRepository;
        }

        public async Task<User> RegisterUserAsync(UserRequestModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Password = HashPassword(model.Password),
                Birthday = model.Birthday ?? new DateTime(),
                Phone = model.Phone,
                IsTeacher = model.IsTeacher
            };

            await userWriteRepository.AddAsync(user);

            var newUser = (await userReadRepository.GetByEmailAsync(model.Email));

            if (model.IsTeacher)
            {
                var teacher = new Teacher
                {
                    Id = newUser.Id
                };

                await teacherWriteService.AddTeacherAsync(teacher);
            }
            else
            {
                var student = new Student
                {
                    Id = newUser.Id
                };

                await studentWriteService.AddStudentAsync(student);
            }

            return newUser;
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
