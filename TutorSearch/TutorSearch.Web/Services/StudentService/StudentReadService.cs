using System.Threading.Tasks;
using TutorSearch.Web.Models.Response;
using TutorSearch.Web.Repositories.StudentRepository;
using TutorSearch.Web.Repositories.UserRepository;

namespace TutorSearch.Web.Services.StudentService
{
    public class StudentReadService : IStudentReadService
    {
        private IStudentReadRepository studentReadRepository;
        private IUserReadRepository userReadRepository;

        public StudentReadService(
            IStudentReadRepository studentReadRepository,
            IUserReadRepository userReadRepository)
        {
            this.studentReadRepository = studentReadRepository;
            this.userReadRepository = userReadRepository;
        }

        public async Task<StudentViewModel> ViewStudentByIdAsync(int id)
        {
            var student = await studentReadRepository.GetAsync(id);
            var user = await userReadRepository.GetAsync(id);

            if (student == null || user == null)
                return null;

            StudentViewModel studentViewModel = new StudentViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Birthday = user.Birthday,
                Email = user.Email,
                Phone = user.Phone,
                isTeacher = user.IsTeacher,
                Type = student.Type,
                Skill = student.Skill,
                Education = student.Education,
                Description = student.Description
            };

            return studentViewModel;
        }
    }
}