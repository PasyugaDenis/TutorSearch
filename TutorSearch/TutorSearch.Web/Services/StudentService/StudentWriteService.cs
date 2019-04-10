using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.StudentRepository;

namespace TutorSearch.Web.Services.StudentService
{
    public class StudentWriteService : IStudentWriteService
    {
        private IStudentWriteRepository studentWriteRepository;

        public StudentWriteService(
            IStudentWriteRepository studentWriteRepository)
        {
            this.studentWriteRepository = studentWriteRepository;
        }

        public Task AddStudentAsync(Student model)
        {
            return studentWriteRepository.AddAsync(model);
        }
    }
}
