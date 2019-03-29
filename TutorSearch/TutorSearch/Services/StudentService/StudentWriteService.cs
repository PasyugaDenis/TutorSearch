using System.Threading.Tasks;
using TutorSearch.Models.Entities;
using TutorSearch.Repositories.StudentRepository;

namespace TutorSearch.Services.StudentService
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
