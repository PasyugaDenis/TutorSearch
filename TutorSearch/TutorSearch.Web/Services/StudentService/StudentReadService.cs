using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
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

        public async Task<Student> GetStudentAsync(int id)
        {
            var model = await studentReadRepository.GetAsync(id);

            return model;
        }
    }
}